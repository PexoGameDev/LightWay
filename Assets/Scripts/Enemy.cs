using UnityEngine;

public class Enemy : MonoBehaviour {
    #region Variables
    // FIELDS //
    int scoreValue = 100;
    
	// PUBLIC PROPERTIES //
    public float DPS { get; private set; }
	public float hitPoints
    {
        get { return hitPoints;}
        set { hitPoints = value; if (hitPoints < 0)
            {
                hitPoints = 0;
                GameController.Score += scoreValue;
                Destroy(gameObject);
            } }
    }
    
	// PRIVATE PROPERTIES //
	#endregion
	
	#region Unity Methods
	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}
	#endregion

	#region Public Methods
	// PUBLIC METHODS //

	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
