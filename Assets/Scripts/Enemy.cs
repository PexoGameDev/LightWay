using UnityEngine;

public class Enemy : MonoBehaviour {
	#region Variables
	// FIELDS //
	int scoreValue = 100;

    // PUBLIC PROPERTIES //
    public float DPS { get; private set; }
    private float hitPoints = 30;
    public GameObject drop;

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
                if(drop != null)
                    Instantiate(drop, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake()
    {

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

        if (other.gameObject.tag == "Explosive")
        {
            Explosive explosive = other.gameObject.GetComponent(typeof(Explosive)) as Explosive;
            HitPoints -= explosive.damage;
            Destroy(other.gameObject);
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
