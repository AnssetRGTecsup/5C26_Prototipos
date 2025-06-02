using System;
using UnityEngine;

namespace Assets.Scripts.MouseControls
{
    /// <summary>
    /// This Scrptable Object processes and records the Mouse Position from Screen and transform it into World Point coordenates.
    /// </summary>
    [CreateAssetMenu(fileName = "Mouse Position Handler", menuName = "Scriptable Objects/Utils/Mouse Position Handlers")]
    public class MousePositionHandler : ScriptableObject
    {
        /// <summary>
        /// Current Vector 3 Mouse World Position.
        /// </summary>
        [field: SerializeField] public Vector3 MousePosition { get;  private set; }
        /// <summary>
        /// Layer Mask of Layers which will be included on the Raycast
        /// </summary>
        [SerializeField] private LayerMask interactables;
        /// <summary>
        /// Event Action that raises with a Vector3 when the raycasts lands into an interactable object.
        /// </summary>
        public event Action<Vector3> OnMousePosition;

        private Camera _cameraRef;

        /// <summary>
        /// Set up the Camera reference for the Calculation. If the Camera refernce hasn't been asigned it will use Camera.main.
        /// </summary>
        /// <param name="cameraReference">The Camera component to be the new reference.</param>
        public void SetUpCamera(Camera cameraReference)
        {
            _cameraRef = cameraReference;
        }

        /// <summary>
        /// Processes the Vector2 of the mouse position to world cordenates using the Camera actual refernce and raising an Action Vector3 event.
        /// </summary>
        /// <param name="mouseScreenPosition">A Vector 2 of the current Mouse Position on the screen.</param>
        public void UpdateMousePosition(Vector2 mouseScreenPosition)
        {
            if(_cameraRef == null)
            {
                _cameraRef = Camera.main;
            }

            Ray ray = _cameraRef.ScreenPointToRay(mouseScreenPosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance: Mathf.Infinity, layerMask: interactables))
            {
                MousePosition = hit.point;

                Debug.DrawRay(ray.origin, ray.direction * MousePosition.magnitude, Color.red);

                OnMousePosition?.Invoke(MousePosition);
            }
        }
    }
}