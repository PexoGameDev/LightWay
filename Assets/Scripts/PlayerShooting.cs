using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	#region Variables
	// FIELDS //
	float weaponCooldownTimePassed = 0f;

	[SerializeField] GameObject playerBulletPrefab;
	float weaponCooldown = 0.1f;
    // PUBLIC PROPERTIES //


    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Start () 
	{

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
			Instantiate(playerBulletPrefab, transform.position + 3*direction, Quaternion.identity).GetComponent<PlayerBullet>().DirectionOfShot = direction;
			weaponCooldownTimePassed = 0f;
		}
	}
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
