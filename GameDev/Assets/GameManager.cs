using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject EndPanel;

    
    public void EndGame()
    {      
        Debug.Log("Game Over");
        GameObject.Find("Robot").SetActive(false);
        EndPanel.SetActive(true);
        GameObject.Find("PanelText").GetComponent<Text>().text += GameObject.Find("ScoreValue").GetComponent<Text>().text;
        Invoke("Restart", 5f);
            
    }

    void Restart()
    {
        SceneManager.LoadScene("Week05_FPS");
    }
}
