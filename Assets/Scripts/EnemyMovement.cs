using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    #region Variables
    // FIELDS //
    public bool invert = false;
    [SerializeField] float targetDelay = 0.1f;

    GameObject player;
    NavMeshAgent navMeshAgent;
    Rigidbody myRb;
	// PUBLIC PROPERTIES //


	// PRIVATE PROPERTIES //
	
	#endregion
	
	#region Unity Methods
	void Awake() 
	{
        player = FindObjectOfType<PlayerMovement>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        myRb = GetComponent<Rigidbody>();

        InvokeRepeating("TargetPlayer", 0f, targetDelay);
    }
	
	void Update () 
	{
		
	}
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public void GetKnockedBack(Vector3 direction)
    {
        myRb.isKinematic = false;
        myRb.AddForce(direction, ForceMode.Impulse);
        StopCoroutine("ResetRigidbody");
        StartCoroutine("ResetRigidbody");
    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //
    void TargetPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position * (invert ? -1 : 1));
    }

    IEnumerator ResetRigidbody()
    {
        yield return new WaitForSeconds(0.3f);
        myRb.isKinematic = true;
    }
    #endregion
}
