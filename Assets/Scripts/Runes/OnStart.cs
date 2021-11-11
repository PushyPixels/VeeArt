using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : Rune
{
    void Start()
    {
        if(nextExec)
        {
            nextExec.Exec();
        }
    }
}
