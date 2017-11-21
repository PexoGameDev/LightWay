using UnityEngine;

public class GameController : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject ground;
    [SerializeField] Transform playerBulletsContainer;
    [SerializeField] Transform particlesContainer;

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
    public static Transform PlayerBulletsContainer { get; set; }
    public static Transform ParticlesContainer { get; set; }

    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Awake () 
	{
        Ground = ground;
        PlayerBulletsContainer = playerBulletsContainer;
        ParticlesContainer = particlesContainer;
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
