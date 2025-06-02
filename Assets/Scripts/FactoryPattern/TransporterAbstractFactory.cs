using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.FactoryPattern
{
    public abstract class TransporterAbstractFactory : MonoBehaviour
    {
        public abstract ITransport GetTransport();
    }

    public interface ITransport
    {
        public void SetSpawnPosition(Vector3 spawnPosition);

        public void MoveTransport(Vector3 targetPosition);
    }

    public abstract class NavMeshMovement : MonoBehaviour
    {
        [SerializeField] protected NavMeshAgent agent;

        protected void SpawnAtClosestPoint(Vector3 spawnPosition)
        {
            NavMeshHit closestHit;
            if (NavMesh.SamplePosition(spawnPosition, out closestHit, 500, 1))
            {
                transform.position = closestHit.position;
            }
        }
    }

}