using UnityEngine;

public class WeaponController : MonoBehaviour {
	
	#region Variables
	// FIELDS //

    // PUBLIC PROPERTIES //
    public ProjectileGun ProjectileGunWeapon { get; private set; }
    public MineWeapon MineWeapon { get; private set; }
    public GranadeWeapon GranadeWeapon { get; private set; }
    public LaserWeapon LaserWeapon{ get; private set; }

    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake () 
	{
        ProjectileGunWeapon = gameObject.GetComponent<ProjectileGun>();
        MineWeapon = gameObject.GetComponent<MineWeapon>();
        GranadeWeapon = gameObject.GetComponent<GranadeWeapon>();
        LaserWeapon = gameObject.GetComponent<LaserWeapon>();
        
    }
    #endregion

    #region Public Methods
    // PUBLIC METHODS //

    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
