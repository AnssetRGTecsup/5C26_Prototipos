using TMPro;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class DigimonTransport : NavMeshMovement, ITransport
    {
        private ITransport currentTransport;
        private GameObject currentTransportGO;
        public void EvolutionTransformation(Vector3 newTransportPrefab)
        {

            SpawnAtClosestPoint(newTransportPrefab);
            Debug.Log($"Digimon aaa {newTransportPrefab} Agunimon");
            Vector3 currentPos = currentTransportGO.transform.position;

            LeanTween.rotateY(currentTransportGO, 360f, 0.5f).setOnComplete(() =>
            {
                Destroy(currentTransportGO);

                GameObject evolvedGO = Instantiate(((MonoBehaviour)newTransportPrefab).gameObject, currentPos, Quaternion.identity);
                ITransport evolvedTransport = evolvedGO.GetComponent<ITransport>();

                SetCurrentTransport(evolvedTransport);

            }
            

        public void MoveTransport(Vector3 targetPosition)
        {
            agent.SetDestination(targetPosition);

            Debug.Log($"evolu a {targetPosition} por aire");
        }

        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            SpawnAtClosestPoint(spawnPosition);

            Debug.Log($"Spawneando en {spawnPosition} modo aire");
        }
    }
}