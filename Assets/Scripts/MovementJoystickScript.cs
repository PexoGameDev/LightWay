using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    #region Variables
    // FIELDS //
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject joystickPivot;

    PlayerMovement playerMovementScript;
    Vector3 MovingAngle;
    Vector3 joystickAngle;
    Vector2 joystickPivotOrigin;

    bool isMoving = false;
    // PUBLIC PROPERTIES //

    // PRIVATE PROPERTIES //
    #endregion

    #region Unity Methods
    void Awake()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();
        joystickPivotOrigin = new Vector2(joystickPivot.transform.position.x, joystickPivot.transform.position.y);
        MovingAngle = Vector3.forward;
    }

    void Update()
    {
        if (isMoving)
        {
            playerMovementScript.MovePlayer(MovingAngle);
            joystick.transform.position = joystickPivot.transform.position + joystickAngle * 100;
        }
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        SetMovingAngle(pointerEventData);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isMoving = false;
        joystick.transform.position = joystickPivot.transform.position;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        SetMovingAngle(pointerEventData);
        isMoving = true;
    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //
    void SetMovingAngle(PointerEventData pointerEventData)
    {
        joystickAngle = (pointerEventData.position - joystickPivotOrigin).normalized;
        MovingAngle = new Vector3(-joystickAngle.x, 0, -joystickAngle.y);
    }
    #endregion
}
