using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject joystickPivot;

    PlayerShooting playerShootingScript;
    Vector2 joystickPivotOrigin;
    Vector3 joystickAngle;

    bool isShooting = false;
    // PUBLIC PROPERTIES //
    public static Vector3 ShootingAngle { get; private set; }
    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake()
    {
        playerShootingScript = FindObjectOfType<PlayerShooting>();
        joystickPivotOrigin = new Vector2(joystickPivot.transform.position.x, joystickPivot.transform.position.y);
        ShootingAngle = Vector3.forward;
    }

    void Update()
    {
        if(isShooting)
        {
            playerShootingScript.Shoot();
            joystick.transform.position = joystickPivot.transform.position + joystickAngle * 100;
        }
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        SetShootingAngle(pointerEventData);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isShooting = false;
        joystick.transform.position = joystickPivot.transform.position;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        SetShootingAngle(pointerEventData);
        isShooting = true;
    }
    #endregion

    #region Public Methods
        // PUBLIC METHODS //
    #endregion

    #region Private Methods
    // PRIVATE METHODS //
    void SetShootingAngle(PointerEventData pointerEventData)
    {
        joystickAngle = (pointerEventData.position - joystickPivotOrigin).normalized;
        ShootingAngle = new Vector3(-joystickAngle.x, 0, -joystickAngle.y);
    }
    #endregion
}
