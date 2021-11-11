using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuit : Rune
{
    void OnApplicationQuit()
    {
        if(nextExec)
        {
            nextExec.Exec();
        }
    }
}
