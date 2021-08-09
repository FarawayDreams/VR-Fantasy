using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamPiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Disappear()
    {
        GetComponent<Animator>().SetBool("disappear", true);
        GetComponent<Collider>().enabled=false;
    }
    public void setActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
