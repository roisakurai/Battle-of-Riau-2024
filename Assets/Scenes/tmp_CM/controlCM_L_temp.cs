using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controlCM_L_temp : MonoBehaviour
{
    public List<InputAxis> inputAxis = new List<InputAxis>() { InputAxis.LeftThumbStickAxis };
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    public float moveSpeed = 5f; // Adjust this to control the movement speed


    void Update()
    {
        // Get joystick input
        float horizontalInput = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");
        float verticalInput = Input.GetAxis("XRI_Right_Primary2DAxis_Vertical");

        // Calculate movement direction based on joystick input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the cube based on the joystick input
        transform.Translate(movement * moveSpeed * Time.deltaTime);


        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    Debug.Log("KeyCode down: " + keyCode);
                    break;
                }
            }
        }
    }

    //public virtual Vector2 GetMovementAxis()
    //{

    //    // Use the largest, non-zero value we find in our input list
    //    Vector3 lastAxisValue = Vector3.zero;
    //    // Check raw input bindings
    //    if (inputAxis != null)
    //    {
    //        for (int i = 0; i < inputAxis.Count; i++)
    //        {
    //            Vector3 axisVal = InputBridge.Instance.GetInputAxisValue(inputAxis[i]);

    //            // Always take this value if our last entry was 0. 
    //            if (lastAxisValue == Vector3.zero)
    //            {
    //                lastAxisValue = axisVal;
    //            }
    //            else if (axisVal != Vector3.zero && axisVal.magnitude > lastAxisValue.magnitude)
    //            {
    //                lastAxisValue = axisVal;
    //            }
    //        }
    //    }
    //    return lastAxisValue;
    //}


    public enum InputAxis
    {
        None,
        LeftThumbStickAxis,
        LeftTouchPadAxis,
        RightThumbStickAxis,
        RightTouchPadAxis
    }
}
