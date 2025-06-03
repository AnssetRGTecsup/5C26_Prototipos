using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class TilinTransportFactory : TransporterAbstractFactory
    {
        [SerializeField] protected TilinTransport tilinTransportPrefab;
        public override ITransport GetTransport()
        {
            return Instantiate(tilinTransportPrefab);
        }
    }
}