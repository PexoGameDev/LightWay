using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] float targetDelay = 0.2f;

    GameObject player;
    NavMeshAgent navMeshAgent;
	// PUBLIC PROPERTIES //


	// PRIVATE PROPERTIES //
	
	#endregion
	
	#region Unity Methods
	void Awake() 
	{
        player = FindObjectOfType<PlayerMovement>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(TargetPlayer());
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
    IEnumerator TargetPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
        yield return new WaitForSeconds(targetDelay);
    }
	#endregion
}
