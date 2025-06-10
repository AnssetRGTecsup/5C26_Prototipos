using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(MeshFilter), typeof(MeshRenderer))]
public class UniversalTransporter : MonoBehaviour
{
    private NavMeshAgent _agent;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private MovementStrategy _currentStrategy;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetStrategy(MovementStrategy newStrategy)
    {
        _currentStrategy = newStrategy;

        _meshFilter.mesh = _currentStrategy.GetMesh();
        _meshRenderer.material = _currentStrategy.GetMaterial();

        Debug.Log($"Estrategia cambiada a: {_currentStrategy.GetStrategyName()}");
    }

    public void ExecuteMove(Vector3 targetPosition)
    {
        if (_currentStrategy == null)
        {
            Debug.LogError("No hay una estrategia asignada para mover el transportador.");
            return;
        }

        // Delegamos la ejecución del movimiento a la estrategia actual
        _currentStrategy.Move(_agent, targetPosition);
    }

    public void SetSpawnPosition(Vector3 spawnPosition)
    {
        NavMeshHit closestHit;
        if (NavMesh.SamplePosition(spawnPosition, out closestHit, 500, 1))
        {
            transform.position = closestHit.position;
            _agent.Warp(closestHit.position); // Asegura que el agent se teletransporte correctamente
        }
    }
}