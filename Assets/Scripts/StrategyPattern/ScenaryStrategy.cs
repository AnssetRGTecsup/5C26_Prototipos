using UnityEngine;

public class ScenaryStrategy : MonoBehaviour, IPasiveAttackStrategy
{
    [SerializeField] private Attributes scenaryAttribute;
    [SerializeField] private int extraGPower;
    public void Activate()
    {
        BakuganAttack bakuganAttack = GetComponent<BakuganAttack>();
        if(scenaryAttribute == bakuganAttack.BakuganAttribute)
        {
            bakuganAttack.GPower = bakuganAttack.GPower + extraGPower;
        }
    }
}
