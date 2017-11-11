using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	#region Variables
	// FIELDS //
	float bulletSpeed = 2f;
	[SerializeField] float timeOfLife = 3f;
    // PUBLIC PROPERTIES //
	public Vector3 DirectionOfShot { get; set; }
    private float damage = 2f;
    [SerializeField] public GameObject BulletParticle;
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

	#region Public Methods
	// PUBLIC METHODS //
    public void Hit()
    {
        //instantiate particles
        Instantiate(BulletParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
