using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject ground;
    NavMeshAgent navMeshAgent;
    RaycastHit rayHit;
    Ray raycast;
	// PUBLIC PROPERTIES //


	// PRIVATE PROPERTIES //
	
	#endregion
	
	#region Unity Methods
	void Start () 
	{
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
	
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
        {
            raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(raycast, out rayHit))
            {
                if (rayHit.collider.gameObject == ground)
                {
                    navMeshAgent.SetDestination(rayHit.point);
                }
            }
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
