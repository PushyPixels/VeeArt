using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : RuneBase
{
    public Doohicky associatedDoohicky;
    public Rune nextExec;

    // NOTE: Please call base.Exec() LAST when subclassing
    virtual public void Exec()
    {
        if(nextExec)
        {
            //Debug.Log("Calling Exec on: " + nextExec.name, nextExec.gameObject);
            nextExec.Exec();
        }
    }

    protected override void OnValidate()
    {
        base.OnValidate();

        if(associatedDoohicky == null)
        {
            associatedDoohicky = GetComponentInParent<Doohicky>();
        }
    }
}