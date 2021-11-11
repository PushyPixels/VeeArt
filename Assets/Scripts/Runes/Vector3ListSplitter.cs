using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3ListSplitter : Rune
{
    public RuneVectorListParameter vectorListInput;
    public RuneVectorListParameter vectorListOutput1;
    public RuneVectorListParameter vectorListOutput2;

    void Update()
    {
        vectorListOutput1.value = vectorListInput.value;
        vectorListOutput2.value = vectorListInput.value;

        base.Exec();
    }
}
