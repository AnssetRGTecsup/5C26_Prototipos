using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

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
        [SerializeField] public GameObject strategy;

        [Header("Events")]
        public UnityEvent<IPasiveAttackStrategy> onDestinationReached;

        private bool hasReachedDestination = false;

        protected virtual void Update()
        {
            if (!hasReachedDestination && PathComplete())
            {
                hasReachedDestination = true;
                onDestinationReached?.Invoke(strategy.GetComponent<IPasiveAttackStrategy>());
            }

            if (agent.hasPath && !agent.pathPending && agent.remainingDistance > agent.stoppingDistance)
            {
                hasReachedDestination = false;
            }
        }

        protected void SpawnAtClosestPoint(Vector3 spawnPosition)
        {
            NavMeshHit closestHit;
            if (NavMesh.SamplePosition(spawnPosition, out closestHit, 500, NavMesh.AllAreas))
            {
                transform.position = closestHit.position;
            }
        }

        public bool PathComplete()
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}