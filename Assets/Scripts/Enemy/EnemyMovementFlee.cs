using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementFlee : MonoBehaviour {

    public float distanceToTarget = 12f;
	public LayerMask playerEnemyMask;

	[Range(1, 5)]
	public int fovAccuracy = 2;
	public Vector3 fieldOfView;

	private Transform target;
	private NavMeshAgent agent;
	
	void Start ()
	{
		target = GameObject.Find("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}
	void Update ()
	{
		if(target)
		{
			if(Vector3.Distance(transform.position, target.position) < distanceToTarget || playerInSight())
			{
				Flee();
				print("Run!");
			}
		}
	}

	private void Flee()
	{
		//Look at the opposite to player direction
		transform.LookAt(transform.position-target.position);

		//Get the escape point
		Vector3 point = transform.position + transform.forward*distanceToTarget;

		//Stores NavMesh query information
		NavMeshHit hit;

		NavMesh.SamplePosition(point, out hit, distanceToTarget, 1 << NavMesh.GetNavMeshLayerFromName("Walkable"));

		agent.SetDestination(hit.position);
	}

	private bool playerInSight()
	{
		RaycastHit hitInfo;

		for(int i=0; i<fovAccuracy+1; i++)
		{
			if(Physics.Raycast(transform.position, transform.TransformDirection((Vector3.forward+fieldOfView*i)*distanceToTarget), out hitInfo, distanceToTarget, playerEnemyMask))
			{
				if(hitInfo.collider.tag == "Player")
					return true;
			}
			
			#if (UNITY_EDITOR)
			Debug.DrawRay(transform.position, transform.TransformDirection((Vector3.forward+fieldOfView*i)*distanceToTarget), Color.red);
			#endif
		}

		for(int i=1; i<=fovAccuracy; i++)
		{
			if(Physics.Raycast(transform.position, transform.TransformDirection((Vector3.forward-fieldOfView*i)*distanceToTarget), out hitInfo, distanceToTarget, playerEnemyMask))
			{
				if(hitInfo.collider.tag == "Player")
					return true;
			}

			#if (UNITY_EDITOR)
			Debug.DrawRay(transform.position, transform.TransformDirection((Vector3.forward-fieldOfView*i)*distanceToTarget), Color.red);
			#endif
		}
		
		return false;
	}
}