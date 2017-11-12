using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    #region Variables
    // FIELDS //
    float weaponCooldown = 0.1f;
    int ammoCount = 1;

    // PUBLIC PROPERTIES //
    public virtual float WeaponCooldown
    {
        get { return weaponCooldown; }
        set { weaponCooldown = value; }
    }

    public virtual int AmmoCount
    {
        get { return ammoCount; }
        set { ammoCount = value; }
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
