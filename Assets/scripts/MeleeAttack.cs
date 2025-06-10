using UnityEngine;

public class MeleeAttack : IAttackStrategy
{
    private float _range = 1.5f; 
    private float _damage = 10f;

    public void Attack(Transform attacker)
    {
        Debug.Log("Ejecutando ataque MELEE");
        var attackOrigin = attacker.position;
        var attackDirection = attacker.forward;

        Debug.DrawRay(attackOrigin, attackDirection * _range, Color.red, 1f);

        RaycastHit hit;
        if (Physics.Raycast(attackOrigin, attackDirection, out hit, _range))
        {
            if (hit.collider.CompareTag("Enemigo"))
            {
                Debug.Log("¡Golpe melee ACERTADO!");
               
            }
        }
    }
}