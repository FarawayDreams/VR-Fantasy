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
        //����ξ���Ƭ������
        //����ÿ����һ�������½ǵ�UI��ɫˮ���ͻ�����һ����
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
                    Debug.Log("������ƬΪ" + GlobalData.dreamPieceNum + "��");
                    if(dreamPieceUI.Length - i >= 0)
                        dreamPieceUI[i].SetActive(true);
                    Debug.Log("��ǰ���鳤��Ϊ" + dreamPieceUI.Length + "��,Ŀǰi��ֵΪ"+i);
                    Debug.Log("��" + i + "����Ƭ�ɹ����");
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
