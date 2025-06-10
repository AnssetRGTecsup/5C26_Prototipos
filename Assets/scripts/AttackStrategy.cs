using UnityEngine;


public abstract class AttackStrategy : ScriptableObject, IAttackStrategy
{
    [Header("Datos Comunes del Ataque")]
    public float damage = 10f;

    public abstract void Attack(Transform attacker);
}
