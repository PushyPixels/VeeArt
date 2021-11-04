using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : Rune
{
    // We're gonna attempt to use OnValidate to build out interfaces at editor-time and serialize for runtime
    // I think it's gonna work! - Max
    void OnValidate()
    {
        outputs.Clear();

        // Outputs
        outputs.Add(new Parameter<Vector3>("Position"));
    }

    public override void Exec()
    {
        base.Exec();

        Debug.Log("Outputting current position as Vector");
        Parameter<Vector3> output = outputs[0] as Parameter<Vector3>;
        output.Value = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
