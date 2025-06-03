using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class TilinTransport : NavMeshMovement, ITransport
    {
        public void MoveTransport(Vector3 targetPosition)
        {
            agent.SetDestination(targetPosition);

            Debug.Log($"Viajando a {targetPosition} por suelo");
        }

        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            SpawnAtClosestPoint(spawnPosition);

            Debug.Log($"Spawneando en {spawnPosition} modo tierra");
        }
    }
}