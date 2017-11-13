using UnityEngine;

public class LaserWeapon : Weapon {
    #region Variables
    // FIELDS //
    [SerializeField] LineRenderer laserPrefab;
    public int ammoCount = 99; //It's public only because [SerializeField] returns some weird error
    public float weaponCooldown = 1f; //It's public only because [SerializeField] returns some weird error
    // PUBLIC PROPERTIES //
    public LineRenderer LaserPrefab
    {
        get { return laserPrefab; }
        set { laserPrefab = value; }
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

    public override float WeaponCooldown
    {
        get { return weaponCooldown; }
        set { weaponCooldown = value; }
    }
    // PRIVATE PROPERTIES //

    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public override void Shoot()
    {
        if (AmmoCount > 0)
        {
            LineRenderer tmpLaser = new GameObject("Laser").AddComponent<LineRenderer>();//Instantiate(LaserPrefab, PlayerController.Player.transform.position + JoystickScript.ShootingAngle*3, Quaternion.identity);

            tmpLaser.startColor = Color.cyan;
            tmpLaser.endColor = Color.green;

            tmpLaser.SetPosition(0, PlayerController.Player.transform.position + JoystickScript.ShootingAngle * 3);
            tmpLaser.SetPosition(1, PlayerController.Player.transform.position + JoystickScript.ShootingAngle * 30);

            AmmoCount--;
        }
        else
        {
            //click sound or smth.
            print("Not enough ammo!");
        }
    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
