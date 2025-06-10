using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Attack", menuName = "Attacks/Projectile Attack")]
public class MagicAttackStrategy : AttackStrategy
{
    [Header("Datos del Proyectil")]
    public GameObject projectilePrefab;
    public float launchForce = 20f;

    public override void Attack(Transform attacker)
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("¡No se ha asignado un prefab de proyectil a esta estrategia!");
            return;
        }

        Debug.Log("Lanzando un proyectil mágico...");

        Vector3 spawnPosition = attacker.position + attacker.forward * 1.0f;
        GameObject projectileInstance = Instantiate(projectilePrefab, spawnPosition, attacker.rotation);

        Rigidbody rb = projectileInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(attacker.forward * launchForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("¡El prefab del proyectil no tiene un componente Rigidbody!");
        }
    }
}