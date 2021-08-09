using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MonoChr : MonoBehaviour
{
    public float myVelocity;
    private SteamVR_Action_Boolean proceed;
    private SteamVR_Action_Boolean backward;
    public SteamVR_Behaviour_Pose pose;
    [HideInInspector]public Transform vrCamera;

    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Input.GetActionSet("fantasy").Activate();
        proceed = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("proceed");
        backward = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("backward");
        vrCamera = GetComponentInChildren<Camera>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(proceed.GetState(pose.inputSource))
        {
            transform.position +=(new Vector3(vrCamera.forward.x, 0, vrCamera.forward.z)).normalized*Time.fixedDeltaTime;
        }
        if(backward.GetState(pose.inputSource))
        {
            transform.position -= (new Vector3(vrCamera.forward.x, 0, vrCamera.forward.z)).normalized * Time.fixedDeltaTime;
        }
    }
}
