using UnityEngine;

public class Explosive : MonoBehaviour
{
    #region Variables
    // FIELDS //
    [SerializeField] protected float explosionRadius = 1f;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected GameObject explosionParticles;
    // PUBLIC PROPERTIES //
    public float ExplosionRadius
    {
        get { return explosionRadius; }
        set { explosionRadius = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public GameObject ExplosionParticles
    {
        get { return explosionParticles; }
        set { explosionParticles = value; }
    }
    #endregion

    #region Public Methods
    public void Explode()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity, GameController.ParticlesContainer);
        Collider[] objectsInExplosionRange = Physics.OverlapSphere(transform.position, ExplosionRadius);
        for (int i = 0; i < objectsInExplosionRange.Length; i++)
        {
            Enemy tmpEnemy = objectsInExplosionRange[i].GetComponent<Enemy>();
            if (tmpEnemy != null)
            {
                tmpEnemy.HitPoints -= Damage;
            }
        }
        Destroy(gameObject);
    }
    #endregion
}
