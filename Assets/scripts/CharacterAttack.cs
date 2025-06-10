using UnityEngine;
using UnityEngine.InputSystem; 

public class CharacterAttack : MonoBehaviour
{
    [Header("Tipos de Ataque (Assets)")]
    [SerializeField] private AttackStrategy _meleeAttack;
    [SerializeField] private AttackStrategy _rangedAttack;
    [SerializeField] private AttackStrategy _magicAttack;

    private IAttackStrategy _currentStrategy;

    void Start()
    {
        SetStrategy(_meleeAttack);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ExecuteAttack();
        }
    }

    public void OnSelectMelee(InputAction.CallbackContext context)
    {
        if (context.performed) SetStrategy(_meleeAttack);
    }

    public void OnSelectRanged(InputAction.CallbackContext context)
    {
        if (context.performed) SetStrategy(_rangedAttack);
    }

    public void OnSelectMagic(InputAction.CallbackContext context)
    {
        if (context.performed) SetStrategy(_magicAttack);
    }


    private void SetStrategy(IAttackStrategy newStrategy)
    {
        this._currentStrategy = newStrategy;
        var so = (ScriptableObject)newStrategy;
        Debug.Log("Estrategia cambiada a: " + so.name);
    }

    private void ExecuteAttack()
    {
        _currentStrategy?.Attack(this.transform);
    }
}