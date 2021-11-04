using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    virtual public void Exec()
    {
        Debug.Log("Exec called on: " + gameObject.name, gameObject);
    }
}