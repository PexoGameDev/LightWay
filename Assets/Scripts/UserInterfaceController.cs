using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] Button ChangeWeaponProjectileGunButton;
    [SerializeField] Button ChangeWeaponMineButton;
    [SerializeField] Button ChangeWeaponGranadeButton;
    [SerializeField] Button ChangeWeaponLaserButton;

    // PUBLIC PROPERTIES //


    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
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
        ChangeWeaponProjectileGunButton .onClick.AddListener(delegate { PlayerShooting.ChosenWeapon = WeaponController.ProjectileGunWeapon; });
        ChangeWeaponGranadeButton       .onClick.AddListener(delegate { PlayerShooting.ChosenWeapon = WeaponController.GranadeWeapon; });
        ChangeWeaponMineButton          .onClick.AddListener(delegate { PlayerShooting.ChosenWeapon = WeaponController.MineWeapon; });
        ChangeWeaponLaserButton         .onClick.AddListener(delegate { PlayerShooting.ChosenWeapon = WeaponController.LaserWeapon; });

    }
    #endregion
}
