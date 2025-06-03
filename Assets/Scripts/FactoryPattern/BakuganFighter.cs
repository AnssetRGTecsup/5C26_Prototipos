using Assets.Scripts.MouseControls;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class BakuganFighter : MonoBehaviour
    {
        [SerializeField] protected BakuganAbstractFactory bakuganFactory;
        [SerializeField] protected MousePositionHandler mousePositionHandler;

        private List<IBakugan> bakugansList = new List<IBakugan>();

        private Vector3 targetPosition;

        public void ChangeCurrentFactory(BakuganAbstractFactory newFactory)
        {
            bakuganFactory = newFactory;
        }

        public void CreateNewBakugan()
        {
            IBakugan newTransport = bakuganFactory.GetBakugan();

            newTransport.SetSpawnPosition(mousePositionHandler.MousePosition);

            bakugansList.Add(newTransport);
        }

        public void SetTargetPoition()
        {
            targetPosition = mousePositionHandler.MousePosition;
        }

        public void LaunchBakugans()
        {
            foreach (IBakugan transport in bakugansList)
            {
                transport.LaunchBakugan(targetPosition);
            }
        }
    }

}