using UnityEngine;

public class GranadeWeapon : Weapon {

    #region Variables
    // FIELDS //
    [Range(0.01f,0.9f)]
    public float slope = 0.3f;
    public GameObject granadePrefab;
    public float GranadeMass;
    public float GranadeDrag;
    public float GranadeAngularDrag;
    // PUBLIC PROPERTIES //
    public GameObject GranadePrefab
    {
        get { return granadePrefab; }
        set { granadePrefab = value; }
    }
    // PRIVATE PROPERTIES //

    public GranadeWeapon()
    {
        WeaponCooldown = 1f;
        AmmoCount = 99;
    }

    #endregion
    void Start()
    {
        Rigidbody granadeRb = GranadePrefab.GetComponent<Rigidbody>();
        granadeRb.drag = GranadeDrag;
        granadeRb.angularDrag = GranadeAngularDrag;
        granadeRb.mass = GranadeMass;
    }
    #region Public Methods
    // PUBLIC METHODS //
    public override void Shoot()
    {
        if (AmmoCount > 0)
        {
            GranadeScript tmpGranade = Instantiate(GranadePrefab, PlayerController.Player.transform.position + Vector3.up*4, Quaternion.identity).GetComponent<GranadeScript>();
            tmpGranade.Force = new Vector3(JoystickScript.ShootingAngle.x, slope, JoystickScript.ShootingAngle.z) * 50;
            tmpGranade.StartMovement();
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
