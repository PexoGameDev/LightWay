using UnityEngine;

public class GranadeWeapon : Weapon {

    #region Variables
    // FIELDS //
    [Range(0.01f,0.9f)] float slope = 0.3f;

    int ammoCount = 99;
    float weaponCooldown = 1f;
    // PUBLIC PROPERTIES //
    public GameObject GranadePrefab { get; set; }

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
            GranadeScript tmpGranade = Instantiate(GranadePrefab, PlayerController.Player.transform.position + Vector3.up*4, Quaternion.identity).GetComponent<GranadeScript>();
            tmpGranade.Force = new Vector3(JoystickScript.ShootingAngle.x, slope, JoystickScript.ShootingAngle.z) * 50;
            tmpGranade.StartMovement();
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
