using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class RobotClientExample : MonoBehaviour
    {
        [SerializeField] private RobotAbstractFactory robotFactory;
        [SerializeField] private List<IRobot> robots = new List<IRobot>();

        public void ChangeFactory(RobotAbstractFactory newFactory)
        {
            robotFactory = newFactory;
            Debug.Log("Fábrica cambiada a: " + newFactory.GetType().Name);
        }

        public void CreateRobot()
        {
            Vector3 spawnPosition = Random.insideUnitSphere * 5f;
            IRobot newRobot = robotFactory.CreateRobot();
            newRobot.Spawn(spawnPosition);
            robots.Add(newRobot);
        }

        public void CommandRobots()
        {
            Vector3 target = Random.insideUnitSphere * 10f;
            foreach (IRobot robot in robots)
            {
                robot.MoveTo(target);
                robot.PerformAction();
            }
        }
    }
}