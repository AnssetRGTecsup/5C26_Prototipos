using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class GroundTransportFactory : TransporterAbstractFactory
    {
        [SerializeField] public GroundTransport groundTransportPrefab;
        public override ITransport GetTransport()
        {
            return Instantiate(groundTransportPrefab);
        }
        public void SetPrefab(GroundTransport newPrefab)
        {
            groundTransportPrefab = newPrefab;
        }
    }
}