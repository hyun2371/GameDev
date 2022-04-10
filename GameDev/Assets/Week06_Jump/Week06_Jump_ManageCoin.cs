using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week06_Jump_ManageCoin : MonoBehaviour
{
    int Coin;
    int Ballcount;
    // Start is called before the first frame update
    void Start()
    {
        Ballcount = GameObject.Find("FPSController").GetComponent<Week06_Jump_Player>().Ballcount;
    }

    private void Update()
    {
        Ballcount = GameObject.Find("FPSController").GetComponent<Week06_Jump_Player>().Ballcount;
        if (Input.GetKeyDown(KeyCode.B))
        {
            Buy();
        }
        
    }
    void DisplayCoin(int Coin)
    {
        GameObject.Find("CoinValue").GetComponent<Text>().text = Coin.ToString();

    }

    public void AddCoin(int value)
    {
        Coin += value;
        DisplayCoin(Coin);
       
    }

    private void Buy()
    {
        if (Coin >= 30)
        {
            print("buy snowball");
            Coin -= 30;
            GameObject.Find("CoinValue").GetComponent<Text>().text = Coin.ToString();
            GameObject.Find("FPSController").GetComponent<Week06_Jump_Player>().Buy();
        }
        else
        {
            print("not enough coins");

        }
    }
}
