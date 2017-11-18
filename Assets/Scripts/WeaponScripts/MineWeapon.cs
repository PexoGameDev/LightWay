using UnityEngine;

public class MineWeapon : Weapon {

    #region Variables
    // FIELDS //
    public GameObject minePrefab;

    // PUBLIC PROPERTIES //
    public GameObject MinePrefab
    {
        get { return minePrefab; }
        set { minePrefab = value; }
    }
    // PRIVATE PROPERTIES //

    #endregion

    public MineWeapon()
    {
        WeaponCooldown = 1f;
        AmmoCount = 99;
    }

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
