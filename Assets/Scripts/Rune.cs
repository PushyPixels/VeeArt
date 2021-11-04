using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    [SerializeField]
    public List<IParameter> inputs = new List<IParameter>();
    [SerializeField]
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
        [SerializeField]
        string Name { get; set; }

        [SerializeField]
        Type ParameterType { get; }
    }

    [Serializable]
    public class Parameter<T> : IParameter
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