using UnityEngine;

namespace Assets.Scripts.MouseControls
{
    public class TestMouseTrack : MonoBehaviour
    {
        [SerializeField] private MousePositionHandler mouseHandler;
        [SerializeField] private Camera reference;

        private void Awake()
        {
            mouseHandler.SetUpCamera(reference);
        }

        private void OnEnable()
        {
            mouseHandler.OnMousePosition += MoveObject;
        }

        private void OnDisable()
        {
            mouseHandler.OnMousePosition -= MoveObject;
        }

        private void MoveObject(Vector3 position)
        {
            transform.position = position;
        }
    }
}