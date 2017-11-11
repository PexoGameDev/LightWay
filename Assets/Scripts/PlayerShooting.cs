using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	#region Variables
	// FIELDS //
	JoystickScript  joystick;
	float           weaponCooldownTimePassed = 0f;

	[SerializeField] GameObject playerBulletPrefab;
	float      weaponCooldown = 0.1f;

	// PUBLIC PROPERTIES //


	// PRIVATE PROPERTIES //

	#endregion

	#region Unity Methods
	void Start () 
	{
		joystick = FindObjectOfType<JoystickScript>();
	}
	
	void Update () 
	{
		if(weaponCooldownTimePassed<weaponCooldown)
		{
			weaponCooldownTimePassed += Time.deltaTime;
		}
	}
	#endregion

	#region Public Methods
	// PUBLIC METHODS //
	public void Shoot(Vector3 direction)
	{
		if (weaponCooldownTimePassed > weaponCooldown)
		{
			Instantiate(playerBulletPrefab, transform.position, Quaternion.identity).GetComponent<PlayerBullet>().DirectionOfShot = direction;
			weaponCooldownTimePassed = 0f;
		}
	}
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
