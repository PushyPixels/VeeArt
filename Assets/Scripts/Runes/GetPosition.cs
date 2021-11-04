using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : Rune
{
    public Vector3 position;

    public override void Exec()
    {
        base.Exec();

        Debug.Log("Outputting current position as Vector");
        position = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        Exec();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
