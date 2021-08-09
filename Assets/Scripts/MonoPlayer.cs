using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using Valve.VR;

public class MonoPlayer : MonoBehaviour
{
    public static MonoPlayer instance;
    public float velocity;
    [HideInInspector]public bool controlled;
    public GameObject portal;
    public GameObject aimPos;
    public GameObject player;
    public GameObject truePlayer;
    public GameObject aimPosPlayer;
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
        
    }
    public void moveUnit(Vector3 toPlace)
    {
        if (controlled&&Vector3.Distance(toPlace,transform.position)>0.1)
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
                    //重置梦境碎片数量，使左下角的显示重置为0
                    GlobalData.dreamPieceNum = 0;

                    /*
                     * 此处要添加一个梦境碎片的合成动画
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
        Debug.Log(GlobalData.dreamPieceNum);
        if(GlobalData.dreamPieceNum==4)
        {
            portal.SetActive(true);
        }
    }
    private void OnTouchTreasure()
    {
        GlobalData.getTreasurePieces();
    }
   
//拾取梦境碎片
    public void collectPiece()
    {
        controlled = true;
        GameMenu.instance.activePiece(GlobalData.dreamPieceNum);
        GlobalData.dreamPieceNum++;
    }
}
