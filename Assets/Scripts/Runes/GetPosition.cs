using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : Rune
{
    public RuneVectorParameter positionOutput;

    public override void Exec()
    {
        Debug.Log("Outputting current position as Vector to: " + positionOutput.name, positionOutput.gameObject);

        // We call base.Exec LAST because it calls the next Exec() and we want that to happen last
        base.Exec();
    }
}
