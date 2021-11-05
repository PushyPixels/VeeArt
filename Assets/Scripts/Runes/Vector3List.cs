using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3List : Rune
{
    public RuneVectorParameter vector3Input;

    private List<Vector3> vectorList = new List<Vector3>();

    public override void Exec()
    {
        vectorList.Add(vector3Input.value);

        // We call base.Exec LAST because it calls the next Exec() and we want that to happen last.
        base.Exec();
    }
}
