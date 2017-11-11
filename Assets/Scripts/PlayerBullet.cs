using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	#region Variables
	// FIELDS //
	[SerializeField] float bulletSpeed = 1f;
	[SerializeField] float timeOfLife = 5f;
	// PUBLIC PROPERTIES //
	public Vector3 DirectionOfShot { get; set; }

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
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
