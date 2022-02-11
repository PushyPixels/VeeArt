using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using MessagePack;

public class Vector3List : Rune
{
    public RuneVectorListParameter vector3ListOutput;
    
    private List<Vector3> vectorList = new List<Vector3>();

    private Vector3ListMememto memento;

    void Start()
    {
        memento = Load<Vector3ListMememto>();
        if(memento != null)
        {
            vector3ListOutput.connectedRune = RuneBase.FindRuneByGuid(memento.vector3ListOutputGuid) as RuneParameter<List<Vector3>>;
            vectorList = memento.vectorList;
        }

        vector3ListOutput.value = vectorList;
    }

    void OnApplicationQuit()
    {
        if(memento == null)
        { 
            memento = new Vector3ListMememto();
        }
        memento.vector3ListOutputGuid = vector3ListOutput.guid;
        memento.vectorList = vectorList;
        Save<Vector3ListMememto>(memento);
    }
}

[MessagePackObject]
public class Vector3ListMememto
{
    [Key(0)]
    public string vector3ListOutputGuid;
    [Key(1)]
    public List<Vector3> vectorList;
}