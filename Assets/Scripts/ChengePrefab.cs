using Assets.Scripts.FactoryPattern;
using UnityEngine;
using System.Collections.Generic;
public class ChangePrefab : MonoBehaviour
{
    [SerializeField] private TransporterAbstractFactory factory;
    [SerializeField] private List<GroundTransport> prefabOptions;
    [SerializeField] private int currentPrefabIndex = 0;

    private void Awake()
    {
        factory = GetComponent<TransporterAbstractFactory>();
    }

    public void ChangePerson()
    {   
        currentPrefabIndex = (currentPrefabIndex + 1) % prefabOptions.Count;
        
        if (factory is GroundTransportFactory groundFactory)
        {
            groundFactory.SetPrefab(prefabOptions[currentPrefabIndex]);
        }
    }
}
