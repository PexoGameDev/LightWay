using UnityEngine;

public class WeaponController : MonoBehaviour {
	
	#region Variables
	// FIELDS //
    [SerializeField] GameObject projectileGunProjectilePrefab;
    [SerializeField] GameObject granadePrefab;
    [SerializeField] GameObject minePrefab;


    // PUBLIC PROPERTIES //
    public static ProjectileGun ProjectileGunWeapon { get; private set; }
    public static MineWeapon MineWeapon { get; private set; }
    public static GranadeWeapon GranadeWeapon { get; private set; }

    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Awake () 
	{
        ProjectileGunWeapon = gameObject.AddComponent<ProjectileGun>();
        ProjectileGunWeapon.ProjectilePrefab = projectileGunProjectilePrefab;

        MineWeapon = gameObject.AddComponent<MineWeapon>();
        MineWeapon.MinePrefab = minePrefab;

        GranadeWeapon = gameObject.AddComponent<GranadeWeapon>();
        GranadeWeapon.GranadePrefab = granadePrefab;
    }
	#endregion

	#region Public Methods
	// PUBLIC METHODS //

	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
