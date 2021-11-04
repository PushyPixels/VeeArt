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

    virtual public void Return()
    {
        Debug.Log("Exec called on: " + gameObject.name, gameObject);
    }

    [Serializable]
    public class Parameter<T>
    {
        [SerializeField]
        public string Name { get; set; }
        [SerializeField]
        public T Value { get; set; }

        public Parameter(string name)
        {
            Name = name;
        }

        public Type ParameterType
        {
            get
            {
                return typeof(T);
            }
        }
    }
}