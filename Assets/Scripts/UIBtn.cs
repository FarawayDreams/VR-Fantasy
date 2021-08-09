using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class UIBtn : MonoBehaviour
{
    public GameObject[] dreamPieceUI;
    public GameObject[] goldsCorona;
    public GameObject[] viewsPage;
    public GameObject[] functionUI;
    public GameObject goldsBtn;
    public GameObject viewBtn;
    public GameObject funcBtn;
    public GameObject pieceUI;

    //三个UI界面默认都是关闭状态
    private bool goldsOpen = false;
    private bool viewOpen = false;
    private bool functionOpen = false;

    private void Start()
    {
        for (int i = 0; i < dreamPieceUI.Length; i++)
            dreamPieceUI[i].SetActive(false);
    }
    void Update()
    {
        UpdatePieceUI();
    }

    public void UpdatePieceUI()
    {
        //检测梦境碎片的数量
        //数量每增加一个，左下角的UI白色水晶就会亮起一个。
        switch (GlobalData.dreamPieceNum)
        {
            case 1:
                if(dreamPieceUI.Length > 0)
                    dreamPieceUI[0].SetActive(true);
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
                dreamPieceUI[1].SetActive(true);
                break;
            case 3:
                dreamPieceUI[2].SetActive(true);
                break;
            case 4:
                dreamPieceUI[3].SetActive(true);
                break;
            default:
                for (int i = 0; i < dreamPieceUI.Length; i++)
                    dreamPieceUI[i].SetActive(false);
                break;
        }
    }
    //打开宝物收藏按钮
    public void PressGoldBtn()
    {
        goldsOpen = !goldsOpen;
        if (goldsOpen && !functionOpen && !viewOpen)
        {
            for (int i = 0; i < goldsCorona.Length; i++)
                goldsCorona[i].SetActive(true);
            viewBtn.SetActive(false);
            funcBtn.SetActive(false);
            pieceUI.SetActive(false);
        }
        else
        {
            for (int i = 0; i < goldsCorona.Length; i++)
                goldsCorona[i].SetActive(false);
            viewBtn.SetActive(true);
            funcBtn.SetActive(true);
            pieceUI.SetActive(true);
        }
    }

    //打开梦境场景按钮
    public void PressViewBtn()
    {
        viewOpen = !viewOpen;
        if (viewOpen && !functionOpen && !goldsOpen)
        {
            for (int i = 0; i < viewsPage.Length; i++)
                viewsPage[i].SetActive(true);
            funcBtn.SetActive(false);
            goldsBtn.SetActive(false);
            pieceUI.SetActive(false);
        }
        else
        {
            for (int i = 0; i < viewsPage.Length; i++)
                viewsPage[i].SetActive(false);
            funcBtn.SetActive(true);
            goldsBtn.SetActive(true);
            pieceUI.SetActive(true);
        }
    }

    //打开function按钮
    public void PressFuncBtn()
    {
        functionOpen = !functionOpen;
        if (functionOpen && !viewOpen && !goldsOpen)
        {
            for (int i = 0; i < functionUI.Length; i++)
                functionUI[i].SetActive(true);
            goldsBtn.SetActive(false);
            viewBtn.SetActive(false);
            pieceUI.SetActive(false);
        }
        else
        {
            for (int i = 0; i < functionUI.Length; i++)
                functionUI[i].SetActive(false);
            goldsBtn.SetActive(true);
            viewBtn.SetActive(true);
            pieceUI.SetActive(true);
        }
    }
}
