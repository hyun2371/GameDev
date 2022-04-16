using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Week06_Jump_GameManager : MonoBehaviour
{
    public GameObject EndPanel;


    public void EndGame()
    {
        Debug.Log("Game Over");
        GameObject.Find("Snowman").SetActive(false);
        EndPanel.SetActive(true);
        GameObject.Find("PanelValue").GetComponent<Text>().text = GameObject.Find("ProgressText").GetComponent<Week06_Jump_ManageProgress>().Progress.ToString() + "%";
        Invoke("Restart", 5f);

    }

    void Restart()
    {
        SceneManager.LoadScene("Week06_Jump");
    }
}