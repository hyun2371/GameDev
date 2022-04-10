using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Week06_Jump_ManageProgress : MonoBehaviour
{
    public int Progress;
    // Start is called before the first frame update
    void Start()
    {
        DisplayProgress(0);
    }


    void DisplayProgress(int Progress)
    {
        GameObject.Find("ProgressValue").GetComponent<Text>().text = Progress.ToString()+"%";

    }

    public void AddProgress()
    {
        Progress += 10;
        DisplayProgress(Progress);
        if (Progress == 100)
            GameObject.Find("World").GetComponent<Week06_Jump_GameManager>().EndGame();

    }
}
