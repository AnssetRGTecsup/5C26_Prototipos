using System;
using UnityEngine;

namespace Assets.Scripts.MouseControls
{
    [CreateAssetMenu(fileName = "Mouse Handler", menuName = "Scriptable Objects/Utils/Mouse Handlers")]
    public class MouseHandler : ScriptableObject
    {
        [field: SerializeField] public Vector3 MousePosition { get;  private set; }
        [SerializeField] private LayerMask interactables;

        public event Action<Vector3> OnMousePosition;
        private Camera _cameraRef;

        public void SetUpCamera(Camera cameraReference)
        {
            _cameraRef = cameraReference;
        }

        public void UpdateMousePosition(Vector2 mouseScreenPosition)
        {
            if(_cameraRef == null)
            {
                _cameraRef = Camera.main;
            }

            Ray ray = _cameraRef.ScreenPointToRay(mouseScreenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                MousePosition = hit.point;

                Debug.DrawRay(ray.origin, ray.direction * MousePosition.magnitude, Color.red);

                OnMousePosition?.Invoke(MousePosition);
            }
        }
    }
}