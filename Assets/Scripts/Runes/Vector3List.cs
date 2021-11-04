using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3List : Rune
{
    public RuneVectorParameter vector3Input;

    private List<Vector3> vectorList = new List<Vector3>();

    public override void Exec()
    {
        base.Exec();

        vectorList.Add(vector3Input.value);
    }
}
