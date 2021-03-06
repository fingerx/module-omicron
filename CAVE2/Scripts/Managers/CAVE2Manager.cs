﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVE2 : MonoBehaviour
{
    public enum Axis
    {
        None, LeftAnalogStickLR, LeftAnalogStickUD, RightAnalogStickLR, RightAnalogStickUD, AnalogTriggerL, AnalogTriggerR,
        LeftAnalogStickLR_Inverted, LeftAnalogStickUD_Inverted, RightAnalogStickLR_Inverted, RightAnalogStickUD_Inverted, AnalogTriggerL_Inverted, AnalogTriggerR_Inverted
    };
    public enum Button { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, SpecialButton1, SpecialButton2, SpecialButton3, ButtonUp, ButtonDown, ButtonLeft, ButtonRight, None };
    public enum InteractionType { Any, Pointing, Touching }

    public static CAVE2InputManager Input;
    public static CAVE2RPCManager RpcManager;

    public struct WandEvent
    {
        public CAVE2PlayerIdentity playerID;
        public int wandID;
        public Button button;
        public InteractionType interactionType;

        public WandEvent(CAVE2PlayerIdentity id, int wand, Button b, InteractionType t)
        {
            playerID = id;
            wandID = wand;
            button = b;
            interactionType = t;
        }
    };

    // CAVE2 Tracking Management -------------------------------------------------------------------
    public static Vector3 GetHeadPosition(int ID)
    {
        return CAVE2Manager.GetHeadPosition(ID);
    }

    public static Quaternion GetHeadRotation(int ID)
    {
        return CAVE2Manager.GetHeadRotation(ID);
    }

    public static Vector3 GetWandPosition(int ID)
    {
        return CAVE2Manager.GetWandPosition(ID);
    }

    public static Quaternion GetWandRotation(int ID)
    {
        return CAVE2Manager.GetWandRotation(ID);
    }

    public static Vector3 GetMocapPosition(int ID)
    {
        return CAVE2Manager.GetMocapPosition(ID);
    }

    public static Quaternion GetMocapRotation(int ID)
    {
        return CAVE2Manager.GetMocapRotation(ID);
    }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Input Management ----------------------------------------------------------------------
    public static bool UsingOmicronServer()
    {
        return CAVE2Manager.UsingOmicronServer();
    }

    public static float GetAxis(int wandID, CAVE2.Axis axis)
    {
        return CAVE2Manager.GetAxis(wandID, axis);
    }

    public static bool GetButton(int wandID, CAVE2.Button button)
    {
        return CAVE2Manager.GetButton(wandID, button);
    }

    public static bool GetButtonDown(int wandID, CAVE2.Button button)
    {
        return CAVE2Manager.GetButtonDown(wandID, button);
    }

    public static bool GetButtonUp(int wandID, CAVE2.Button button)
    {
        return CAVE2Manager.GetButtonUp(wandID, button);
    }

    public static OmicronController.ButtonState GetButtonState(int wandID, CAVE2.Button button)
    {
        return CAVE2Manager.GetButtonState(wandID, button);
    }

    public static CAVE2.Button GetReal3DToCAVE2Button(string name)
    {
        return CAVE2Manager.GetReal3DToCAVE2Button(name);
    }

    public static CAVE2.Axis GetReal3DToCAVE2Axis(string name)
    {
        return CAVE2Manager.GetReal3DToCAVE2Axis(name);
    }

    public static string CAVE2ToGetReal3DButton(CAVE2.Button name)
    {
        return CAVE2Manager.CAVE2ToGetReal3DButton(name);
    }

    public static string CAVE2ToGetReal3DAxis(CAVE2.Axis name)
    {
        return CAVE2Manager.CAVE2ToGetReal3DAxis(name);
    }

    // ---------------------------------------------------------------------------------------------


    // CAVE2 Cluster Management --------------------------------------------------------------------
    public static CAVE2Manager GetCAVE2Manager()
    {
        return CAVE2Manager.GetCAVE2Manager();
    }

    public static bool IsMaster()
    {
        return CAVE2Manager.IsMaster();
    }

    public static bool OnCAVE2Display()
    {
        return CAVE2Manager.OnCAVE2Display();
    }

    public static bool UsingGetReal3D()
    {
        return CAVE2Manager.UsingGetReal3D();
    }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Simulator Management ------------------------------------------------------------------
    public static bool IsSimulatorMode()
    {
        return CAVE2Manager.IsSimulatorMode();
    }

    public static void RegisterHeadObject(int headID, GameObject gameobject)
    {
        CAVE2Manager.GetCAVE2Manager().RegisterHeadObject(headID, gameobject);
    }

    public static void RegisterWandObject(int wandID, GameObject gameobject)
    {
        CAVE2Manager.GetCAVE2Manager().RegisterWandObject(wandID, gameobject);
    }

    public static bool IsHeadRegistered(int headID, GameObject gameobject)
    {
        return CAVE2Manager.GetCAVE2Manager().IsHeadRegistered(headID, gameobject);
    }

    public static bool IsWandRegistered(int wandID, GameObject gameobject)
    {
        return CAVE2Manager.GetCAVE2Manager().IsWandRegistered(wandID, gameobject);
    }
    // ---------------------------------------------------------------------------------------------

    // CAVE2 Player Management ---------------------------------------------------------------------
    public static GameObject GetHeadObject(int ID)
    {
        return CAVE2Manager.GetCAVE2Manager().GetHeadObject(ID);
    }

    public static GameObject GetWandObject(int ID)
    {
        return CAVE2Manager.GetCAVE2Manager().GetWandObject(ID);
    }

    public static void ShowDebugCanvas(bool value)
    {
        CAVE2Manager.GetCAVE2Manager().showDebugCanvas = value;
    }
    // ---------------------------------------------------------------------------------------------

    public static void AddCameraController(CAVE2CameraController cam)
    {
        CAVE2Manager.AddCameraController(cam);
    }
    public static CAVE2CameraController GetCameraController()
    {
        return GetCAVE2Manager().mainCameraController;
    }

    public static void AddPlayerController(int id, GameObject g)
    {
        GetCAVE2Manager().AddPlayerController(id, g);
    }

    public static GameObject GetPlayerController(int id)
    {
        return GetCAVE2Manager().GetPlayerController(id);
    }

    public static int GetPlayerControllerCount()
    {
        return GetCAVE2Manager().GetPlayerControllerCount();
    }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Synchronization Management ------------------------------------------------------------
    public static void BroadcastMessage(string targetObjectName, string methodName)
    {
        GetCAVE2Manager().BroadcastMessage(targetObjectName, methodName);
    }

    public static void BroadcastMessage(string targetObjectName, string methodName, object param)
    {
        GetCAVE2Manager().BroadcastMessage(targetObjectName, methodName, param);
    }

    public static void BroadcastMessage(string targetObjectName, string methodName, object param, object param2)
    {
        GetCAVE2Manager().BroadcastMessage(targetObjectName, methodName, param, param2);
    }

    public static void BroadcastMessage(string targetObjectName, string methodName, object param, object param2, object param3)
    {
        GetCAVE2Manager().BroadcastMessage(targetObjectName, methodName, param, param2, param3);
    }

    public static void BroadcastMessage(string targetObjectName, string methodName, object param, object param2, object param3, object param4)
    {
        GetCAVE2Manager().BroadcastMessage(targetObjectName, methodName, param, param2, param3, param4);
    }

    public static void Destroy(string targetObjectName)
    {
        GetCAVE2Manager().Destroy(targetObjectName);

    }

    public static void LoadScene(int id)
    {
        RpcManager.BroadcastMessage(GetCAVE2Manager().name, "CAVE2LoadScene", id);
    }

    public static void LoadScene(string id)
    {
        RpcManager.BroadcastMessage(GetCAVE2Manager().name, "CAVE2LoadScene", id);
    }

    public static void LoadSceneAsync(int id)
    {
        RpcManager.BroadcastMessage(GetCAVE2Manager().name, "CAVE2LoadSceneAsync", id);
    }

    public static void LoadSceneAsync(string id)
    {
        RpcManager.BroadcastMessage(GetCAVE2Manager().name, "CAVE2LoadSceneAsync", id);
    }

    // ---------------------------------------------------------------------------------------------
}
[RequireComponent(typeof(CAVE2AdvancedTrackingSimulator))]
[RequireComponent(typeof(CAVE2InputManager))]
[RequireComponent(typeof(CAVE2RPCManager))]

