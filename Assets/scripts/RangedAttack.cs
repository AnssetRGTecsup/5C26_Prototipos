using UnityEngine;

public class RangedAttack : IAttackStrategy
{
    private float _range = 20f; 
    private float _damage = 5f;

    public void Attack(Transform attacker)
    {
        Debug.Log("Ejecutando ataque RANGED");
        var attackOrigin = attacker.position;
        var attackDirection = attacker.forward;

        Debug.DrawRay(attackOrigin, attackDirection * _range, Color.blue, 1f);

        RaycastHit hit;
        if (Physics.Raycast(attackOrigin, attackDirection, out hit, _range))
        {
            if (hit.collider.CompareTag("Enemigo"))
            {
                Debug.Log("¡Disparo a distancia ACERTADO!");
                
            }
        }
    }
}