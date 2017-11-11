using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Variables
    // FIELDS //
    BoxCollider myCollider;

    // PUBLIC PROPERTIES //
    [SerializeField]
    float hitPoints
    {
        get
        {
            return hitPoints;
        }
        set
        {
            hitPoints = value;
            if(hitPoints<0)
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
		myCollider = GetComponent<BoxCollider>();

	}
	
	void Update () 
	{
		
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.GetComponent<Enemy>())
		{
            Enemy tmpEnemy = other.GetComponent<Enemy>();
            hitPoints -= tmpEnemy.DPS;
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
