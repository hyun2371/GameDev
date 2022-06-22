using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week9_ManageCoin : MonoBehaviour
{
    int Coin;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("BestScoreValue").GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
    }

   
    void DisplayScore(int Coin)
    {
        int BestScore = int.Parse(GameObject.Find("BestScoreValue").GetComponent<Text>().text);
        if (Coin > BestScore)
        {
            BestScore = Coin; //갱신
            PlayerPrefs.SetInt("BestScore", BestScore); //PlayerPrefs에 저장
        }
        GameObject.Find("ScoreValue").GetComponent<Text>().text = Coin.ToString();

    }
    public void AddScore(int value)
    {
        Coin += value;
        DisplayScore(Coin);

    }
}
