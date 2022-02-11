using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;

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

    public static void Instantiate(Type runeType)
    {
        GameObject newRuneGameObject = new GameObject();
        newRuneGameObject.AddComponent(runeType);
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