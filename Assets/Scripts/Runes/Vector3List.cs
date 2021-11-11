using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3List : Rune
{
    public RuneVectorListParameter vector3ListOutput;

    private List<Vector3> vectorList = new List<Vector3>();

    void Start()
    {
        vector3ListOutput.value = vectorList;
    }
}
