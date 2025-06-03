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
        public UnityEvent<Vector2> OnMousePositionUpdate; //
        /// <summary>
        /// Unity Event that raises a void event when it is clicked.
        /// </summary>
        public UnityEvent OnMouseLeftClick; //
        public UnityEvent OnMouseMiddleClick; //
        public UnityEvent OnMouseRightClick; //

        // --- NUEVOS EVENTOS PARA CAMBIO DE FÁBRICA ---
        /// <summary>
        /// Evento para ciclar a la siguiente fábrica disponible.
        /// </summary>
        public UnityEvent OnCycleFactory;
        /// <summary>
        /// Evento para seleccionar la fábrica asociada a la tecla Alpha1 (o la primera).
        /// </summary>
        public UnityEvent OnSelectFactoryAlpha1;
        /// <summary>
        /// Evento para seleccionar la fábrica asociada a la tecla Alpha2 (o la segunda).
        /// </summary>
        public UnityEvent OnSelectFactoryAlpha2;
        // Añade más si necesitas selección directa para más fábricas (Alpha3, etc.)

        private Vector2 _currentPosition; //

        public void UpdateMousePosition(InputAction.CallbackContext context)
        {
            _currentPosition = context.ReadValue<Vector2>(); //
            OnMousePositionUpdate?.Invoke(_currentPosition); //
        }

        public void UpdateMouseLeftClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseLeftClick?.Invoke(); //
            }
        }

        public void UpdateMouseMiddleClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseMiddleClick?.Invoke(); //
            }
        }

        public void UpdateMouseRightClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMouseRightClick?.Invoke(); //
            }
        }

        // --- NUEVOS MÉTODOS INVOCADOS POR INPUT ACTIONS ---
        public void HandleCycleFactoryInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnCycleFactory?.Invoke();
            }
        }

        public void HandleSelectFactoryAlpha1Input(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnSelectFactoryAlpha1?.Invoke();
            }
        }

        public void HandleSelectFactoryAlpha2Input(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnSelectFactoryAlpha2?.Invoke();
            }
        }
        // Añade más manejadores si definiste más acciones (Alpha3, etc.)
    }
}
