using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class AquaticRobotFactory : RobotAbstractFactory
    {
        [SerializeField] private AquaticRobot aquaticRobotPrefab;

        public override IRobot CreateRobot()
        {
            return Instantiate(aquaticRobotPrefab);
        }
    }
}