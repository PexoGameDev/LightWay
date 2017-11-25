using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementFlee : MonoBehaviour {

    public float distanceToTarget = 12f;
	public float boundsOffset = 1f;

	private Transform target;
	private NavMeshAgent agent;
	private Vector3 point = Vector3.zero;
	private Vector3 minPosition;
    private Vector3 maxPosition;
	
	void Start ()
	{
		target = GameObject.Find("Player").transform;
		agent = GetComponent<NavMeshAgent>();

		minPosition = Camera.main.GetComponent<CameraFollow>().minPosition;
		maxPosition = Camera.main.GetComponent<CameraFollow>().maxPosition;

		minPosition.x += boundsOffset;
		minPosition.z += boundsOffset;
		maxPosition.x -= boundsOffset;
		maxPosition.z -= boundsOffset;

	}
	
	void Update ()
	{
		if(target)
		{
			if(Vector3.Distance(transform.position, target.position) <= distanceToTarget)
			{
				if(point == Vector3.zero)
					Flee();
			}

			if(agent.velocity == Vector3.zero)
				point = Vector3.zero;
		}
	}

	private void Flee()
	{
		point = CalculatePoint();

		agent.SetDestination(point);
	}

	private Vector3 CalculatePoint()
	{
		Vector3 freePoint = new Vector3(Random.Range(minPosition.x, maxPosition.x), transform.position.y, Random.Range(minPosition.z, maxPosition.z));

		if(Vector3.Distance(freePoint, target.position) <= distanceToTarget)
			return CalculatePoint();
		
		return freePoint;
	}
}
