using UnityEngine;

public class ChangeAttributeStrategy : MonoBehaviour, IPasiveAttackStrategy
{
    [SerializeField] private Attributes changeAttribute;
    public void Activate()
    {
        BakuganAttack bakuganAttack = GetComponent<BakuganAttack>();
        bakuganAttack.BakuganAttribute = changeAttribute;
    }
}
