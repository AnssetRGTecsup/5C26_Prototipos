using Assets.Scripts.MouseControls;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class ExampleNavMesh : NavMeshMovement
    {
        [SerializeField] private MousePositionHandler mouseHandler;
        [SerializeField] private Vector3 currentPosition;

        private void Start()
        {
            SpawnAtClosestPoint(transform.position);
        }
        private void OnEnable()
        {
            mouseHandler.OnMousePosition += SetUpTargetPosition;
        }

        private void OnDisable()
        {
            mouseHandler.OnMousePosition -= SetUpTargetPosition;
        }

        private void SetUpTargetPosition(Vector3 newPosition)
        {
            currentPosition = newPosition;
        }

        public void MoveTransport()
        {
            Vector3 targetPosition = currentPosition;
            agent.SetDestination(targetPosition);
        }
    }
}