using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class AquosBakuganFactory : BakuganAbstractFactory
    {
        [SerializeField] protected AquosBakugan aquosBakuganPrefab;

        public override IBakugan GetBakugan()
        {
            return Instantiate(aquosBakuganPrefab);
        }
    }
}