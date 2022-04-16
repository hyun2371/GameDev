using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Week06_Jump_Snowman : MonoBehaviour
{

    //플레이어를 향해 움직이도록 함
    GameObject Player;
    NavMeshAgent Agent;
    public float speed = 1f;
    public GameObject IceCage;

    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
         Agent.SetDestination(Player.transform.position);
    }

   
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snow")
        {
            print("Snowman hit");
            IceCage.SetActive(true);
            Agent.speed = 0;
            Invoke("SetNormal", 5f);
        }
    }

    private void SetNormal()
    {
        IceCage.SetActive(false);
        Agent.speed = 1f;
    }
}
