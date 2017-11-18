using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	#region Variables
	// FIELDS //
	public GameObject playerBulletPrefab;
    static Weapon chosenWeapon;

	float weaponCooldownTimePassed = 0f;
    // PUBLIC PROPERTIES //
    public static Weapon ChosenWeapon
    {
        get { return chosenWeapon; }
        set
        {
            chosenWeapon = value;
            //UpdateUI, show chosen weapon and ammo.
        }
    }


    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Start () 
	{
        chosenWeapon = WeaponController.ProjectileGunWeapon;
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
