using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPanel : UIPanel
{
    private Animation anim;

    void Start()
    {

    }

    private void OnEnable()
    {
        anim.Play("collectionStart");
    }

    public override void deActive()
    {
        anim.Play("collectionDestroy");
    }
    // Start is called before the first frame update

    public override void moveLeft()
    {
        anim.Play("collectionLeft");
    }

    public override void moveRight()
    {
        anim.Play("collectionRight");
    }
}
