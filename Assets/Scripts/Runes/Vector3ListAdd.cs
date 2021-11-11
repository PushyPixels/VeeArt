using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3ListAdd : Rune
{
    public RuneVectorParameter vector3Input;
    public RuneVectorListParameter vector3ListInput;

    public override void Exec()
    {
        vector3ListInput.value.Add(vector3Input.value);

        // We call base.Exec LAST because it calls the next Exec() and we want that to happen last.
        base.Exec();
    }
}
