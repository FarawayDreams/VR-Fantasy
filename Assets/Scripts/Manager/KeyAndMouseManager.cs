//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Controls for the non-VR debug camera
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
	//-------------------------------------------------------------------------
	[RequireComponent(typeof(Camera))]
	public class KeyAndMouseManager: MonoBehaviour
	{
	public float speed = 4.0f;
	public bool showInstructions = true;

	private Vector3 startEulerAngles;
	private Vector3 startMousePosition;
	private float realTime;
	public LineRenderer line;
	public GameObject DefaultPoint;
	Vector3 target;
	Vector3 StartPoint;
	public Vector3 EndPoint;
	private RaycastHit hit;
	public float LightLength;
	public bool isLeftClick;
	public bool isRightClick;
	public float MaxLength;
	public GameObject Sphere;
		//-------------------------------------------------
		void OnEnable()
		{
			realTime = Time.realtimeSinceStartup;
		}
        private void Awake()
        {
			LightLength = 5;
		MaxLength = 10;
		isRightClick = false;
        }

        //-------------------------------------------------
        void Update()
		{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		#region ¼üÅÌ¿ØÖÆ
		float forward = 0.0f;
			if (Input.GetKey(KeyCode.W))
			{
				forward += 1.0f;
			}
			if (Input.GetKey(KeyCode.S))
			{
				forward -= 1.0f;
			}

			if (Input.GetKey(KeyCode.E))
			{
				transform.localEulerAngles = startEulerAngles + new Vector3(-1, 0, 0);
			}
			if (Input.GetKey(KeyCode.Q))
			{
				transform.localEulerAngles = startEulerAngles + new Vector3(1, 0, 0);
			}

			float right = 0.0f;
			startEulerAngles = transform.localEulerAngles;
			if (Input.GetKey(KeyCode.D))
			{
				transform.localEulerAngles = startEulerAngles + new Vector3(0, 1, 0);
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.localEulerAngles = startEulerAngles - new Vector3(0, 1, 0);
			}

			float currentSpeed = speed;
			

			float realTimeNow = Time.realtimeSinceStartup;
			float deltaRealTime = realTimeNow - realTime;
			realTime = realTimeNow;

			Vector3 delta = new Vector3(right, 0, forward) * currentSpeed * deltaRealTime;

			transform.position += transform.TransformDirection(delta);
		#endregion
		#region Êó±ê¿ØÖÆ
			#region ×ó¼ü
			if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit)&&isRightClick==false)
			{
				isLeftClick = true;
				line.enabled = true;
				target = hit.point;
				StartPoint = DefaultPoint.transform.position;
				EndPoint = (target - StartPoint).normalized * LightLength + StartPoint;
				line.SetPositions(new Vector3[] { StartPoint, EndPoint });
			}
			if (Input.GetMouseButtonUp(0))
			{
				line.enabled = false;
				isLeftClick = false;
			}
			#endregion
			#region ¹öÂÖ
			if (Input.GetAxis("Mouse ScrollWheel") < 0 && LightLength > 1)
			{
				LightLength -= 0.5f;
			}
			if (Input.GetAxis("Mouse ScrollWheel") > 0 && LightLength < MaxLength)
			{
				LightLength += 0.5f;
			}
			#endregion
			#region ÓÒ¼ü
			if (Input.GetMouseButton(1) && Physics.Raycast(ray, out hit) && Sphere.activeSelf == false)
			{
				isRightClick = true;
				line.enabled = true;
				target = hit.point;
				StartPoint = DefaultPoint.transform.position;
				EndPoint = (target - StartPoint).normalized * LightLength + StartPoint;
				line.SetPositions(new Vector3[] { StartPoint, EndPoint });
				Sphere.SetActive(true);
				Sphere.transform.position = EndPoint;
			}
			if (Input.GetMouseButtonUp(1))
			{
				line.enabled = false;
			}
			#endregion
        #endregion
    }

    //-------------------------------------------------
    void OnGUI()
		{
			if (showInstructions)
			{
				GUI.Label(new Rect(10.0f, 10.0f, 600.0f, 400.0f),
					"WASD EQ to translate the camera\n");
			}
		}
	}
