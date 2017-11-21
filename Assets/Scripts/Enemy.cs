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

                if (drop != null)
                {
                    Instantiate(drop, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }
    }

    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Start () 
	{
        DPS = 10; //DEBUG
	}
    #endregion

    #region Public Methods
    // PUBLIC METHODS //

    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
