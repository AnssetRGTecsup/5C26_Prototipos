using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    [Header("Configuración de la Explosión")]
    public float damage = 20f;
    public float explosionRadius = 4f;
    public LayerMask enemyLayer;

    

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        

        Collider[] enemiesToDamage = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);

        
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            Collider enemy = enemiesToDamage[i];
            Debug.Log($"<color=orange>Explosión ha dañado a: {enemy.name}</color>");

           
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}