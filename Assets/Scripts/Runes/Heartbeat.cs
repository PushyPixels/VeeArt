using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : Rune
{
    // Update is called once per frame
    void Update()
    {
        if(nextExec)
        {
            nextExec.Exec();
        }
    }
}