public class CAVE2Manager : MonoBehaviour {

static CAVE2Manager CAVE2Manager_Instance;
    CAVE2InputManager inputManager;

    static string machineName;

    public int head1MocapID = 0;
    public int wand1MocapID = 1;
    public int wand1ControllerID = 1;

    public int head2MocapID = 2;
    public int wand2MocapID = 3;
    public int wand2ControllerID = 2;

    ArrayList cameraControllers;
    public CAVE2CameraController mainCameraController;
    public Hashtable headObjects = new Hashtable();
    public Hashtable wandObjects = new Hashtable();

    public Hashtable playerControllers = new Hashtable();

    // Simulator
    public bool simulatorMode;
    public bool mocapEmulation;
    public bool keyboardEventEmulation;
    public bool wandMousePointerEmulation;
    public bool usingKinectTrackingSimulator;
    
    public Vector3 simulatorHeadPosition = new Vector3(0.0f, 1.6f, 0.0f);
    public Vector3 simulatorHeadRotation = new Vector3(0.0f, 0.0f, 0.0f);

    public Vector3 simulatorWandPosition = new Vector3(0.16f, 1.43f, 0.4f);
    public Vector3 simulatorWandRotation = new Vector3(0.0f, 0.0f, 0.0f);

    // CAVE2 Simulator to Wand button bindings
    public string wandSimulatorAnalogUD = "Vertical";
    public string wandSimulatorAnalogLR = "Horizontal";
    public string wandSimulatorButton3 = "Fire1"; // PS3 Navigation Cross
    public string wandSimulatorButton2 = "Fire2"; // PS3 Navigation Circle
    public KeyCode wandSimulatorDPadUp = KeyCode.UpArrow;
    public KeyCode wandSimulatorDPadDown = KeyCode.DownArrow;
    public KeyCode wandSimulatorDPadLeft = KeyCode.LeftArrow;
    public KeyCode wandSimulatorDPadRight = KeyCode.RightArrow;
    public KeyCode wandSimulatorButton5 = KeyCode.Space; // PS3 Navigation L1
    public string wandSimulatorButton6 = "Fire3"; // PS3 Navigation L3
    public KeyCode wandSimulatorButton7 = KeyCode.LeftShift; // PS3 Navigation L2

