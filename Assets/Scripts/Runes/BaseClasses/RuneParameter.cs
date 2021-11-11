using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneParameter<T> : RuneBase
{
    [System.Serializable]
    public enum ParamType { Input, Output }
    public ParamType paramType;
    public RuneParameter<T> connectedRune;
    public T value;
    private T previousValue;

    void Start()
    {
        //Debug.Log("Start called on: " + name, gameObject);
        previousValue = value;
    }

    void Update()
    {
        if(paramType == ParamType.Output)
        {
            if(!previousValue.Equals(value))
            {
                if(connectedRune)
                {
                    connectedRune.value = value;
                }
                previousValue = value;
            }
        }
    }
}
