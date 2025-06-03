using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.FactoryPattern
{
    public abstract class BakuganAbstractFactory : MonoBehaviour
    {
        public abstract IBakugan GetBakugan();
    }

    public interface IBakugan
    {
        public void SetSpawnPosition(Vector3 spawnPosition);

        public void LaunchBakugan(Vector3 targetPosition);
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