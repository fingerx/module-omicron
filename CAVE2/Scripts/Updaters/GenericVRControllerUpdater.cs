﻿using omicron;
using UnityEngine;
using UnityEngine.VR;

public class GenericVRControllerUpdater : MonoBehaviour {

    public enum VRModel { None, Vive, Oculus };

    // [SerializeField]
    // VRModel vrModel = VRModel.None;

    [SerializeField]
    string vrModelString;

    [SerializeField]
    bool debug = false;

    [Header("Wand 1 (Left)")]
    [SerializeField]
    Vector3 wand1_position;

    [SerializeField]
    Quaternion wand1_rotation;

    [SerializeField]
    Vector2 wand1_analog1;

    [SerializeField]
    Vector2 wand1_analog2;

    [SerializeField]
    Vector2 wand1_analog3;

    [SerializeField]
    int wand1_flags;

    [Header("Wand 2 (Right)")]
    [SerializeField]
    Vector3 wand2_position;

    [SerializeField]
    Quaternion wand2_rotation;

    [SerializeField]
    Vector2 wand2_analog1;

    [SerializeField]
    Vector2 wand2_analog2;

    [SerializeField]
    Vector2 wand2_analog3;

    [SerializeField]
    int wand2_flags;

    // Use this for initialization
    void Start () {
        vrModelString = VRDevice.model;

        if (vrModelString == "Vive MV")
        {
            // vrModel = VRModel.Vive;
        }
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_5_5_OR_NEWER
        wand1_position = InputTracking.GetLocalPosition(VRNode.LeftHand);
        wand1_rotation = InputTracking.GetLocalRotation(VRNode.LeftHand);

        wand2_position = InputTracking.GetLocalPosition(VRNode.RightHand);
        wand2_rotation = InputTracking.GetLocalRotation(VRNode.RightHand);
#endif
        ProcessVRInput();
    }

    // Copied from CAVE2InputManager.cs
    void ProcessVRInput ()
    {
        // VR Left Controller (Keycode.Joystick1)
        // Button2 - Menu
        // Button8 - Thumbstick Press
        // Button16 - Thumbstick Touch
        // Button14 - Index Trigger
        // Axis1 - Thumbstick Horz
        // Axis2 - Thumbstick Vert
        // Axis9 - Index Trigger
        // Axis11 - Hand Trigger
        wand1_flags = 0;
        wand2_flags = 0;

        // Oculus Touch Left: Button.Three / X (Press)
        // Vive Left: Menu Button
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            wand1_flags += (int)EventBase.Flags.Button2;
            if (debug)
                Debug.Log("Joystick1Button2");
        }

        // Oculus Touch Left: Button.Four / Y (Press)
        if (Input.GetKey(KeyCode.JoystickButton3))
        {
            wand1_flags += (int)EventBase.Flags.Button3;
            if (debug)
                Debug.Log("Joystick1Button3");
        }

        // Oculus Touch Left: Button.Start / Menu
        if (Input.GetKey(KeyCode.JoystickButton7))
        {
            if (debug)
                Debug.Log("Joystick1Button7");
        }

        // Oculus Touch Left: Analog Stick (Press)
        if (Input.GetKey(KeyCode.JoystickButton8))
        {
            wand1_flags += (int)EventBase.Flags.Button6;
            if (debug)
                Debug.Log("Joystick1Button8");
        }

        // Oculus Touch Left: Button.Three / X (Touch)
        if (Input.GetKey(KeyCode.JoystickButton12))
        {
            if (debug)
                Debug.Log("Joystick1Button12");
        }

        // Oculus Touch Left: Button.Four / Y (Touch)
        if (Input.GetKey(KeyCode.JoystickButton13))
        {
            if (debug)
                Debug.Log("Joystick1Button13");
        }

        // Oculus Touch Left: IndexTrigger (Touch)
        if (Input.GetKey(KeyCode.JoystickButton14))
        {
            if (debug)
                Debug.Log("Joystick1Button14");
        }

        // Oculus Touch Left: ThumbRest (Touch)
        if (Input.GetKey(KeyCode.JoystickButton18))
        {
            if (debug)
                Debug.Log("Joystick1Button18");
        }

        /*
         * Grip L/R are not default Unity InputManager axis, but 
         * are required for proper mapping of VR controller buttons.
         * The following can be added to the Axis. All other fields
         * are blank unless otherwise specified
         * 
         * Name: Trigger L
         * Gravity: 3
         * Dead: 0.001
         * Sensitivity: 3
         * Type: Joystick Axis
         * Axis: 9th axis (Joysticks)
         * JoyNum: Get Motion from all Joysticks
         *
         * Name: Trigger R
         * Gravity: 3
         * Dead: 0.001
         * Sensitivity: 3
         * Type: Joystick Axis
         * Axis: 10th axis (Joysticks)
         * JoyNum: Get Motion from all Joysticks
         * 
         * Name: Grip L
         * Gravity: 3
         * Dead: 0.001
         * Sensitivity: 3
         * Type: Joystick Axis
         * Axis: 11th axis (Joysticks)
         * JoyNum: Get Motion from all Joysticks
         * 
         * Name: Grip R
         * Gravity: 3
         * Dead: 0.001
         * Sensitivity: 3
         * Type: Joystick Axis
         * Axis: 12th axis (Joysticks)
         * JoyNum: Get Motion from all Joysticks
         */
        // Oculus Touch Left: IndexTrigger (Press)
        wand1_analog3.y = Input.GetAxis("Trigger L");
        if (Input.GetAxis("Trigger L") > 0.1f)
        {
            wand1_flags += (int)EventBase.Flags.Button5;

        }

