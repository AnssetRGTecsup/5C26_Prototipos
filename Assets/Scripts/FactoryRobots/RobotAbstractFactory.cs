using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.FactoryPattern
{
    public abstract class RobotAbstractFactory : MonoBehaviour
    {
        public abstract IRobot CreateRobot();
    }

    public interface IRobot
    {
        void Spawn(Vector3 position);
        void MoveTo(Vector3 destination);
        void PerformAction();
    }

    public abstract class RobotBase : MonoBehaviour, IRobot
    {
        [SerializeField] protected NavMeshAgent agent;

        protected void SpawnAtClosestPoint(Vector3 spawnPosition)
        {
            NavMeshHit closestHit;
            if (NavMesh.SamplePosition(spawnPosition, out closestHit, 500, NavMesh.AllAreas))
            {
                transform.position = closestHit.position;
                agent.Warp(closestHit.position); 
            }
        }

        public abstract void Spawn(Vector3 position);
        public abstract void MoveTo(Vector3 destination);
        public abstract void PerformAction();
    }
}