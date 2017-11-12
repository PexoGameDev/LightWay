using UnityEngine;

public class MineWeapon : Weapon {

    #region Variables
    // FIELDS //
    int ammoCount = 5;
    float weaponCooldown = 1f;

    // PUBLIC PROPERTIES //
    public GameObject MinePrefab { get; set; }

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
            Instantiate(MinePrefab, PlayerController.Player.transform.position, Quaternion.identity);
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
