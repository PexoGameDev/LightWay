using UnityEngine;

public class LaserProjectile : MonoBehaviour {

    #region Variables
    // FIELDS //

    // PUBLIC PROPERTIES //
    public int Damage { get; set; }
    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Start () 
	{
        SetCollider();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>())
        {
            Enemy tmpEnemy = other.GetComponent<Enemy>();
            tmpEnemy.HitPoints -= Damage;
            //Some Enemy's animation of getting damaged?
        }
    }
    #endregion
    #region Private Methods
    void SetCollider()
    {
        LineRenderer myLine = GetComponent<LineRenderer>();
        BoxCollider myCollider = GetComponent<BoxCollider>();

        Vector3 startPoint = myLine.GetPosition(0);
        Vector3 endPoint = myLine.GetPosition(1);
        Vector3 midPoint = (startPoint + endPoint) / 2;
        float lineLenght = Vector3.Distance(startPoint, endPoint);

        myCollider.size = new Vector3(lineLenght, 4f, 4f);
        myCollider.transform.position = midPoint;
        myCollider.transform.LookAt(startPoint);
        myCollider.transform.Rotate(0, 90f, 0);
    }
    #endregion
}
