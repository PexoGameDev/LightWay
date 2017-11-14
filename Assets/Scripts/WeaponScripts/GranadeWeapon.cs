using UnityEngine;

public class GranadeWeapon : Weapon {

    #region Variables
    // FIELDS //
    [SerializeField] [Range(0.01f,0.9f)] float slope = 0.3f;
    [SerializeField] GameObject granadePrefab;
    public int ammoCount = 99; //It's public only because [SerializeField] returns some weird error
    public float weaponCooldown = 1f; //It's public only because [SerializeField] returns some weird error
    [SerializeField] float GranadeMass;
    [SerializeField] float GranadeDrag;
    [SerializeField] float GranadeAngularDrag;
    // PUBLIC PROPERTIES //
    public GameObject GranadePrefab
    {
        get { return granadePrefab; }
        set { granadePrefab = value; }
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
