using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.MouseControls
{
    public class InputHandler : MonoBehaviour
    {
        public UnityEvent<Vector2> OnMousePositionUpdate;
        public UnityEvent OnMouseClickUpdate;

        private Vector2 _currentPosition;

        public void UpdateMousePosition(InputAction.CallbackContext context)
        {
            _currentPosition = context.ReadValue<Vector2>();

            OnMousePositionUpdate?.Invoke(_currentPosition);
        }

        public void UpdateMouseClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseClickUpdate?.Invoke();
            }
        }
    }
}
