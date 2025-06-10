using UnityEngine;
using UnityEngine.AI;

public abstract class MovementStrategy : ScriptableObject
{
    [Header("Visuals")]
    [SerializeField] private Mesh transportMesh;
    [SerializeField] private Material transportMaterial;

    // --- NUEVA SECCIÓN ---
    [Header("Movement Stats")]
    [Tooltip("La velocidad de movimiento del NavMeshAgent al usar esta estrategia.")]
    [SerializeField] protected float agentSpeed = 8f; // 'protected' para que las clases hijas puedan acceder.
    // --- FIN NUEVA SECCIÓN ---

    public Mesh GetMesh() => transportMesh;
    public Material GetMaterial() => transportMaterial;

    public abstract void Move(NavMeshAgent agent, Vector3 targetPosition);

    public abstract string GetStrategyName();
}