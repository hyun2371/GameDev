using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArrows_ButtonController : MonoBehaviour
{
    
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player");    
    }

    public void MoveLeft()
    {
        Player.transform.Translate(Vector2.left);
    }

    public void MoveRight()
    {
        Player.transform.Translate(Vector2.right);
    }
}
