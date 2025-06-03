using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class GroundRobot : RobotBase
    {
        public override void Spawn(Vector3 position)
        {
            SpawnAtClosestPoint(position);

            agent.speed = 3.5f;
            agent.avoidancePriority = 70;

            Debug.Log($"Robot terrestre desplegado en {position}");
        }

        public override void MoveTo(Vector3 destination)
        {
            agent.SetDestination(destination);
            Debug.Log($"Robot terrestre avanzando hacia {destination}");
        }

        public override void PerformAction()
        {
            Debug.Log("Robot terrestre: Modo de carga activado!");
          
        }
    }
}