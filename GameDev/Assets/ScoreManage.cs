using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    int score;
    
    // Start is called before the first frame update
    void Start()
    {
        DisplayScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayScore(int score)
    {
        GameObject.Find("ScoreValue").GetComponent<Text>().text = score.ToString();

    }

    public void AddScore()
    {
        score++;
        DisplayScore(score);
        if (score == 20)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
        }
    }
}
