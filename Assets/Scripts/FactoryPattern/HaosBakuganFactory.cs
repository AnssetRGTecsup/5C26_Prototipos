using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class HaosBakuganFactory : BakuganAbstractFactory
    {
        [SerializeField] protected HaosBakugan haosBakuganPrefab;

        public override IBakugan GetBakugan()
        {
            return Instantiate(haosBakuganPrefab);
        }
    }
}