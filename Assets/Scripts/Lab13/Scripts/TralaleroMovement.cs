using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Tralalero Movement", menuName = "Strategies/Tralalero Movement")]
public class TralaleroMovementStrategy : MovementStrategy
{
    public override void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        agent.enabled = true;
        agent.speed = agentSpeed; // <-- LÍNEA AÑADIDA
        agent.SetDestination(targetPosition);
        agent.transform.DOShakePosition(1.5f, strength: 5, vibrato: 10);
        Debug.Log($"Viajando a {targetPosition} a lo TRALALA a velocidad {agentSpeed}.");
    }
    public override string GetStrategyName() => "Estrategia Tralalero";
}