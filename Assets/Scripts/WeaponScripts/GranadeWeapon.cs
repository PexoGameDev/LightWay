using UnityEngine;

public class GranadeWeapon : Weapon {

    #region Variables
    // FIELDS //
    public GameObject granadePrefab;

    [Range(0.01f,0.9f)]
    public float Slope = 0.3f;
    public float GranadeMass = 1;
    public float GranadeDrag = 0;
    public float GranadeAngularDrag = 1;
    public float ExplosionRadius = 10f;
    public int Damage = 20;

    // PUBLIC PROPERTIES //
    public GameObject GranadePrefab
    {
        get { return granadePrefab; }
        set { granadePrefab = value; }
    }
    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Start()
    {
        Rigidbody granadeRb = GranadePrefab.GetComponent<Rigidbody>();
        GranadeScript granadeScript = granadePrefab.GetComponent<GranadeScript>();

        granadeRb.drag = GranadeDrag;
        granadeRb.angularDrag = GranadeAngularDrag;
        granadeRb.mass = GranadeMass;

        granadeScript.ExplosionRadius = ExplosionRadius;
        granadeScript.Damage = Damage;
    }
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public override void Shoot()
    {
        if (AmmoCount > 0)
        {
            GranadeScript tmpGranade = Instantiate(GranadePrefab, PlayerController.Player.transform.position + Vector3.up*4, Quaternion.identity).GetComponent<GranadeScript>();
            tmpGranade.Force = new Vector3(JoystickScript.ShootingAngle.x, Slope, JoystickScript.ShootingAngle.z) * 50;
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
