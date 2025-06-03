using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class AerialRobot : RobotBase
    {
        public override void Spawn(Vector3 position)
        {
         
            Vector3 aerialPosition = new Vector3(position.x, position.y + 5f, position.z);
            SpawnAtClosestPoint(aerialPosition);

            
            agent.baseOffset = 5f; 
            agent.avoidancePriority = 50;

            Debug.Log($"Robot aéreo desplegado en {position} (volando a 5m de altura)");
        }

        public override void MoveTo(Vector3 destination)
        {
            Vector3 aerialDestination = new Vector3(destination.x, destination.y + 5f, destination.z);
            agent.SetDestination(aerialDestination);
            Debug.Log($"Robot aéreo volando hacia {aerialDestination}");
        }

        public override void PerformAction()
        {
            Debug.Log("Robot aéreo: Escaneo aéreo activado!");
      
        }
    }
}