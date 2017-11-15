using UnityEngine;

public class LaserProjectile : MonoBehaviour {

    #region Variables
    // FIELDS //

    // PUBLIC PROPERTIES //

    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Start () 
	{
        	

	}
	
    void Update () 
	{
		

	}

    void OnTriggerEnter(Collider other)
    {
        Collider[] objectsInExplosionRange = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f)); //Working on it, it's supposed to be collider covering whole line renderer, but well... it doesn't work yet.
        for (int i = 0; i < objectsInExplosionRange.Length; i++)
        {
            Enemy tmpEnemy = objectsInExplosionRange[i].GetComponent<Enemy>();
            if (tmpEnemy != null)
            {
                //damage 'em
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
