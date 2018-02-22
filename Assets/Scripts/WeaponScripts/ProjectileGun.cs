using UnityEngine;

public class ProjectileGun : Weapon{

    #region Variables
    // FIELDS //
    [SerializeField] GameObject projectilePrefab;

    [SerializeField] float knockbackForce = 5f;
    [SerializeField] float bulletSpeed = 2f;

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
        tmpProjectile = Instantiate (projectilePrefab, PlayerController.Player.transform.position + ShootingJoystickScript.ShootingAngle * 3, Quaternion.identity, GameController.PlayerBulletsContainer).GetComponent<PlayerBullet>();

        tmpProjectile.DirectionOfShot = ShootingJoystickScript.ShootingAngle;
        tmpProjectile.BulletParticle = Particles;
        tmpProjectile.KnockbackForce = knockbackForce;
        tmpProjectile.BulletSpeed = bulletSpeed;
        tmpProjectile.Damage = Damage;

    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
