using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class FlyTransportFactory : TransporterAbstractFactory
    {
        [SerializeField] protected FlyTransport flyingTransportPrefab;

        public override ITransport GetTransport()
        {
            return Instantiate(flyingTransportPrefab);
        }
        public override string GetFactoryName()
        {
            return "Transporte Aereo";
        }
    }
}