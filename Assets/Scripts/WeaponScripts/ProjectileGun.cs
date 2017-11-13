using UnityEngine;

public class ProjectileGun : Weapon{

    #region Variables
    // FIELDS //
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject defaultProjectile;
    public int ammoCount = 99; //It's public only because [SerializeField] returns some weird error
    public float weaponCooldown = 1f; //It's public only because [SerializeField] returns some weird error

    public GameObject ProjectilePrefab
    {
        private get { return projectilePrefab; }
        set { projectilePrefab = value; }
    }

    public override float WeaponCooldown
    {
        get { return weaponCooldown; }
        set { weaponCooldown = value; }
    }

    public override int AmmoCount
    {
        get { return ammoCount; }

        set
        {
            ammoCount = value;
            if (ammoCount <= 0)
            {
                ammoCount = 0;
                print("Out of ammo in" + name + "!");
            }
        }
    }
    // PRIVATE PROPERTIES //
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    override public void Shoot()
    {
            Instantiate
            (
                projectilePrefab, PlayerController.Player.transform.position + JoystickScript.ShootingAngle * 3, Quaternion.identity
            )   .GetComponent<PlayerBullet>().DirectionOfShot = JoystickScript.ShootingAngle;
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
