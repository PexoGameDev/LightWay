using UnityEngine;

public class GranadeScript : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject explosionParticles;
    float explosionRadius = 5f;
    int damage = 100;
    Rigidbody myRb;
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

    public Vector3 Force { get; set; }
    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameController.Ground || other.GetComponent<Enemy>())
        {
            Explode();
        }
    }
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public void StartMovement()
    {
        myRb.AddForce(Force, ForceMode.Impulse);
    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //
    void Explode()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Collider[] objectsInExplosionRange = Physics.OverlapSphere(transform.position, ExplosionRadius);
        for (int i = 0; i < objectsInExplosionRange.Length; i++)
        {
            Enemy tmpEnemy = objectsInExplosionRange[i].GetComponent<Enemy>();
            if (tmpEnemy!=null)
            {
                tmpEnemy.HitPoints -= Damage;
            }
        }
        Destroy(gameObject);
    }
    #endregion
}
