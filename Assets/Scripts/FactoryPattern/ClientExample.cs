using Assets.Scripts.MouseControls;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.FactoryPattern
{
    public class ClientExample : MonoBehaviour
    {
        [SerializeField] private List<TransporterAbstractFactory> availableFactories;
        [SerializeField] private TextMeshProUGUI currentFactoryUI; // Asigna tu elemento UI de TextMeshPro
        [SerializeField] protected MousePositionHandler mousePositionHandler;

        private TransporterAbstractFactory _currentFactory;
        private int _currentFactoryIndex = 0;

        private List<ITransport> _tranportsList = new List<ITransport>();
        private Vector3 _targetPosition;

        private void Start()
        {
            if (availableFactories == null || availableFactories.Count == 0)
            {
                Debug.LogError("No hay fábricas asignadas en ClientExample.");
                enabled = false; // Desactiva el script si no hay fábricas
                return;
            }
            ChangeCurrentFactory(availableFactories[_currentFactoryIndex]);
        }

        private void Update()
        {
            // Cambiar de fábrica con teclas numéricas (Alpha1, Alpha2, ...)
            // Puedes adaptar esto al InputHandler si prefieres
            //if (Input.GetKeyDown(KeyCode.Alpha1) && availableFactories.Count > 0)
            //{
            //    ChangeCurrentFactory(availableFactories[0]);
            //    _currentFactoryIndex = 0;
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha2) && availableFactories.Count > 1)
            //{
            //    ChangeCurrentFactory(availableFactories[1]);
            //    _currentFactoryIndex = 1;
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha3) && availableFactories.Count > 2)
            //{
            //    ChangeCurrentFactory(availableFactories[2]);
            //    _currentFactoryIndex = 2;
            //}
            //// Añade más 'else if' si tienes más fábricas

            //// Alternativamente, para ciclar entre fábricas:
            //if (Input.GetKeyDown(KeyCode.Tab)) // Por ejemplo, con Tab
            //{
            //    _currentFactoryIndex = (_currentFactoryIndex + 1) % availableFactories.Count;
            //    ChangeCurrentFactory(availableFactories[_currentFactoryIndex]);
            //}
        }

        public void ChangeCurrentFactory(TransporterAbstractFactory newFactory)
        {
            _currentFactory = newFactory;
            if (currentFactoryUI != null && _currentFactory != null)
            {
                currentFactoryUI.text = $"Agente: {_currentFactory.GetFactoryName()}";
            }
            Debug.Log($"Fábrica cambiada a: {_currentFactory.GetFactoryName()}");
        }

        public void CreateNewTranport()
        {
            if (_currentFactory == null)
            {
                Debug.LogError("No hay una fábrica seleccionada para crear el transporte.");
                return;
            }

            ITransport newTransport = _currentFactory.GetTransport();
            MonoBehaviour transportMonoBehaviour = newTransport as MonoBehaviour;

            if (transportMonoBehaviour == null)
            {
                Debug.LogError("El transporte creado no es un MonoBehaviour, no se puede acceder al GameObject para efectos.");
                // Considera añadir el objeto a la lista igualmente si no depende de ser un MBH
                // _tranportsList.Add(newTransport);
                return;
            }

            newTransport.SetSpawnPosition(mousePositionHandler.MousePosition); //

            // --- Aquí iría la lógica de DOTween (ver sección 3) ---

            _tranportsList.Add(newTransport);
        }

        public void SetTargetPoition()
        {
            _targetPosition = mousePositionHandler.MousePosition;
        }

        public void RunTransports()
        {
            foreach (ITransport transport in _tranportsList)
            {
                transport.MoveTransport(_targetPosition);
            }
        }
    }
}