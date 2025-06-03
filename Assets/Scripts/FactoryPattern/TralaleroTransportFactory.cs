using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class TralaleroTransportFactory : TransporterAbstractFactory
    {
        [SerializeField] protected TralaleroTransport tralaleroTransportPrefab;

        public override ITransport GetTransport()
        {
            return Instantiate(tralaleroTransportPrefab);
        }
        public override string GetFactoryName()
        {
            return "Transporte Tralalero";
        }
    }
}