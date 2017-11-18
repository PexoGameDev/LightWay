using UnityEngine;

public class ProjectileGun : Weapon{

    #region Variables
    // FIELDS //
    private GameObject projectilePrefab;
    private GameObject defaultProjectile;
    
    public GameObject ProjectilePrefab
    {
        private get { return projectilePrefab; }
        set { projectilePrefab = value; }
    }
    // PRIVATE PROPERTIES //
    #endregion

    public ProjectileGun()
    {
        AmmoCount = 99;
        WeaponCooldown = 1f;
    }

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
