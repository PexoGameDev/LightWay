using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    #region Variables
    // FIELDS //
    NavMeshAgent navMeshAgent;
    RaycastHit rayHit;
    Ray raycast;
    Rigidbody myRb;
	// PUBLIC PROPERTIES //


	// PRIVATE PROPERTIES //
	
	#endregion
	
	#region Unity Methods
	void Awake() 
	{
        navMeshAgent = GetComponent<NavMeshAgent>();
        myRb = GetComponent<Rigidbody>();
    }
	
	void Update() 
	{
#if UNITY_EDITOR
    if(Input.GetMouseButtonDown(0))
    {
        raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast, out rayHit))
        {
            if (rayHit.collider.gameObject == GameController.Ground)
            {
                navMeshAgent.SetDestination(rayHit.point);
            }
        }
    }
#elif UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).tapCount >= 2)
            {
                raycast = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(raycast, out rayHit))
                {
                    if (rayHit.collider.gameObject == GameController.Ground)
                    {
                        navMeshAgent.SetDestination(rayHit.point);
                    }
                }
            }
        }
#endif
    }
#endregion

    #region Public Methods
    // PUBLIC METHODS //
    public void MovePlayer(Vector3 movingAngle)
    {
        myRb.velocity = Vector3.zero;
        transform.LookAt(transform.position + movingAngle);
        transform.position += movingAngle;
    }

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
    IEnumerator ResetRigidbody()
    {
        yield return new WaitForSeconds(0.2f);
        myRb.isKinematic = true;
    }
    #endregion
}
