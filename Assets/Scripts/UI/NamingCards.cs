using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NamingCards : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    //TextMeshProUGUI output;
    // Start is called before the first frame update
    void Start()
    {
        input.textComponent.text = "Click Me to Name";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