        // Oculus Touch Left: HandTrigger (Press)
        wand1_analog3.x = Input.GetAxis("Grip L");
        if (Input.GetAxis("Grip L") > 0.1f)
        {
            wand1_flags += (int)EventBase.Flags.Button7;
        }

        wand2_analog3.x = Input.GetAxis("Grip R");
        if (Input.GetAxis("Grip R") > 0.1f)
        {
            wand2_flags += (int)EventBase.Flags.Button7;
        }

        wand2_analog3.y = Input.GetAxis("Trigger R");
        if (Input.GetAxis("Trigger R") > 0.1f)
        {
            wand2_flags += (int)EventBase.Flags.Button5;

        }

        // VR Right Controller (Keycode.Joystick2)
        // Button0 - Menu
        // Button9 - Thumbstick Press
        // Button17 - Thumbstick Touch
        // Button15 - Index Trigger
        // Axis4 - Thumbstick Horz
        // Axis5 - Thumbstick Vert
        // Axis10 - Index Trigger
        // Axis12 - Hand Trigger

        // Oculus Touch Right: Button.One / A (Press)
        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            wand2_flags += (int)EventBase.Flags.Button2;
            if (debug)
                Debug.Log("Joystick2Button0");
        }

        // Oculus Touch Right: Button.Two / B (Press)
        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            wand2_flags += (int)EventBase.Flags.Button3;
            if (debug)
                Debug.Log("Joystick2Button1");
        }

        // Oculus Touch Right: Oculus Button Reserved

        // Oculus Touch Right: Analog Stick (Press)
        if (Input.GetKey(KeyCode.JoystickButton9))
        {
            wand2_flags += (int)EventBase.Flags.Button6;
            if (debug)
                Debug.Log("Joystick2Button9");
        }

        // Oculus Touch Right: Button.One / A (Touch)
        if (Input.GetKey(KeyCode.JoystickButton10))
        {
            if (debug)
                Debug.Log("Joystick2Button10");
        }

        // Oculus Touch Right: Button.Two / B (Touch)
        if (Input.GetKey(KeyCode.JoystickButton11))
        {
            if (debug)
                Debug.Log("Joystick2Button11");
        }

        // Oculus Touch Right: IndexTrigger (Touch)
        if (Input.GetKey(KeyCode.JoystickButton15))
        {
            if (debug)
                Debug.Log("Joystick2Button15");
        }

        // Oculus Touch Right: ThumbRest (Touch)
        if (Input.GetKey(KeyCode.JoystickButton19))
        {
            if (debug)
                Debug.Log("Joystick2Button19");
        }

        wand1_analog1 = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        wand2_analog1 = new Vector2(Input.GetAxis("Horizontal2"), -Input.GetAxis("Vertical2"));

        // Oculus Touch Right: Analog (Touch)
        // For CAVE2 simulator purposes, we're treating the right analog as the DPad
        if (Input.GetKey(KeyCode.JoystickButton17) &&
            (Input.GetAxis("Vertical2") != 0 ||
            Input.GetAxis("Horizontal2") != 0)
            )
        {
            /*
             * Horizontal2/Vertical2 are not default Unity InputManager axis, but 
             * are required for proper mapping of the second VR controller pad/analog stick.
             * The following can be added to the Axis. All other fields
             * are blank unless otherwise specified
             * 
             * Name: Horizontal2
             * Gravity: 3
             * Dead: 0.001
             * Sensitivity: 3
             * Type: Joystick Axis
             * Axis: 4th axis (Joysticks)
             * JoyNum: Get Motion from all Joysticks
             * 
             * Name: Vertical2
             * Gravity: 3
             * Dead: 0.001
             * Sensitivity: 3
             * Type: Joystick Axis
             * Axis: 5th axis (Joysticks)
             * JoyNum: Get Motion from all Joysticks
             */
            float padAngle = Mathf.Rad2Deg * Mathf.Atan2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2"));

            if (padAngle < -45 && padAngle > -135)
            {
                wand2_flags += (int)EventBase.Flags.ButtonUp;
            }
            else if (padAngle > -45 && padAngle < 45)
            {
                wand2_flags += (int)EventBase.Flags.ButtonRight;
            }
            else if (padAngle > 45 && padAngle < 135)
            {
                wand2_flags += (int)EventBase.Flags.ButtonDown;
            }
            else if (padAngle < -135 || padAngle > 135)
            {
                wand2_flags += (int)EventBase.Flags.ButtonLeft;
            }
        }
    }
}
