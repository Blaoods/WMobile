using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    public static InputListener instance;

    public GeneralMap inputMap;

    public Vector2 touch_1_position;
    public Vector2 touch_2_position;

    public bool touch_1_contact;
    public bool touch_2_contact;

    public bool touch_1_contactDown;
    public bool touch_2_contactDown;

    public bool touch_1_contactUp;
    public bool touch_2_contactUp;

    void Awake()
	{
        instance = this;

        inputMap = new GeneralMap();
        inputMap.Enable();

        inputMap.General.Touch_1_Position.performed += OnTouch1;
        inputMap.General.Touch_1_Position.canceled += OnTouch1;

        inputMap.General.Touch_2_Position.performed += OnTouch2;
        inputMap.General.Touch_2_Position.canceled += OnTouch2;

        inputMap.General.Touch_1_Contact.started += OnTouchContact1;
        inputMap.General.Touch_1_Contact.performed += OnTouchContact1;
        inputMap.General.Touch_1_Contact.canceled += OnTouchContact1;

        inputMap.General.Touch_1_Contact.started += OnTouchContact2;
        inputMap.General.Touch_1_Contact.performed += OnTouchContact2;
        inputMap.General.Touch_1_Contact.canceled += OnTouchContact2;
    }

	private void OnDisable()
	{
        inputMap.Disable();

        inputMap.General.Touch_1_Position.performed -= OnTouch1;
        inputMap.General.Touch_1_Position.canceled -= OnTouch1;

        inputMap.General.Touch_2_Position.performed -= OnTouch2;
        inputMap.General.Touch_2_Position.canceled -= OnTouch2;

        inputMap.General.Touch_1_Contact.started -= OnTouchContact1;
        inputMap.General.Touch_1_Contact.performed -= OnTouchContact1;
        inputMap.General.Touch_1_Contact.canceled -= OnTouchContact1;

        inputMap.General.Touch_1_Contact.started -= OnTouchContact2;
        inputMap.General.Touch_1_Contact.performed -= OnTouchContact2;
        inputMap.General.Touch_1_Contact.canceled -= OnTouchContact2;
    }

    void OnTouch1(InputAction.CallbackContext context)
	{
        touch_1_position = context.ReadValue<Vector2>();
    }

    void OnTouch2(InputAction.CallbackContext context)
    {
        touch_2_position = context.ReadValue<Vector2>();
    }

    void OnTouchContact1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started: touch_1_contactDown = true; break;
            case InputActionPhase.Performed: touch_1_contact = true; break;
            case InputActionPhase.Canceled: touch_1_contact = false; touch_1_contactUp = true ; break;
        }
    }

    void OnTouchContact2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started: touch_2_contactDown = true; break;
            case InputActionPhase.Performed: touch_2_contact = true; break;
            case InputActionPhase.Canceled: touch_2_contact = false; touch_2_contactUp = true; break;
        }
    }

    /*void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void OnUiMove(InputAction.CallbackContext context)
    {
        uiMoveInput = context.ReadValue<Vector2>();
    }

    void OnMouse(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }

    

    void OnBack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started: backInputDown = true; break;
            case InputActionPhase.Performed: backInput = true; break;
            case InputActionPhase.Canceled: backInput = false; ; break;
        }
    }

    void OnStart(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started: startInputDown = true; break;
            case InputActionPhase.Performed: startInput = true; break;
            case InputActionPhase.Canceled: startInput = false; ; break;
        }
    }

    void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started: jumpInputDown = true; break;
            case InputActionPhase.Performed: jumpInput = true; break;
            case InputActionPhase.Canceled: jumpInput = false; ; break;
        }
    }*/

    private void LateUpdate()
	{
        touch_1_contactDown = false;
        touch_2_contactDown = false;

        touch_1_contactUp = false;
        touch_2_contactUp = false;
    }
}
