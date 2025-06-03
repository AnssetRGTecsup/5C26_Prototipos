// ClientExample.cs
using Assets.Scripts.MouseControls;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening; // Asegúrate de tener este using si lo usas

namespace Assets.Scripts.FactoryPattern
{
    public class ClientExample : MonoBehaviour
    {
        [SerializeField] private List<TransporterAbstractFactory> availableFactories;
        [SerializeField] private TextMeshProUGUI currentFactoryUI;
        [SerializeField] protected MousePositionHandler mousePositionHandler; //

        // --- AÑADE UNA REFERENCIA A TU INPUTHANDLER ---
        [SerializeField] private InputHandler inputHandler;

        private TransporterAbstractFactory _currentFactory;
        private int _currentFactoryIndex = 0;

        private List<ITransport> _tranportsList = new List<ITransport>(); //
        private Vector3 _targetPosition; //

        private void Awake()
        {
            // Es buena práctica verificar la referencia al InputHandler
            if (inputHandler == null)
            {
                Debug.LogError("InputHandler no asignado en ClientExample. Buscando...");
                inputHandler = FindObjectOfType<InputHandler>(); // Intenta encontrarlo
                if (inputHandler == null)
                {
                    Debug.LogError("InputHandler no encontrado en la escena. El cambio de fábrica por teclas no funcionará.");
                    // Considera desactivar el script o esta funcionalidad si es crítico
                }
            }
        }

        private void Start()
        {
            if (availableFactories == null || availableFactories.Count == 0)
            {
                Debug.LogError("No hay fábricas asignadas en ClientExample.");
                enabled = false;
                return;
            }
            // Inicializa con la primera fábrica
            _currentFactoryIndex = 0;
            ChangeCurrentFactory(availableFactories[_currentFactoryIndex]);
        }

        private void OnEnable()
        {
            // Suscribirse a los eventos del InputHandler usando AddListener
            if (inputHandler != null)
            {
                // Antes: inputHandler.OnCycleFactory += HandleCycleFactoryEvent;
                inputHandler.OnCycleFactory.AddListener(HandleCycleFactoryEvent);

                // Antes: inputHandler.OnSelectFactoryAlpha1 += HandleSelectFactory1Event;
                inputHandler.OnSelectFactoryAlpha1.AddListener(HandleSelectFactory1Event);

                // Antes: inputHandler.OnSelectFactoryAlpha2 += HandleSelectFactory2Event;
                inputHandler.OnSelectFactoryAlpha2.AddListener(HandleSelectFactory2Event);
                // Suscríbete a más eventos si los tienes (Alpha3, etc.) de la misma manera
            }
        }

        private void OnDisable()
        {
            // Desuscribirse para evitar errores usando RemoveListener
            if (inputHandler != null)
            {
                // Antes: inputHandler.OnCycleFactory -= HandleCycleFactoryEvent;
                inputHandler.OnCycleFactory.RemoveListener(HandleCycleFactoryEvent);

                // Antes: inputHandler.OnSelectFactoryAlpha1 -= HandleSelectFactory1Event;
                inputHandler.OnSelectFactoryAlpha1.RemoveListener(HandleSelectFactory1Event);

                // Antes: inputHandler.OnSelectFactoryAlpha2 -= HandleSelectFactory2Event;
                inputHandler.OnSelectFactoryAlpha2.RemoveListener(HandleSelectFactory2Event);
                // Desuscríbete de más eventos si los tienes de la misma manera
            }
        }

        // El método Update ya NO necesita Input.GetKeyDown para cambiar fábricas
        // private void Update() { ... } // Puedes eliminar el contenido de Update si solo era para esto

        // --- MÉTODOS MANEJADORES PARA LOS EVENTOS DEL INPUTHANDLER ---
        private void HandleCycleFactoryEvent()
        {
            if (availableFactories == null || availableFactories.Count == 0) return;
            _currentFactoryIndex = (_currentFactoryIndex + 1) % availableFactories.Count;
            ChangeCurrentFactory(availableFactories[_currentFactoryIndex]);
        }

        private void HandleSelectFactory1Event()
        {
            if (availableFactories != null && availableFactories.Count > 0)
            {
                _currentFactoryIndex = 0;
                ChangeCurrentFactory(availableFactories[_currentFactoryIndex]);
            }
        }

        private void HandleSelectFactory2Event()
        {
            if (availableFactories != null && availableFactories.Count > 1)
            {
                _currentFactoryIndex = 1;
                ChangeCurrentFactory(availableFactories[_currentFactoryIndex]);
            }
        }
        // Añade más manejadores si es necesario (SelectFactory3, etc.)

        public void ChangeCurrentFactory(TransporterAbstractFactory newFactory) //
        {
            _currentFactory = newFactory;
            if (currentFactoryUI != null && _currentFactory != null)
            {
                currentFactoryUI.text = $"Agente: {_currentFactory.GetFactoryName()}";
            }
            Debug.Log($"Fábrica cambiada a: {_currentFactory.GetFactoryName()}");
        }

        public void CreateNewTranport() //
        {
            if (_currentFactory == null)
            {
                Debug.LogError("No hay una fábrica seleccionada para crear el transporte.");
                return;
            }

            ITransport newTransport = _currentFactory.GetTransport(); //
            MonoBehaviour transportMonoBehaviour = newTransport as MonoBehaviour;

            if (transportMonoBehaviour == null)
            {
                Debug.LogError("El transporte creado no es un MonoBehaviour, no se puede acceder al GameObject para efectos.");
                _tranportsList.Add(newTransport); //
                return;
            }

            newTransport.SetSpawnPosition(mousePositionHandler.MousePosition); //

            GameObject transportGO = transportMonoBehaviour.gameObject;
            transportGO.transform.localScale = Vector3.zero;
            transportGO.transform.DOScale(170f, 0.5f).SetEase(Ease.OutBack);

            _tranportsList.Add(newTransport); //
        }

        public void SetTargetPoition() //
        {
            _targetPosition = mousePositionHandler.MousePosition; //
        }

        public void RunTransports() //
        {
            foreach (ITransport transport in _tranportsList) //
            {
                transport.MoveTransport(_targetPosition); //
            }
        }
    }
}