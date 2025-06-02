using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class FlyTransport : NavMeshMovement, ITransport
    {
        public void MoveTransport(Vector3 targetPosition)
        {
            agent.SetDestination(targetPosition);

            Debug.Log($"Viajando a {targetPosition} por aire");
        }

        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            SpawnAtClosestPoint(spawnPosition);

            Debug.Log($"Spawneando en {spawnPosition} modo aire");
        }
    }
}