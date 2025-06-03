using Assets.Scripts.FactoryPattern;
using UnityEngine;

public class RobotDemoController : MonoBehaviour
{
    [SerializeField] private RobotClientExample client;
    [SerializeField] private AerialRobotFactory aerialFactory;
    [SerializeField] private GroundRobotFactory groundFactory;
    [SerializeField] private AquaticRobotFactory aquaticFactory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
            client.ChangeFactory(aerialFactory);

        if (Input.GetKeyDown(KeyCode.E))
            client.ChangeFactory(groundFactory);

        if (Input.GetKeyDown(KeyCode.T))
            client.ChangeFactory(aquaticFactory);

        if (Input.GetKeyDown(KeyCode.Space))
            client.CreateRobot();

        if (Input.GetKeyDown(KeyCode.C))
            client.CommandRobots();
    }
}
