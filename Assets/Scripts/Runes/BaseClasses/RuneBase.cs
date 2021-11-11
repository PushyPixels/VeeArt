using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RuneBase : MonoBehaviour
{
    public string guid;

    private static Dictionary<string,RuneBase> globalRuneDictionary = new Dictionary<string,RuneBase>();

    void Awake()
    {
        globalRuneDictionary.Add(guid,this);
    }

    public static RuneBase FindRuneByGuid(string guid)
    {
        return globalRuneDictionary[guid];
    }

    protected virtual void OnValidate()
    {
        #if UNITY_EDITOR
        // This lets us detect if we are a prefab instance or a prefab asset.
        // A prefab asset cannot contain a GUID since it would then be duplicated when instanced.
        if(PrefabUtility.GetPrefabAssetType(this) == PrefabAssetType.Regular)
        {
            RuneBase prefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource<RuneBase>(this);
            if(prefab.guid == guid)
            {
                guid = null;
            }
        }
        #endif

        if(string.IsNullOrEmpty(guid))
        {
            guid = Guid.NewGuid().ToString();
        }
    }
}