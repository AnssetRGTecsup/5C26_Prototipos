using UnityEngine;

public class MagicAttack : IAttackStrategy
{
    private GameObject magicEffectPrefab;
    private GameObject weaponModel;
    private float radius = 3f;
    private int damage = 15;

    public MagicAttack(GameObject magicEffectPrefab, GameObject model)
    {
        this.magicEffectPrefab = magicEffectPrefab;
        weaponModel = model;
    }

    public void ExecuteAttack(Transform playerTransform)
    {
        Debug.Log("Lanzando hechizo con bastón mágico!");

        GameObject.Instantiate(
            magicEffectPrefab,
            playerTransform.position + playerTransform.forward * 2f,
            Quaternion.identity
        );

        Collider[] hitColliders = Physics.OverlapSphere(
            playerTransform.position + playerTransform.forward * 2f,
            radius
        );

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.GetComponent<Enemy>()?.TakeDamage(damage);
            }
        }
    }

    public GameObject GetWeaponModel()
    {
        return weaponModel;
    }
}