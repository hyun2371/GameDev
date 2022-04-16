using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FallingArrows_PlayAgain : MonoBehaviour
{
    public Object TargetScene;
    public void PlayAgain()
    {
        SceneManager.LoadScene(TargetScene.name);
    }
}
