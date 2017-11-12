using UnityEngine;

public class Weapon : MonoBehaviour {

    #region Variables
    // FIELDS //
    float weaponCooldown = 0.1f;
    int ammoCount = 1;

    // PUBLIC PROPERTIES //
    public float WeaponCooldown
    {
        get { return weaponCooldown; }
        private set { weaponCooldown = value; }
    }

    public int AmmoCount
    {
        get { return ammoCount; }
        private set { ammoCount = value; }
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
