using UnityEngine;

public class RangeAttack : IAttackStrategy
{
    private GameObject projectilePrefab;
    private GameObject weaponModel;
    private float projectileSpeed = 15f;
    private int damage = 7;

    public RangeAttack(GameObject projectilePrefab, GameObject model)
    {
        this.projectilePrefab = projectilePrefab;
        weaponModel = model;
    }

    public void ExecuteAttack(Transform playerTransform)
    {
        Debug.Log("Disparando flecha con arco!");

        GameObject projectile = GameObject.Instantiate(
            projectilePrefab,
            playerTransform.position + playerTransform.forward,
            playerTransform.rotation
        );

        projectile.GetComponent<Rigidbody>().linearVelocity = playerTransform.forward * projectileSpeed;
        projectile.GetComponent<Projectile>().SetDamage(damage);
    }

    public GameObject GetWeaponModel()
    {
        return weaponModel;
    }
}