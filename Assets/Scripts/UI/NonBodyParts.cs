using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NonBodyParts : DragPart
{
    public bool spawned = false;
    public bool unlocked = true;

    [SerializeField] private Sprite locked;
    [SerializeField] private Sprite notLocked;

    private void Start()
    {
        if (!unlocked)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = locked;
        }
    }

    private void Update()
    {
        if (unlocked == true)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = notLocked;
        }
    }


    public override void CreatePart()
    {
        if (unlocked)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = notLocked;
            Debug.Log("Part Created");
            spawned = true;
            Instantiate(part, Input.mousePosition, Quaternion.identity);
        }
    }
}