    public enum TrackerEmulated { CAVE, Head, Wand };
    public enum TrackerEmulationMode { Pointer, Translate, Rotate, TranslateForward, TranslateVertical, RotatePitchYaw, RotateRoll };
    // string[] trackerEmuStrings = { "CAVE", "Head", "Wand1" };
    // string[] trackerEmuModeStrings = { "Pointer", "Translate", "Rotate" };

    // TrackerEmulationMode defaultWandEmulationMode = TrackerEmulationMode.Pointer;
    // TrackerEmulationMode toggleWandEmulationMode = TrackerEmulationMode.TranslateVertical;
    public TrackerEmulationMode wandEmulationMode = TrackerEmulationMode.Pointer;

    // bool wandModeToggled = false;
    Vector3 mouseLastPos;
    // Vector3 mouseDeltaPos;

    public bool showDebugCanvas;
    public GameObject debugCanvas;

    CAVE2RPCManager rpcManager;

    [SerializeField]
    bool simulateAsClient;

    public void Init()
    {
        CAVE2Manager_Instance = this;
        inputManager = GetComponent<CAVE2InputManager>();
        
        CAVE2.Input = inputManager;
        CAVE2.RpcManager = GetComponent<CAVE2RPCManager>();

        CAVE2.Input.Init();

        cameraControllers = new ArrayList();

        machineName = System.Environment.MachineName;
        Debug.Log(this.GetType().Name + ">\t initialized on " + machineName);

        Random.InitState(1138);
    }
    void Start()
    {
        Init();

        if ( OnCAVE2Display() || OnCAVE2Master() )
        {
#if UNITY_EDITOR
#else
            simulatorMode = false;
            mocapEmulation = false;
            keyboardEventEmulation = false;
            wandMousePointerEmulation = false;
            usingKinectTrackingSimulator = false;
#endif
        }
    }

    void Update()
    {
        if(CAVE2Manager_Instance == null)
        {
            CAVE2Manager_Instance = this;
        }

        if( !UsingGetReal3D() && !UnityEngine.VR.VRSettings.enabled && (mocapEmulation || usingKinectTrackingSimulator) )
        {
            if (mainCameraController)
            {
                mainCameraController.GetMainCamera().transform.localPosition = simulatorHeadPosition;
                mainCameraController.GetMainCamera().transform.localEulerAngles = simulatorHeadRotation;
            }
        }

        if( debugCanvas )
        {
            debugCanvas.SetActive(showDebugCanvas);
        }
    }

