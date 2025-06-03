using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class GroundRobotFactory : RobotAbstractFactory
    {
        [SerializeField] private GroundRobot groundRobotPrefab;

        public override IRobot CreateRobot()
        {
            return Instantiate(groundRobotPrefab);
        }
    }
}