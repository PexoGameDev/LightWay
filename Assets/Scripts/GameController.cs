using UnityEngine;

public class GameController : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject ground;
    static int score = 0;
    // PUBLIC PROPERTIES //
    public static int Score
	{
		get { return score; }
		set
        {
            score = value;
            //UIController.updatescoretext();
        }
	}
    public static GameObject Ground { get; set; }
	// PRIVATE PROPERTIES //
	
	#endregion
	
	#region Unity Methods
	void Start () 
	{

	}
	
	void Update () 
	{
        Ground = ground;
	}
	#endregion

	#region Public Methods
	// PUBLIC METHODS //
	public static void GameOver()
	{
		print("GameOver!");
	}
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
