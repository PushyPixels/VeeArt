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

    protected override void OnValidate()
    {
        base.OnValidate();

        if(associatedDoohicky == null)
        {
            associatedDoohicky = GetComponentInParent<Doohicky>();
        }
    }
}