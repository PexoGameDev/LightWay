using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	#region Variables
	// FIELDS //
    [SerializeField] GameObject BulletParticle;
	[SerializeField] float timeOfLife = 3f;
	float bulletSpeed = 2f;
    float damage = 2f;

    // PUBLIC PROPERTIES //
    public Vector3 DirectionOfShot { get; set; }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
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
		transform.position += DirectionOfShot * bulletSpeed;
	}
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().HitPoints -= Damage;
        }

        Hit();
    }

    #region Public Methods
    // PUBLIC METHODS //
    public void Hit()
    {
        Instantiate(BulletParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
