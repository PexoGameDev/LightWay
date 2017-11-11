using UnityEngine;

public class GameController : MonoBehaviour {
	
	#region Variables
	// FIELDS //


	// PUBLIC PROPERTIES //
	public static int Score
	{
		get { return Score; }
		set {
			Score = value;
			//UIController.updatescoretext();
			}
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
	public static void GameOver()
	{
		print("GameOver!");
	}
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
