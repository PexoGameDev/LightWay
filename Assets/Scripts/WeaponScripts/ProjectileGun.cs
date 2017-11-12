﻿using UnityEngine;

public class ProjectileGun : Weapon{

    #region Variables
    // FIELDS //
    GameObject projectilePrefab;
    float weaponCooldown = 0.3f;

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