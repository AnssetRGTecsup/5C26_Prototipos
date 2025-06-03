using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class AquosBakugan : NavMeshMovement, IBakugan
    {
        public void LaunchBakugan(Vector3 targetPosition)
        {
            agent.SetDestination(targetPosition);

            Debug.Log($"Bakugan lanzado a la posicion{targetPosition}");
        }

        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            SpawnAtClosestPoint(spawnPosition);

            Debug.Log($"Aquos Bakugan spawneado en la posicion {spawnPosition}.");
        }
    }
}