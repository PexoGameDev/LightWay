using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	#region Variables
	// FIELDS //
	public GameObject playerBulletPrefab;
    WeaponController weaponController;
    Weapon chosenWeapon;

	float weaponCooldownTimePassed = 0f;
    // PUBLIC PROPERTIES //
    public Weapon ChosenWeapon
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
    private void Awake()
    {
        weaponController = FindObjectOfType<WeaponController>();
    }
    void Start () 
	{
        chosenWeapon = weaponController.ProjectileGunWeapon;
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
