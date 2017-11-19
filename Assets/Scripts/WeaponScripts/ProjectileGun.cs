using UnityEngine;

public class ProjectileGun : Weapon{

    #region Variables
    // FIELDS //
    [SerializeField] GameObject projectilePrefab;
    PlayerBullet tmpProjectile;

    public GameObject ProjectilePrefab
    {
        private get { return projectilePrefab; }
        set { projectilePrefab = value; }
    }
    // PRIVATE PROPERTIES //
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    override public void Shoot()
    {
        tmpProjectile = Instantiate (projectilePrefab, PlayerController.Player.transform.position + JoystickScript.ShootingAngle * 3, Quaternion.identity).GetComponent<PlayerBullet>();

        tmpProjectile.DirectionOfShot = JoystickScript.ShootingAngle;
        tmpProjectile.Damage = Damage;
    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
