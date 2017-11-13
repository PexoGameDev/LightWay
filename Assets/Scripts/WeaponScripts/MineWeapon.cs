using UnityEngine;

public class MineWeapon : Weapon {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject minePrefab;
    public int ammoCount = 99; //It's public only because [SerializeField] returns some weird error
    public float weaponCooldown = 1f; //It's public only because [SerializeField] returns some weird error

    // PUBLIC PROPERTIES //
    public GameObject MinePrefab
    {
        get { return minePrefab; }
        set { minePrefab = value; }
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
