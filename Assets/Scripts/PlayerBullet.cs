using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	#region Variables
	// FIELDS //
	[SerializeField] float bulletSpeed = 1f;
	[SerializeField] float timeOfLife = 5f;
    // PUBLIC PROPERTIES //
	public Vector3 DirectionOfShot { get; set; }
    private float damage = 10f;

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
        Destroy(gameObject);
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
