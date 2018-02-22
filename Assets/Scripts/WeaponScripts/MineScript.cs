using UnityEngine;

public class MineScript : Explosive {

    #region Variables
    // FIELDS //
    SphereCollider sphereCollider;

    // PUBLIC PROPERTIES //
    public float TimeDelay { get; set; }

    #endregion

    #region Unity Methods
    void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Start()
    {
        Invoke("MineReady", TimeDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Explode();
        }
    }
    #endregion

    #region Private Methods
    void MineReady()
    {
        sphereCollider.enabled = true;
    }
    #endregion
}
