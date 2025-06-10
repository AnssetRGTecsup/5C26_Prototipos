using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Fly Movement", menuName = "Strategies/Fly Movement")]
public class FlyMovementStrategy : MovementStrategy
{
    public override void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        agent.enabled = false;

        // --- L�GICA MODIFICADA ---
        float distance = Vector3.Distance(agent.transform.position, targetPosition);
        // Evitamos divisi�n por cero si la velocidad o la distancia son muy peque�as.
        if (agentSpeed <= 0 || distance < 0.1f) return;

        // Duraci�n = Distancia / Velocidad. A m�s velocidad, menor duraci�n.
        float duration = distance / agentSpeed;

        agent.transform.DOMove(targetPosition, duration).SetEase(Ease.InOutQuad);
        // --- FIN DE L�GICA MODIFICADA ---

        Debug.Log($"Viajando a {targetPosition} por AIRE a velocidad {agentSpeed}.");
    }

    public override string GetStrategyName() => "Estrategia A�rea";
}