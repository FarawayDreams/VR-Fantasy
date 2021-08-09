using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowCameraUI: MonoBehaviour
{
    Button CollectionButton;
    Button SceneButton;
    Button OptionButton;
    public GameObject CollectionMenu;
    public GameObject SceneMenu;
    public GameObject OptionMenu;
    public GameObject[] DreamPiecesUI;
    private void Awake()
    {
        CollectionButton = transform.Find("CollectionButton").GetComponent<Button>();
        SceneButton = transform.Find("SceneButton").GetComponent<Button>();
        OptionButton = transform.Find("OptionButton").GetComponent<Button>();
        CollectionButton.onClick.AddListener(OpenCollection);
        SceneButton.onClick.AddListener(OpenScene);
        OptionButton.onClick.AddListener(OpenOption);
        for (int i = 0; i < DreamPiecesUI.Length; i++) DreamPiecesUI[i].SetActive(false);
    }
    private void Update()
    {
        UpdatePieceUI();
    }
    void UpdatePieceUI()
    {
        //检测梦境碎片的数量
        //数量每增加一个，左下角的UI白色水晶就会亮起一个。
        switch (GlobalData.dreamPieceNum)
        {
            case 1:
                if (DreamPiecesUI.Length > 0)
                    DreamPiecesUI[0].SetActive(true);
                break;
            case 2:
                /*
                for (int i = 0; i < 2; i++)
                {
                    Debug.Log("现在碎片为" + GlobalData.dreamPieceNum + "个");
                    if(dreamPieceUI.Length - i >= 0)
                        dreamPieceUI[i].SetActive(true);
                    Debug.Log("当前数组长度为" + dreamPieceUI.Length + "个,目前i的值为"+i);
                    Debug.Log("第" + i + "个碎片成功添加");
                }*/
                DreamPiecesUI[1].SetActive(true);
                break;
            case 3:
                DreamPiecesUI[2].SetActive(true);
                break;
            case 4:
                DreamPiecesUI[3].SetActive(true);
                break;
            default:
                for (int i = 0; i < DreamPiecesUI.Length; i++)
                    DreamPiecesUI[i].SetActive(false);
                break;
        }
    }

     void OpenOption()
    {
        OptionMenu.SetActive(true);
    }
    void OpenCollection()
    {
        CollectionMenu.SetActive(true);
    }
    void OpenScene()
    {
        SceneMenu.SetActive(true);
    }
}
