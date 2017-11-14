using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class MineBehaviour : Explosive
{
	void Start ()
    {
        Invoke("MineReady", 2f);
	}
	
    void MineReady()
    {
        GetComponent<SphereCollider>().enabled = true;
    }
}
