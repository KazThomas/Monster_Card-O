using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBodyParts : DragPart
{
    public bool spawned = false;
    public override void CreatePart()
    {
        Debug.Log("Part Created");
        spawned = true;
        Instantiate(part, Input.mousePosition, Quaternion.identity);
    }
}
