using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public Rune targetRune;

    // Update is called once per frame
    void Update()
    {
        targetRune.Exec();
    }
}
