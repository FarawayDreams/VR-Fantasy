using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public Button CloseButton;
    private void Awake()
    {
        CloseButton.onClick.AddListener(CloseOption);
    }
    void CloseOption()
    {
        gameObject.SetActive(false);
    }
}
