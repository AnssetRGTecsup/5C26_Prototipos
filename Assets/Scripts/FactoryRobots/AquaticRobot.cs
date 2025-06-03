using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class AquaticRobot : RobotBase
    {
        public override void Spawn(Vector3 position)
        {
            
            Vector3 waterPosition = new Vector3(position.x, 0f, position.z);
            SpawnAtClosestPoint(waterPosition);

   
            agent.speed = 2.5f;
            agent.avoidancePriority = 30;

            Debug.Log($"Robot acuático desplegado en {waterPosition} (nivel del agua)");
        }

        public override void MoveTo(Vector3 destination)
        {
            Vector3 waterDestination = new Vector3(destination.x, 0f, destination.z);
            agent.SetDestination(waterDestination);
            Debug.Log($"Robot acuático navegando hacia {waterDestination}");
        }

        public override void PerformAction()
        {
            Debug.Log("Robot acuático: Sonar activado!");
          
        }
    }
}