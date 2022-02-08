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

    private Vector3ListMememto memento = new Vector3ListMememto();

    void Start()
    {
        Load();
        vector3ListOutput.value = vectorList;
    }

    void OnApplicationQuit()
    {
        Save();
    }

    void Load()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, guid + ".rune");
        if(File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
            memento = MessagePackSerializer.Deserialize<Vector3ListMememto>(bytes, lz4Options);

            vector3ListOutput.connectedRune = RuneBase.FindRuneByGuid(memento.vector3ListOutputGuid) as RuneParameter<List<Vector3>>;
            vectorList = memento.vectorList;
        }
        else
        {
            Debug.LogWarning("No serialized data found, using data from Scene file.", gameObject);
        }
    }

    void Save()
    {
        memento.vector3ListOutputGuid = vector3ListOutput.guid;
        memento.vectorList = vectorList;

        string path = System.IO.Path.Combine(Application.persistentDataPath, guid + ".rune");
        var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
        byte[] bytes = MessagePackSerializer.Serialize(memento, lz4Options);
        File.WriteAllBytes(path, bytes);
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