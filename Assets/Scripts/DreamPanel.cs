using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamPanel : UIPanel
{
    private Animation anim;

    void Start()
    {

    }

    private void OnEnable()
    {
        anim.Play("dreamStart");
    }

    public override void deActive()
    {
        anim.Play("dreamDestroy");
    }
    // Start is called before the first frame update

    public override void moveLeft()
    {
        anim.Play("dreamLeft");
    }

    public override void moveRight()
    {
        anim.Play("dreamRight");
    }
}
