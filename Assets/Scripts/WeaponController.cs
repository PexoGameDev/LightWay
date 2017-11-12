using UnityEngine;

public class WeaponController : MonoBehaviour {
	
	#region Variables
	// FIELDS //
    [SerializeField] GameObject projectileGunProjectilePrefab;
    [SerializeField] GameObject minePrefab;


    // PUBLIC PROPERTIES //
    public static ProjectileGun ProjectileGunWeapon { get; private set; }
    public static MineWeapon MineWeapon { get; private set; }

    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Awake () 
	{
        ProjectileGunWeapon = gameObject.AddComponent<ProjectileGun>();
        ProjectileGunWeapon.ProjectilePrefab = projectileGunProjectilePrefab;

        MineWeapon = gameObject.AddComponent<MineWeapon>();
        MineWeapon.MinePrefab = minePrefab;
    }
	#endregion

	#region Public Methods
	// PUBLIC METHODS //

	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
