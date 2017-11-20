using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    #region Variables
    // FIELDS //
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

        // RAYCAST POINT'N'CLICK MOVEMENT
	/*	if(Input.GetMouseButtonDown(0))
        {
            raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(raycast, out rayHit))
            {
                if (rayHit.collider.gameObject == GameController.Ground)
                {
                    navMeshAgent.SetDestination(rayHit.point);
                }
            }
        }*/
	}
	#endregion

	#region Public Methods
	// PUBLIC METHODS //
    public void MovePlayer(Vector3 movingAngle)
    {
        transform.LookAt(transform.position + movingAngle);
        transform.position += movingAngle;
    }
	#endregion

	#region Private Methods
	// PRIVATE METHODS //

	#endregion
}
