using UnityEngine;

public enum Attributes
{
    Pyrus,
    Haos,
    Aquos
}
public class BakuganAttack : MonoBehaviour
{
    [SerializeField] private int gPower;
    [SerializeField] private Attributes bakuganAttribute;
    [SerializeField] private IPasiveAttackStrategy pasiveAttack;
    [SerializeField] private bool isInvulnerable;

    private void OnEnable()
    {
        ScenaryStrategy scenaryStrategy = GetComponent<ScenaryStrategy>();
        IPasiveAttackStrategy pasiveAttack = scenaryStrategy.GetComponent<IPasiveAttackStrategy>();
        ChangeStrategy(pasiveAttack);
        Activate();
    }

    public Attributes BakuganAttribute
    {
        get
        {
            return bakuganAttribute;
        }
        set
        {
            bakuganAttribute = value;
        }
    }

    public int GPower
    {
        get
        {
            return gPower;
        }
        set
        {
            gPower = value;
        }
    }

    public bool IsInvulnerable
    {
        get
        {
            return isInvulnerable;
        }
        set
        {
            isInvulnerable = value;
        }
    }

    public void ChangeStrategy(IPasiveAttackStrategy pasiveAttackStrategy)
    {
        pasiveAttack = pasiveAttackStrategy;
    }

    public void Activate()
    {
        pasiveAttack.Activate();
    }
}

public interface IPasiveAttackStrategy
{
    public void Activate();
}
