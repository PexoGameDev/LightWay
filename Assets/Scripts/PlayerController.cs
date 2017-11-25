using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] float hitDelay = 0.2f;

    PlayerMovement playerMovement;

    bool canBeHit = true;
    float hitDelayTimePassed = 0f;
    float hitPoints;
    // PUBLIC PROPERTIES //
    public static GameObject Player { get; private set; }
    public float HitPoints
    {
        get { return hitPoints; }
        set
        {
            hitPoints = value;
            if (hitPoints < 0f)
            {
                hitPoints = 0;
                GameController.GameOver();
            }
        }
    }

    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Awake () 
	{
        playerMovement = GetComponent<PlayerMovement>();
        Player = gameObject;
        HitPoints = 100f;
	}
	
	void Update () 
	{
        if(hitDelayTimePassed>hitDelay)
        {
            canBeHit = true;
        }
        else
        {
            hitDelayTimePassed += Time.deltaTime;
        }
    }

	private void OnTriggerStay(Collider other)
	{
		if(other.GetComponent<Enemy>() && canBeHit)
		{
            Enemy tmpEnemy = other.GetComponent<Enemy>();
            HitPoints -= tmpEnemy.DPS;
            canBeHit = false;
            hitDelayTimePassed = 0f;
            playerMovement.GetKnockedBack((transform.position - tmpEnemy.transform.position)* tmpEnemy.KnockbackStrength);
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
