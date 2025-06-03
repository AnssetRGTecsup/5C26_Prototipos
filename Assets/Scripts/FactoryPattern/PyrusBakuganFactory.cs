using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class PyrusBakuganFactory : BakuganAbstractFactory
    {
        [SerializeField] protected PyrusBakugan pyrusBakuganPrefab;
        public override IBakugan GetBakugan()
        {
            return Instantiate(pyrusBakuganPrefab);
        }
    }
}