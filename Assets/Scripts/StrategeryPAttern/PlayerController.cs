using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    [Header("Weapon Models")]
    public Transform weaponHolder;
    private GameObject currentWeaponModel;

    [Header("Attack Strategies")]
    public GameObject projectilePrefab;
    public GameObject magicEffectPrefab;
    public GameObject swordModel;
    public GameObject bowModel;
    public GameObject staffModel;

    private IAttackStrategy currentAttackStrategy;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SetAttackStrategy(new MeleeAttack(swordModel));
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleAttackInput();
        HandleStrategyChange();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical;
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);
    }

    private void HandleRotation()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }

    private void HandleAttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentAttackStrategy?.ExecuteAttack(transform);
        }
    }

    private void HandleStrategyChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetAttackStrategy(new MeleeAttack(swordModel));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetAttackStrategy(new RangeAttack(projectilePrefab, bowModel));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetAttackStrategy(new MagicAttack(magicEffectPrefab, staffModel));
        }
    }

    public void SetAttackStrategy(IAttackStrategy strategy)
    {
        // Destruir el arma actual
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        currentAttackStrategy = strategy;

        // Instanciar el nuevo modelo de arma
        currentWeaponModel = Instantiate(strategy.GetWeaponModel(), weaponHolder);
        currentWeaponModel.transform.localPosition = Vector3.zero;
        currentWeaponModel.transform.localRotation = Quaternion.identity;
    }
}