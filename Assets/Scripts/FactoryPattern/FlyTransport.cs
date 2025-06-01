using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class FlyTransport : NavMeshMovement, ITransport
    {
        public void MoveTransport(Vector3 targetPosition)
        {
            agent.SetDestination(targetPosition);
        }

        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
        }
    }
}