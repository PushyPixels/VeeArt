using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : Rune
{
    // We're gonna attempt to use OnValidate to build out interfaces at editor-time and serialize for runtime
    // I think it's gonna work! - Max
    void OnValidate()
    {
        // Outputs
        outputs.Add(new Parameter<Vector3>());
    }

    public override void Exec()
    {
        base.Exec();

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
