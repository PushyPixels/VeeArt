using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RuneBase : MonoBehaviour
{
    public string guid;
    public enum InstantiationSource {Runtime, Scene, Dictionary};
    public InstantiationSource instantiationSource;

    private static Dictionary<string,RuneBase> globalRuneDictionary = new Dictionary<string,RuneBase>();
    private static RuneBaseMememto runeBaseMememto;

    void Awake()
    {
        if (instantiationSource == InstantiationSource.Runtime)
        {
            // Runtime instantiated runes haven't been added to the dictionary yet.  Collision unhandled but should fire exception.
            globalRuneDictionary.Add(guid, this);
        }
        if (instantiationSource == InstantiationSource.Scene)
        {
            // If a Rune has been added to scene since the last run, it will not be in the dictionary yet.  We need to add it in this case.  Not sure how to handle collision.
            if (!globalRuneDictionary.ContainsKey(guid))
            {
                globalRuneDictionary.Add(guid, this);
            }
        }
    }

    protected MementoType Load<MementoType>()
    {
        string path = Path.Combine(Application.persistentDataPath, guid + ".rune");
        if(File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
            return MessagePackSerializer.Deserialize<MementoType>(bytes, lz4Options);
        }
        else
        {
            Debug.LogWarning("No serialized data found, using data from Scene file.", gameObject);
            return default(MementoType);
        }
    }

    protected void Save<MementoType>(MementoType memento)
    {
        string path = Path.Combine(Application.persistentDataPath, guid + ".rune");
        var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
        byte[] bytes = MessagePackSerializer.Serialize(memento, lz4Options);
        File.WriteAllBytes(path, bytes);
    }

    protected void LoadRunes() // This should only be called by Master Rune
    {
        string path = Path.Combine(Application.persistentDataPath, "MASTER.rune");
        if(File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
            runeBaseMememto = MessagePackSerializer.Deserialize<RuneBaseMememto>(bytes, lz4Options);

            if(runeBaseMememto != null)
            {
                foreach(string runeGUID in runeBaseMememto.globalRuneDictionary.Keys)
                {
                    if(!globalRuneDictionary.ContainsKey(runeGUID))
                    {
                        // Rune is not in Scene so we must instantiate it, it will load itself from file during instantiation
                        RuneBase instance = Instantiate(runeBaseMememto.globalRuneDictionary[runeGUID].GetType());
                        instance.guid = runeGUID;
                        instance.instantiationSource = InstantiationSource.Dictionary;
                        globalRuneDictionary.Add(runeGUID,runeBaseMememto.globalRuneDictionary[runeGUID]);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("No Master Rune file found.  Will generate on close.", gameObject);
        }
    }


    public static RuneBase FindRuneByGuid(string guid)
    {
        return globalRuneDictionary[guid];
    }

    private static RuneBase Instantiate(Type runeType)
    {
        GameObject newRuneGameObject = new GameObject();
        RuneBase newRuneBase = newRuneGameObject.AddComponent(runeType) as RuneBase;
        if(newRuneBase == null)
        {
            Debug.LogError("Type is not a RuneBase?");
        }
        return newRuneBase;
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

        instantiationSource = InstantiationSource.Scene;
    }
}

[MessagePackObject]
public class RuneBaseMememto
{
    [Key(0)]
    public Dictionary<string,RuneBase> globalRuneDictionary;
}