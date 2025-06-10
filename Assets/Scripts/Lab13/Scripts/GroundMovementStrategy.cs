using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Ground Movement", menuName = "Strategies/Ground Movement")]
public class GroundMovementStrategy : MovementStrategy
{
    public override void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        agent.enabled = true;
        agent.speed = agentSpeed; // <-- LÍNEA AÑADIDA
        agent.SetDestination(targetPosition);
        Debug.Log($"Viajando a {targetPosition} por TIERRA a velocidad {agentSpeed}.");
    }

    public override string GetStrategyName() => "Estrategia Terrestre";
}