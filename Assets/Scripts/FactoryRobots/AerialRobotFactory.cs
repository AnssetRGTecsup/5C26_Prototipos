using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class AerialRobotFactory : RobotAbstractFactory
    {
        [SerializeField] private AerialRobot aerialRobotPrefab;

        public override IRobot CreateRobot()
        {
            return Instantiate(aerialRobotPrefab);
        }
    }
}