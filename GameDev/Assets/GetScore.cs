using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetScore : MonoBehaviour
{
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    void Update()
    {
        GameObject.Find("Score").GetComponent<Text>().text += Score.ToString();
    }
}