    // CAVE2 Tracking Management -------------------------------------------------------------------
    public static Vector3 GetHeadPosition(int ID)
    {
        int sensorID = 0;
        Vector3 pos = Vector3.zero;

        if (ID == 1)
        {
            sensorID = GetCAVE2Manager().head1MocapID;
            
        }
        pos = CAVE2.Input.GetMocapPosition(sensorID);
        return pos;
    }

    public static Quaternion GetHeadRotation(int ID)
    {
        int sensorID = 0;
        Quaternion rot = Quaternion.identity;
        if (ID == 1)
        {
            sensorID = GetCAVE2Manager().head1MocapID;
        }

        rot = CAVE2.Input.GetMocapRotation(sensorID);
        return rot;
    }

    public static Vector3 GetWandPosition(int ID)
    {
        return CAVE2.Input.GetWandPosition(ID);
    }

    public static Quaternion GetWandRotation(int ID)
    {
        return CAVE2.Input.GetWandRotation(ID);
    }

    public static Vector3 GetMocapPosition(int ID)
    {
        return CAVE2.Input.GetMocapPosition(ID);
    }

    public static Quaternion GetMocapRotation(int ID)
    {
        return CAVE2.Input.GetMocapRotation(ID);
    }

    public static CAVE2CameraController GetCameraController()
    {
        return CAVE2.GetCAVE2Manager().mainCameraController;
    }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Input Management ----------------------------------------------------------------------
    public static bool UsingOmicronServer()
    {
        OmicronManager omicronManager = GetCAVE2Manager().GetComponent<OmicronManager>();
        if (omicronManager)
            return omicronManager.IsConnectedToServer() || omicronManager.IsReceivingDataFromMaster();
        else
            return false;
    }

    public static float GetAxis(int wandID, CAVE2.Axis axis)
    {
        return CAVE2.Input.GetAxis(wandID, axis);
    }

    public static bool GetButton(int wandID, CAVE2.Button button)
    {
        return CAVE2.Input.GetButton(wandID, button);
    }

    public static bool GetButtonDown(int wandID, CAVE2.Button button)
    {
        return CAVE2.Input.GetButtonDown(wandID, button);
    }

    public static bool GetButtonUp(int wandID, CAVE2.Button button)
    {
        return CAVE2.Input.GetButtonUp(wandID, button);
    }

    public static OmicronController.ButtonState GetButtonState(int wandID, CAVE2.Button button)
    {
        return CAVE2.Input.GetButtonState(wandID, button);
    }

    /*
          <map_button index = "2" name="WandButton"/> <!-- B / Circle --> 
          <map_button index = "3" name="ChangeWand"/> <!-- X / Square --> 
          <map_button index = "6" name="Reset"/> <!-- A / Cross -->
          <map_button index = "4" name="Jump"/> <!-- Y / Triangle -->
          <map_button index = "5" name="WandLook" /> <!-- RB / R1-->
          <map_button index = "1" name="NavSpeed" /> <!-- LB / L1-->
          <map_button index = "7" name="WandDrive" /> <!-- LT / L2 --> 
          <map_button index = "8" name="RT" /> <!-- RT / R2 --> 
          <map_button index = "9" name="L3" /> <!-- L3(Left analog button)-->
          <map_button index = "10" name="R3" /> <!-- R3(Right analog button)-->
          <map_button index = "11" name="Back" /> <!-- Back / Select-->
          <map_button index = "12" name="Start" /> <!-- Start -->
          
          <map_valuator dead_zone = ".1" index="1" name="Yaw"/>
          <map_valuator dead_zone = ".1" index="2" name="Forward"/>
          <map_valuator dead_zone = ".1" index="3" name="Strafe" />
          <map_valuator dead_zone = ".1" index="4" name="Pitch" />
          <map_valuator dead_zone = ".1" index="5" name="DPadLR" />
          <map_valuator dead_zone = ".1" index="6" name="DPadUD" />

          <map_tracker index = "1" name="Head" />
          <map_tracker index = "3" name="Wand" />
*/
    public static CAVE2.Button GetReal3DToCAVE2Button(string name)
    {
        switch(name)
        {
            case "WandButton": return CAVE2.Button.Button3;
            case "ChangeWand": return CAVE2.Button.Button2;
            case "Reset": return CAVE2.Button.Button8;
            case "Jump": return CAVE2.Button.Button1;
            case "WandLook": return CAVE2.Button.Button5;
            case "NavSpeed": return CAVE2.Button.Button4;
            case "WandDrive": return CAVE2.Button.Button7;
            case "RT": return CAVE2.Button.SpecialButton3;
            case "L3": return CAVE2.Button.Button6;
            case "R3": return CAVE2.Button.Button9;
            case "Back": return CAVE2.Button.SpecialButton1;
            case "Start": return CAVE2.Button.SpecialButton2;
        }
        return CAVE2.Button.None;
    }

