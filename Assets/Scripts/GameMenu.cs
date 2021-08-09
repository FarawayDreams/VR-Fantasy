using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    public Sprite[] greySprites;
    public Sprite[] normalSprites;
    public Sprite[] highlightedSprites;
    public Sprite[] downSprites;
    public Image[] menuButtons;
    public GameObject[] panels;
    public GameObject[] pieces;
    //public GameObject collector;

    private int highlightedIndex;
    private int selectedIndex;
    private bool isMenued;

    private SteamVR_Action_Boolean left;
    private SteamVR_Action_Boolean right;
    private SteamVR_Action_Boolean up;
    private SteamVR_Action_Boolean down;
    private SteamVR_Action_Boolean choose;
    private SteamVR_Action_Boolean myMenu;
    public SteamVR_Behaviour_Pose pose;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SteamVR_Input.GetActionSet("fantasy").Activate();
        left = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("left");
        right = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("right");
        up = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("up");
        down = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("down");
        myMenu = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("menu");
        choose = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("choose");
        selectedIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void getInput()
    {
        if(!isMenued)
        {
            if(myMenu.GetStateDown(pose.inputSource))
            {
                switchMenu(true);
            }
        }
        else
        {
            if(selectedIndex==-1)
            {
                if(myMenu.GetStateDown(pose.inputSource))
                {
                    switchMenu(false);
                }
                if(left.GetStateDown(pose.inputSource))
                {
                    moveButton(-1);
                }
                if(right.GetStateDown(pose.inputSource))
                {
                    moveButton(1);
                }
                if(choose.GetStateDown(pose.inputSource))
                {
                    turnOn();
                }
            }
            else
            {
                if(myMenu.GetStateDown(pose.inputSource))
                {
                    switchMenu(true);
                }
                getPanelInput();
            }
        }
    }

    void getPanelInput()
    {
        if(panels[selectedIndex].GetComponent<UIPanel>()!=null)
        {
            UIPanel panel = panels[selectedIndex].GetComponent<UIPanel>();
            if(left.GetStateDown(pose.inputSource))
            {
                panel.moveLeft();
            }
            if(right.GetStateDown(pose.inputSource))
            {
                panel.moveRight();
            }
            if (up.GetStateDown(pose.inputSource))
            {
                panel.moveUp();
            }
            if(down.GetStateDown(pose.inputSource))
            {
                panel.moveDown();
            }
            if (choose.GetStateDown(pose.inputSource))
            {
                panel.choose();
            }
        }
    }

    void switchMenu(bool op)
    {
        isMenued = op;
        int i;
        if(op)
        {
            for (i = 0; i < 4; ++i) 
            {
                menuButtons[i].sprite = normalSprites[i];
            }
            if(selectedIndex!=-1)
            {
                if(panels[selectedIndex].GetComponent<UIPanel>()!=null)
                {
                    panels[selectedIndex].GetComponent<UIPanel>().deActive();
                }
                selectedIndex = -1;
                menuButtons[highlightedIndex].sprite = highlightedSprites[highlightedIndex];
            }
            else
            {
                SteamVR_Input.GetActionSet("fantasy").Deactivate();
                SteamVR_Input.GetActionSet("myUI").Activate();
                menuButtons[0].sprite = highlightedSprites[0];
            }
        }
        else
        {
            for (i = 0; i < 4; ++i) 
            {
                menuButtons[i].sprite = greySprites[i];
            }
            if(selectedIndex==-1)
            {
                highlightedIndex = 0;
                SteamVR_Input.GetActionSet("fantasy").Activate();
                SteamVR_Input.GetActionSet("myUI").Deactivate();
            }
        }
    }

    void moveButton(int dir)
    {
        menuButtons[highlightedIndex].sprite = normalSprites[highlightedIndex];
        highlightedIndex += dir;
        if(highlightedIndex<0)
        {
            highlightedIndex = 2;
        }
        else if(highlightedIndex>2)
        {
            highlightedIndex = 0;
        }
        menuButtons[highlightedIndex].sprite = highlightedSprites[highlightedIndex];
    }
    void turnOn()
    {
        selectedIndex = highlightedIndex;
        panels[selectedIndex].SetActive(true);
    }

    public void activePiece(int x)
    {
        pieces[x].SetActive(true);
    }
}
