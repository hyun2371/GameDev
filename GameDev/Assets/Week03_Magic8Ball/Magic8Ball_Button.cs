using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magic8Ball_Button : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleButton()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        if (!string.IsNullOrEmpty(inputField.text))
        {
            GameObject.Find("Magic8Ball").GetComponent<Magic8Ball_Ball>().ShakeBall();
            inputField.text = " ";
        }
    }

    
}
