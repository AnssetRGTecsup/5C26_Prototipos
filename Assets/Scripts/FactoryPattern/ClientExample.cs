using Assets.Scripts.MouseControls;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class ClientExample : MonoBehaviour
    {
        [SerializeField] protected TransporterAbstractFactory transporterFactory;
        [SerializeField] protected MousePositionHandler mousePositionHandler;

        private List<ITransport> _tranportsList = new List<ITransport>();

        private Vector3 _targetPosition;

        public void ChangeCurrentFactory(TransporterAbstractFactory newFactory)
        {
            transporterFactory = newFactory;
        }

        public void CreateNewTranport()
        {
            ITransport newTransport = transporterFactory.GetTransport();

            newTransport.SetSpawnPosition(mousePositionHandler.MousePosition);

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