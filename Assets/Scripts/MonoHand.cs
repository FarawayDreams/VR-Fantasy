using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MonoHand : MonoBehaviour
{
    public float toDistance;
    public float deltaDistance;
    private SteamVR_Action_Boolean shorter = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("shorter");
    private SteamVR_Action_Boolean longer = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("longer");
    private SteamVR_Action_Boolean myMove = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("myMove");
    public SteamVR_Behaviour_Pose pose;
    public Vector3 endPoint;
    public float startFromHand;
    private RaycastHit hit;
    private LineRenderer line;

    private void Start()
    {
        //SteamVR_Input.GetActionSet("default").Deactivate();
        SteamVR_Input.GetActionSet("fantasy").Activate();
        line = GetComponent<LineRenderer>();
        shorter = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("shorter");
        longer = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("longer");
        myMove = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("myMove");
    }

    private void FixedUpdate()
    {
        if(shorter.GetState(pose.inputSource))
        {
            toDistance -= deltaDistance * Time.fixedDeltaTime;
        }
        if(longer.GetState(pose.inputSource))
        {
            toDistance += deltaDistance * Time.fixedDeltaTime;
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, toDistance,8))
        {
            //Debug.Log(hit.collider.gameObject.name);
            endPoint = hit.point;
        }
        else
        {
            endPoint = transform.position + transform.forward * toDistance;
        }
        if (myMove.GetState(pose.inputSource))
        {
            //Debug.Log(endPoint+" "+MonoPlayer.instance.transform.position);
            MonoPlayer.instance.moveUnit(endPoint);
        }
        RenderLine(endPoint);
    }

    private void RenderLine(Vector3 end)
    {
        line.positionCount = 2;
        line.SetPosition(0, transform.position + transform.forward * startFromHand);
        line.SetPosition(1, end);
    }
}
