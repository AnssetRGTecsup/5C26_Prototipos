using UnityEngine;
using System.Collections;

public class ShieldStrategy : MonoBehaviour, IPasiveAttackStrategy
{
    [SerializeField] private float activeSeconds;
    public void Activate()
    {
        BakuganAttack bakuganAttack = GetComponent<BakuganAttack>();
        StartCoroutine(ShieldProtection(bakuganAttack));
    }

    private IEnumerator ShieldProtection(BakuganAttack bakuganAttack)
    {
        bakuganAttack.IsInvulnerable = true;
        yield return new WaitForSeconds(activeSeconds);
        bakuganAttack.IsInvulnerable = false;
    }
}
