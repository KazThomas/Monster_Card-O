using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBodyParts : DragPart
{
    public override void CreatePart()
    {
        Debug.Log("Part Created");

        Instantiate(part, Input.mousePosition, Quaternion.identity);
    }
}
