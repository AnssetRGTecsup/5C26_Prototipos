using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.FactoryPattern
{
    public abstract class TransporterAbstractFactory : MonoBehaviour
    {
        public abstract ITransport GetTransport();
    }

    public interface ITransport
    {
        public void SetSpawnPosition(Vector3 spawnPosition);

        public void MoveTransport(Vector3 targetPosition);
    }

    public abstract class NavMeshMovement : MonoBehaviour
    {
        [SerializeField] protected NavMeshAgent agent;
    }

    public class ClientExample : MonoBehaviour
    {
        [SerializeField] protected TransporterAbstractFactory transporterFactory;

        
    }
}