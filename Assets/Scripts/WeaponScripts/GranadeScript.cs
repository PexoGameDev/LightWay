using UnityEngine;

public class GranadeScript : Explosive {

    #region Variables
    // FIELDS //
    Rigidbody myRb;

    // PUBLIC PROPERTIES //
    public Vector3 Force { get; set; }

    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameController.Ground || other.GetComponent<Enemy>())
        {
            Explode();
        }
    }
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public void StartMovement()
    {
        myRb.AddForce(Force, ForceMode.Impulse);
    }
    #endregion
}
