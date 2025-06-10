using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>()?.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
