using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Variables
    // FIELDS //
    bool canBeHit = true;

    [SerializeField] float hitDelay = 0.2f;
    float hitDelayTimePassed = 0f;

    // PUBLIC PROPERTIES //
    private float hitPoints;

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
            print("Ouch!");
            Enemy tmpEnemy = other.GetComponent<Enemy>();
            HitPoints -= tmpEnemy.DPS;
            canBeHit = false;
            hitDelayTimePassed = 0f;
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
