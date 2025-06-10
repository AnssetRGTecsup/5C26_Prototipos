using UnityEngine;

[CreateAssetMenu(fileName = "New Raycast Attack", menuName = "Attacks/Raycast Attack")]
public class RaycastAttackStrategy : AttackStrategy
{
    [Header("Datos del Raycast")]
    public float range = 3f;
    public LayerMask targetLayer;

    public override void Attack(Transform attacker)
    {
        Debug.Log($"Ejecutando ataque Raycast con {damage} de daño y {range} de rango.");

        Debug.DrawRay(attacker.position, attacker.forward * range, Color.yellow, 1.5f);

        RaycastHit hit;
        if (Physics.Raycast(attacker.position, attacker.forward, out hit, range, targetLayer))
        {
            if (hit.collider.CompareTag("Enemigo"))
            {
                Debug.Log($"¡Impacto a {hit.collider.name}!");
            }
        }
    }
}