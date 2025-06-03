using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class DigimonTransportFactory : TransporterAbstractFactory
    {
        [SerializeField] protected DigimonTransport DigimonTransportPrefab;

        public override ITransport GetTransport()
        {
            return Instantiate(DigimonTransportPrefab);
        }
        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            SpawnAtClosestPoint(spawnPosition);
        }

    }
}