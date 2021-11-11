using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBase : MonoBehaviour
{
    [SerializeField]
    public Guid guid;

    private static Dictionary<Guid,RuneBase> globalRuneDictionary = new Dictionary<Guid,RuneBase>();

    void Awake()
    {
        globalRuneDictionary.Add(guid,this);
    }

    public static RuneBase FindRuneByGuid(Guid guid)
    {
        return globalRuneDictionary[guid];
    }

    protected virtual void OnValidate()
    {
        if(guid == null)
        {
            guid = Guid.NewGuid();
        }
    }
}