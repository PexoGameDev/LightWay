using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	#region Variables
	// FIELDS //
	[SerializeField] GameObject playerBulletPrefab;
    [SerializeField] Weapon chosenWeapon;

    Weapon[] weaponsList; //Array of all aviable weapons to choose || WeaponController is going to handle this after second thought.

	float weaponCooldownTimePassed = 0f;
    // PUBLIC PROPERTIES //


    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Start () 
	{
        chosenWeapon = WeaponController.MineWeapon;
	}
	
	void Update () 
	{
		if(weaponCooldownTimePassed< chosenWeapon.WeaponCooldown)
		{
			weaponCooldownTimePassed += Time.deltaTime;
		}
	}
	#endregion

	#region Public Methods
	// PUBLIC METHODS //
	public void Shoot()
	{
		if (weaponCooldownTimePassed > chosenWeapon.WeaponCooldown)
		{
            chosenWeapon.Shoot();
            weaponCooldownTimePassed = 0f;
        }
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //
	#endregion
}
