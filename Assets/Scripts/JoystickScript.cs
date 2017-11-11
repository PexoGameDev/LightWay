using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject joystickPivot;
    BoxCollider2D               myCollider;
    PlayerShooting              playerShootingScript;
    bool                        isShooting = false;
    Vector2                     joystickPivotOrigin;
    // PUBLIC PROPERTIES //
    public Vector3 ShootingAngle { get; private set; }


    // PRIVATE PROPERTIES //

    #endregion

    #region Unity Methods
    void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        playerShootingScript = FindObjectOfType<PlayerShooting>();
        joystickPivotOrigin = new Vector2(joystickPivot.transform.position.x, joystickPivot.transform.position.y);
    }

    void Update()
    {
        if(isShooting)
        {
            playerShootingScript.Shoot(new Vector3(-ShootingAngle.x, 0, -ShootingAngle.y));
            joystick.transform.position = joystickPivot.transform.position + ShootingAngle * 100;
        }
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        ShootingAngle = (pointerEventData.position - joystickPivotOrigin).normalized;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isShooting = false;
        joystick.transform.position = joystickPivot.transform.position;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isShooting = true;
        ShootingAngle = (pointerEventData.position - joystickPivotOrigin).normalized;
    }
    #endregion

    #region Public Methods
        // PUBLIC METHODS //
    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