    public static CAVE2.Axis GetReal3DToCAVE2Axis(string name)
    {
        switch (name)
        {
            case "Yaw": return CAVE2.Axis.LeftAnalogStickLR;
            case "Forward": return CAVE2.Axis.LeftAnalogStickUD;
            case "Strafe": return CAVE2.Axis.RightAnalogStickLR;
            case "Pitch": return CAVE2.Axis.RightAnalogStickUD;
        }
        return CAVE2.Axis.None;
    }

    public static string CAVE2ToGetReal3DButton(CAVE2.Button name)
    {
        switch (name)
        {
            case CAVE2.Button.Button3: return "WandButton";
            case CAVE2.Button.Button2: return "ChangeWand";
            case CAVE2.Button.Button8: return "Reset";
            case CAVE2.Button.Button1: return "Jump";
            case CAVE2.Button.Button5: return "WandLook";
            case CAVE2.Button.Button4: return "NavSpeed";
            case CAVE2.Button.Button7: return "WandDrive";
            case CAVE2.Button.SpecialButton3: return "RT";
            case CAVE2.Button.Button6: return "L3";
            case CAVE2.Button.Button9: return "R3";
            case CAVE2.Button.SpecialButton1: return "Back";
            case CAVE2.Button.SpecialButton2: return "Start";

            case CAVE2.Button.ButtonUp: return "DPadUD";
            case CAVE2.Button.ButtonDown: return "DPadUD";
            case CAVE2.Button.ButtonLeft: return "DPadLR";
            case CAVE2.Button.ButtonRight: return "DPadLR";
        }
        return "";
    }

    public static string CAVE2ToGetReal3DAxis(CAVE2.Axis name)
    {
        switch (name)
        {
            case CAVE2.Axis.LeftAnalogStickLR: return "Yaw";
            case CAVE2.Axis.LeftAnalogStickUD: return "Forward";
            case CAVE2.Axis.RightAnalogStickLR: return "Strafe";
            case CAVE2.Axis.RightAnalogStickUD: return "Pitch";
        }
        return "";
    }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Cluster Management --------------------------------------------------------------------
    public static CAVE2Manager GetCAVE2Manager()
    {
        if(CAVE2Manager_Instance == null)
        {
            GameObject cave2Manager = GameObject.Find("CAVE2-Manager");
            CAVE2Manager_Instance = cave2Manager.GetComponent<CAVE2Manager>();

            if (CAVE2Manager_Instance == null)
            {
                Debug.LogWarning("CAVE2Manager_Instance is NULL - SHOULD NOT HAPPEN!");
            }
            else
            {
                Debug.LogWarning("Reintializing CAVE2Manager_Instance");
                CAVE2Manager_Instance.Init();
            }
            //GameObject cave2Manager = new GameObject("CAVE2-Manager");
            //cave2Manager.AddComponent<OmicronManager>();
            //CAVE2Manager_Instance = cave2Manager.AddComponent<CAVE2Manager>();
            //cave2Manager.AddComponent<CAVE2InputManager>();
            //cave2Manager.AddComponent<CAVE2AdvancedTrackingSimulator>();
            //cave2Manager.AddComponent<CAVE2RPCManager>();
        }
        return CAVE2Manager_Instance;
    }

    public static bool IsMaster()
    {
        if (CAVE2Manager_Instance.simulateAsClient)
            return false;
#if USING_GETREAL3D
		return getReal3D.Cluster.isMaster;
#else
        if (machineName.Contains("LYRA") && !machineName.Equals("LYRA-WIN"))
            return false;
        else // Assumes on LYRA-WIN or development machine
            return true;
#endif
    }

