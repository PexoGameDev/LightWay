using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    #region Variables
    // FIELDS //
    public bool invert = false;
    [SerializeField] float targetDelay = 0.1f;

    private GameObject player;
    private NavMeshAgent navMeshAgent;
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
        for (; ; )
        {
            navMeshAgent.SetDestination(player.transform.position*(invert ? -1 : 1));
            yield return new WaitForSeconds(targetDelay);
        }
    }
	#endregion
}
