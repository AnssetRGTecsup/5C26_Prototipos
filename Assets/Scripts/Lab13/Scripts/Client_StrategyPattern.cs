using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.MouseControls; // Aseg�rate que el namespace de tus handlers es correcto
using DG.Tweening; // Aseg�rate de tener DOTween en tu proyecto

public class Client_StrategyPattern : MonoBehaviour
{
    [Header("Strategy Setup")]
    [Tooltip("Arrastra aqu� los assets de MovementStrategy que creaste.")]
    [SerializeField] private List<MovementStrategy> availableStrategies;
    [Tooltip("Arrastra aqu� el Prefab de tu UniversalTransporter.")]
    [SerializeField] private UniversalTransporter transporterPrefab;

    [Header("UI & Input")]
    [SerializeField] private TextMeshProUGUI currentStrategyUI;
    [SerializeField] protected MousePositionHandler mousePositionHandler;
    [SerializeField] private InputHandler inputHandler;

    private MovementStrategy _currentStrategy;
    private int _currentStrategyIndex = 0;

    private readonly List<UniversalTransporter> _transportersList = new List<UniversalTransporter>();
    private Vector3 _targetPosition;

    private void Awake()
    {
        if (inputHandler == null)
        {
            if (inputHandler == null)
            {
                Debug.LogError("InputHandler no encontrado. Los controles por teclado no funcionar�n.");
            }
        }
    }

    private void Start()
    {
        if (availableStrategies == null || availableStrategies.Count == 0)
        {
            Debug.LogError("No hay estrategias de movimiento asignadas en la lista 'availableStrategies'.");
            enabled = false;
            return;
        }
        if (transporterPrefab == null)
        {
            Debug.LogError("El prefab del transportador no est� asignado.");
            enabled = false;
            return;
        }

        // Inicializa con la primera estrategia de la lista
        _currentStrategyIndex = 0;
        ChangeCurrentStrategy(availableStrategies[_currentStrategyIndex]);
    }

    private void OnEnable()
    {
        if (inputHandler != null)
        {
            // Suscripci�n a eventos para crear, mover y cambiar de estrategia
            inputHandler.OnMouseLeftClick.AddListener(CreateNewTransporter);
            inputHandler.OnMouseRightClick.AddListener(SetTargetAndRunTransporters);

            inputHandler.OnCycleFactory.AddListener(HandleCycleStrategyEvent);
            inputHandler.OnSelectFactoryAlpha1.AddListener(HandleSelectStrategy1Event);
            inputHandler.OnSelectFactoryAlpha2.AddListener(HandleSelectStrategy2Event);
        }
    }

    private void OnDisable()
    {
        if (inputHandler != null)
        {
            // Siempre es buena pr�ctica desuscribirse para evitar memory leaks
            inputHandler.OnMouseLeftClick.RemoveListener(CreateNewTransporter);
            inputHandler.OnMouseRightClick.RemoveListener(SetTargetAndRunTransporters);

            inputHandler.OnCycleFactory.RemoveListener(HandleCycleStrategyEvent);
            inputHandler.OnSelectFactoryAlpha1.RemoveListener(HandleSelectStrategy1Event);
            inputHandler.OnSelectFactoryAlpha2.RemoveListener(HandleSelectStrategy2Event);
        }
    }

    public void ChangeCurrentStrategy(MovementStrategy newStrategy)
    {
        _currentStrategy = newStrategy;
        if (currentStrategyUI != null && _currentStrategy != null)
        {
            currentStrategyUI.text = $"Estrategia: {_currentStrategy.GetStrategyName()}";
        }

        // Opcional: Aplicar la nueva estrategia a todos los agentes ya creados
        foreach (var transporter in _transportersList)
        {
            transporter.SetStrategy(_currentStrategy);
        }

        Debug.Log($"Estrategia global cambiada a: {_currentStrategy.GetStrategyName()}");
    }

    public void CreateNewTransporter()
    {
        if (transporterPrefab == null || _currentStrategy == null) return;

        UniversalTransporter newTransporter = Instantiate(transporterPrefab);
        newTransporter.SetSpawnPosition(mousePositionHandler.MousePosition);
        newTransporter.SetStrategy(_currentStrategy);

        newTransporter.transform.localScale = Vector3.zero;
        newTransporter.transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBack);

        _transportersList.Add(newTransporter);
    }

    public void SetTargetAndRunTransporters()
    {
        _targetPosition = mousePositionHandler.MousePosition;
        foreach (UniversalTransporter transport in _transportersList)
        {
            transport.ExecuteMove(_targetPosition);
        }
    }

    // --- M�TODOS MANEJADORES DE INPUT ---

    private void HandleCycleStrategyEvent()
    {
        if (availableStrategies.Count == 0) return;
        _currentStrategyIndex = (_currentStrategyIndex + 1) % availableStrategies.Count;
        ChangeCurrentStrategy(availableStrategies[_currentStrategyIndex]);
    }

    private void HandleSelectStrategy1Event()
    {
        if (availableStrategies.Count > 0)
        {
            _currentStrategyIndex = 0;
            ChangeCurrentStrategy(availableStrategies[_currentStrategyIndex]);
        }
    }

    private void HandleSelectStrategy2Event()
    {
        if (availableStrategies.Count > 1)
        {
            _currentStrategyIndex = 1;
            ChangeCurrentStrategy(availableStrategies[_currentStrategyIndex]);
        }
    }
    // A�ade m�s manejadores si tienes m�s teclas (Alpha3, etc.)
}