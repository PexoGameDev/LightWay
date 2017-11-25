using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	#region Variables
	// FIELDS //
    [SerializeField] GameObject bulletParticle;
	[SerializeField] float timeOfLife = 3f;
    float damage = 2f;
    // PUBLIC PROPERTIES //
    public Vector3 DirectionOfShot { get; set; }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float KnockbackForce {get;set;}
    public float BulletSpeed { get; set; }
    public GameObject BulletParticle
    {
        get { return bulletParticle; }
        set { bulletParticle = value; }
    }
    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Start () 
	{
		Destroy(gameObject, timeOfLife);
	}
	
	void FixedUpdate () 
	{
		transform.position += DirectionOfShot * BulletSpeed;
	}
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().HitPoints -= Damage;
            other.GetComponent<EnemyMovement>().GetKnockedBack(DirectionOfShot * KnockbackForce);
        }

        Hit();
    }

    #region Public Methods
    // PUBLIC METHODS //
    public void Hit()
    {
        Instantiate(BulletParticle,transform.position,Quaternion.identity, GameController.ParticlesContainer);
        Destroy(gameObject);
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
