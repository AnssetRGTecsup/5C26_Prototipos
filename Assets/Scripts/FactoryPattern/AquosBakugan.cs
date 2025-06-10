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

        public void Update()
        {
            //if (PathComplete() == true)
            //{
            //    BakuganAttack bakuganAttack = GetComponent<BakuganAttack>();
            //    IPasiveAttackStrategy strategy = GetComponent<ShieldStrategy>();
            //    bakuganAttack.ChangeStrategy(strategy);
            //    bakuganAttack.Activate();
            //}
            base.Update();
        }
    }
}