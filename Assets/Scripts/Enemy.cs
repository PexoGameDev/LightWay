using UnityEngine;

public class Enemy : MonoBehaviour {
	#region Variables
	// FIELDS //
	int scoreValue = 100;
    BoxCollider myCollider;

    // PUBLIC PROPERTIES //
    public float DPS { get; private set; }
    private float hitPoints = 30;

    public float HitPoints
    {
        get { return hitPoints; }
        set
        {
            hitPoints = value;
            if (hitPoints < 0)
            {
                hitPoints = 0;
                GameController.Score += scoreValue;
                Destroy(gameObject);
            }
        }
    }

    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake()
    {
        myCollider = GetComponent<BoxCollider>();
    }
    void Start () 
	{
        DPS = 10;
	}
	
	void Update () 
	{
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerBullet>())
        {
            PlayerBullet tmpBullet = other.GetComponent<PlayerBullet>();
            HitPoints -= tmpBullet.Damage;
            tmpBullet.Hit();
        }
    }
    #endregion

    #region Public Methods
    // PUBLIC METHODS //

    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
