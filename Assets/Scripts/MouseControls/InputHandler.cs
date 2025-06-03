using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.MouseControls
{
    /// <summary>
    /// This Class uses the New Input System to obtain the Mouse Position on the screen and the Click event.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        /// <summary>
        /// Unity Event that raises a Vector2 with the Current Position of the Mouse on the screen.
        /// </summary>
        public UnityEvent<Vector2> OnMousePositionUpdate;
        /// <summary>
        /// Unity Event that raises a void event when it is clicked.
        /// </summary>
        public UnityEvent OnMouseLeftClick;
        public UnityEvent OnMouseMiddleClick;
        public UnityEvent OnMouseRightClick;
        public UnityEvent <int> OnKeyPressed;
        private Vector2 _currentPosition;
        int position = 0;
        public void UpdateMousePosition(InputAction.CallbackContext context)
        {
            _currentPosition = context.ReadValue<Vector2>();

            OnMousePositionUpdate?.Invoke(_currentPosition);
        }

        public void UpdateMouseLeftClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseLeftClick?.Invoke();
            }
        }

        public void UpdateMouseMiddleClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseMiddleClick?.Invoke();
            }
        }

        public void UpdateMouseRightClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseRightClick?.Invoke();
            }
        }
        public void ChangeFactoryType(InputAction.CallbackContext context)
        {
           
            if (context.performed)
            {
                
                
                   
                    OnKeyPressed?.Invoke(position);

                position++;


                // Debug.Log(i);
            }
           
        }

    }
}
