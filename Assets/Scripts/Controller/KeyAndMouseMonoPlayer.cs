using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using Valve.VR;

public class KeyAndMouseMonoPlayer : MonoBehaviour
{
    public static KeyAndMouseMonoPlayer instance;
    public float velocity;
    [HideInInspector] public bool controlled;
    public GameObject portal;
    public GameObject aimPos;
    public GameObject player;
    public GameObject truePlayer;
    public GameObject aimPosPlayer;
    public KeyAndMouseManager Destination;
    public float inclineSpeed;
    public float rotateSpeed;
    private float incline;


    // Start is called before the first frame update
    void Start()
    {
        controlled = true;
        instance = this;
        portal.SetActive(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Destination.isLeftClick == true) moveUnit(Destination.EndPoint);
        else GetComponent<Rigidbody>().MovePosition(transform.position);
        if (Destination.isRightClick == true) moveUnit(Destination.Sphere.transform.position);
    }
    public void moveUnit(Vector3 toPlace)
    {
        if (controlled && Vector3.Distance(toPlace, transform.position) > 0.1)
        {
            GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, toPlace, velocity * Time.fixedDeltaTime));
            //transform.forward = Vector3.RotateTowards(transform.forward, toPlace - transform.position, rotateSpeed * Time.fixedDeltaTime,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "dreamPiece": { OnTouchDream(); other.GetComponent<DreamPiece>().Disappear(); break; }
            case "treasurePiece": { OnTouchTreasure(); break; }
            case "portal":
                {
                    //�����ξ���Ƭ������ʹ���½ǵ���ʾ����Ϊ0
                    GlobalData.dreamPieceNum = 0;

                    /*
                     * �˴�Ҫ���һ���ξ���Ƭ�ĺϳɶ���
                     */

                    transform.position = aimPos.transform.position;
                    player.transform.position = aimPosPlayer.transform.position + truePlayer.transform.position - player.transform.position;
                    break;
                }
        }
    }

    private void OnTouchDream()
    {
        //GetComponent<PlayableDirector>().Play();

        GlobalData.getDreamPiece();
        /*Debug.Log(GlobalData.dreamPieceNum);
        Debug.Log("Touch");*/
        if (GlobalData.dreamPieceNum == 4)
        {
            portal.SetActive(true);
        }
    }
    private void OnTouchTreasure()
    {
        GlobalData.getTreasurePieces();
    }

    //ʰȡ�ξ���Ƭ
    public void collectPiece()
    {
        controlled = true;
        GameMenu.instance.activePiece(GlobalData.dreamPieceNum);
        GlobalData.dreamPieceNum++;
    }
}
