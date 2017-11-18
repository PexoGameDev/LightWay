using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    #region Variables
    // FIELDS //
    protected float weaponCooldown = 0.1f;
    protected int ammoCount = 1;

    // PROPERTIES //
    public virtual float WeaponCooldown
    {
        get { return weaponCooldown; }
        set { weaponCooldown = value; }
    }

    public virtual int AmmoCount
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
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public virtual void Shoot()
    {
        print("Main Weapon Class shoots");
    }
    #endregion
}