    public static bool OnCAVE2Display()
    {
        if (CAVE2Manager_Instance.simulateAsClient)
            return true;

        machineName = System.Environment.MachineName;
        if (machineName.Contains("LYRA") && !IsMaster())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool OnCAVE2Master()
    {
        if (CAVE2Manager_Instance.simulateAsClient)
            return true;

        machineName = System.Environment.MachineName;
        if (machineName.Contains("LYRA-WIN") )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool UsingGetReal3D()
    {
#if USING_GETREAL3D
		return true;
#else
        return false;
#endif
    }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Simulator Management ------------------------------------------------------------------
    public static bool IsSimulatorMode()
    {
        return GetCAVE2Manager().simulatorMode;
    }

    // public Vector3 GetMouseDeltaPos()
    // {
    //     return mouseDeltaPos;
    // }
    // ---------------------------------------------------------------------------------------------


    // CAVE2 Player Management ---------------------------------------------------------------------
    public static void AddCameraController(CAVE2CameraController cam)
    {
        if (GetCAVE2Manager().cameraControllers == null)
        {
            GetCAVE2Manager().cameraControllers = new ArrayList();
        }

        if(GetCAVE2Manager().cameraControllers.Count == 0)
            GetCAVE2Manager().mainCameraController = cam;

        GetCAVE2Manager().cameraControllers.Add(cam);
    }

    public static CAVE2CameraController GetCameraController(int cam)
    {
        if (cam >= 0 && cam < GetCAVE2Manager().cameraControllers.Count - 1)
            return (CAVE2CameraController)GetCAVE2Manager().cameraControllers[cam];
        else
            return null;
    }

    public void RegisterHeadObject(int ID, GameObject gameObject)
    {
        headObjects[ID] = gameObject;
    }

    public void RegisterWandObject(int ID, GameObject gameObject)
    {
        wandObjects[ID] = gameObject;
    }

    public bool IsHeadRegistered(int ID, GameObject gameObject)
    {
        if ((GameObject)headObjects[ID] == gameObject)
            return true;
        return false;
    }

    public bool IsWandRegistered(int ID, GameObject gameObject)
    {
        if ((GameObject)wandObjects[ID] == gameObject)
            return true;
        return false;
    }

    public GameObject GetHeadObject(int ID)
    {
        return (GameObject)headObjects[ID];
    }

    public GameObject GetWandObject(int ID)
    {
        return (GameObject)wandObjects[ID];
    }

    public void AddPlayerController(int id, GameObject g)
    {
        playerControllers[id] = g;
    }

    public GameObject GetPlayerController(int id)
    {
        GameObject player = (GameObject)playerControllers[id];
        return player;
    }

    public int GetPlayerControllerCount()
    {
        return playerControllers.Count;
    }

    // ---------------------------------------------------------------------------------------------


    // CAVE2 Synchronization Management ------------------------------------------------------------
    public void BroadcastMessage(string targetObjectName, string methodName, object param)
    {
        CAVE2.RpcManager.BroadcastMessage(targetObjectName, methodName, param);
    }

    public void BroadcastMessage(string targetObjectName, string methodName, object param, object param2)
    {
        CAVE2.RpcManager.BroadcastMessage(targetObjectName, methodName, param, param2);
    }

    public void BroadcastMessage(string targetObjectName, string methodName, object param, object param2, object param3)
    {
        CAVE2.RpcManager.BroadcastMessage(targetObjectName, methodName, param, param2, param3);
    }

    public void BroadcastMessage(string targetObjectName, string methodName, object param, object param2, object param3, object param4)
    {
        CAVE2.RpcManager.BroadcastMessage(targetObjectName, methodName, param, param2, param3, param4);
    }

    public void BroadcastMessage(string targetObjectName, string methodName)
    {
        CAVE2.RpcManager.BroadcastMessage(targetObjectName, methodName, 0);
    }

    public void Destroy(string targetObjectName)
    {
        CAVE2.RpcManager.Destroy(targetObjectName);
    }

    public void CAVE2LoadScene(int id)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(id);
        Debug.Log(this.GetType().Name + ">\t CAVE2 Load Scene: " + id);
    }

    public void CAVE2LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        Debug.Log(this.GetType().Name + ">\t CAVE2 Load Scene: " + sceneName);
    }

    public void CAVE2LoadSceneAsync(int id)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(id);
        Debug.Log(this.GetType().Name + ">\t CAVE2 Load Scene (Async): " + id);
    }

    public void CAVE2LoadSceneAsync(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        Debug.Log(this.GetType().Name + ">\t CAVE2 Load Scene (Async): " + sceneName);
    }
}
