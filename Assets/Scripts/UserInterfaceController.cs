using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] Button ChangeWeaponProjectileGunButton;
    [SerializeField] Button ChangeWeaponMineButton;
    [SerializeField] Button ChangeWeaponGranadeButton;
    [SerializeField] Button ChangeWeaponLaserButton;

    WeaponController weaponController;
    PlayerShooting playerShootingModule;

    // PUBLIC PROPERTIES //


    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Awake()
    {
        weaponController = FindObjectOfType<WeaponController>();
        playerShootingModule = FindObjectOfType<PlayerShooting>();
    }

    void Start () 
	{
        AddButtonsListeners();
	}
	
	void Update () 
	{
		
	}
	#endregion

	#region Public Methods
	// PUBLIC METHODS //

	#endregion

	#region Private Methods
	// PRIVATE METHODS //
    void AddButtonsListeners()
    {
        ChangeWeaponProjectileGunButton .onClick.AddListener(delegate { playerShootingModule.ChosenWeapon = weaponController.ProjectileGunWeapon; });
        ChangeWeaponGranadeButton       .onClick.AddListener(delegate { playerShootingModule.ChosenWeapon = weaponController.GranadeWeapon; });
        ChangeWeaponMineButton          .onClick.AddListener(delegate { playerShootingModule.ChosenWeapon = weaponController.MineWeapon; });
        ChangeWeaponLaserButton         .onClick.AddListener(delegate { playerShootingModule.ChosenWeapon = weaponController.LaserWeapon; });

    }
    #endregion
}
