using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public List<IParameter> inputs = new List<IParameter>();
    public List<IParameter> outputs = new List<IParameter>();
    
    virtual public void Exec()
    {
        Debug.Log("Exec called on: " + gameObject.name, gameObject);
    }

    virtual public void Return()
    {
        Debug.Log("Exec called on: " + gameObject.name, gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public interface IParameter
    {
        string Name { get; set; }
        Type ParameterType { get; }
    }

    [Serializable]
    public class Parameter<T> : IParameter
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public Type ParameterType
        {
            get
            {
                return typeof(T);
            }
        }
    }
}
