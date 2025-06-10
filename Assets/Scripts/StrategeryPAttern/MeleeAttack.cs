using UnityEngine;

public class MeleeAttack : IAttackStrategy
{
    private float attackRange = 2f;
    private int damage = 10;
    private GameObject weaponModel;

    public MeleeAttack(GameObject model)
    {
        weaponModel = model;
    }

    public void ExecuteAttack(Transform playerTransform)
    {
        Debug.Log("Ataque cuerpo a cuerpo con espada!");

        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, playerTransform.forward, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>()?.TakeDamage(damage);
            }
        }
    }

    public GameObject GetWeaponModel()
    {
        return weaponModel;
    }

}

public interface IAttackStrategy
{
    void ExecuteAttack(Transform playerTransform);
    GameObject GetWeaponModel();
}
