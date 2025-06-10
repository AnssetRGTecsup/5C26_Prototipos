using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Fly Movement", menuName = "Strategies/Fly Movement")]
public class FlyMovementStrategy : MovementStrategy
{
    public override void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        agent.enabled = false;

        // --- LÓGICA MODIFICADA ---
        float distance = Vector3.Distance(agent.transform.position, targetPosition);
        // Evitamos división por cero si la velocidad o la distancia son muy pequeñas.
        if (agentSpeed <= 0 || distance < 0.1f) return;

        // Duración = Distancia / Velocidad. A más velocidad, menor duración.
        float duration = distance / agentSpeed;

        agent.transform.DOMove(targetPosition, duration).SetEase(Ease.InOutQuad);
        // --- FIN DE LÓGICA MODIFICADA ---

        Debug.Log($"Viajando a {targetPosition} por AIRE a velocidad {agentSpeed}.");
    }

    public override string GetStrategyName() => "Estrategia Aérea";
}