using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3List : Rune
{
    public RuneVectorParameter vector3Input;
    public RuneVectorListParameter vector3ListOutput;

    private List<Vector3> vectorList = new List<Vector3>();

    public override void Exec()
    {
        vectorList.Add(vector3Input.value);
        vector3ListOutput.value = vectorList;

        // We call base.Exec LAST because it calls the next Exec() and we want that to happen last.
        base.Exec();
    }
}
