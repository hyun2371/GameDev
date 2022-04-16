using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump2D_Restart : MonoBehaviour
{
    public void ClickRestart()
    {
        print("clicked");
        SceneManager.LoadScene("Jump2D");
    }
}
