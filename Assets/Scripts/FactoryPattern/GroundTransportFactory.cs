using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class GroundTransportFactory : TransporterAbstractFactory
    {
        [SerializeField] protected GroundTransport groundTransportPrefab;
        public override ITransport GetTransport()
        {
            return Instantiate(groundTransportPrefab);
        }

        public override string GetFactoryName()
        {
            return "Transporte Terrestre";
        }
    }
}