using Assets.Scripts.MouseControls;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class ClientExample : MonoBehaviour
    {
        [SerializeField]
        protected TransporterAbstractFactory transporterFactory;//current
        [SerializeField] protected MousePositionHandler mousePositionHandler;

        private List<ITransport> _tranportsList = new List<ITransport>();

        private Vector3 _targetPosition;


        [SerializeField]protected List<TransporterAbstractFactory> transporterAbstractFactories = new List<TransporterAbstractFactory>();
        public void ChangeCurrentFactory(TransporterAbstractFactory newFactory)
        {
            transporterFactory = newFactory;
        }


        public void ChangeFactory(int current )
        {


            /*switch (i)
            {
                case 0:
                    transporterFactory = transporterAbstractFactories[0];
                    return;
                case 1:
                    transporterFactory = transporterAbstractFactories[1];
                    return;
                default:
                    Debug.Log("no hay mas");
                    return;
            }*/


             for( int i = 0 ;  i< current; i++)
             {
                 transporterFactory = transporterAbstractFactories[i];
                Debug.Log("factory n: " + i);
             }
            // transporterFactory = newFactory;
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