using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Week9_Life : MonoBehaviour
{
    public float MaxHealth = 10;
    public float CurrentHealth;
    private float PotionEffect = 5;
    public HealthBar healthBar;
    public GameObject EndPanel;
    public AudioSource HurtSound;
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            print("Gameover");
            EndGame();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Bullet"))
        {
            HurtSound.Play();
            CurrentHealth -= 1;
            healthBar.SetHealth(CurrentHealth);

        }
    }
    
    void OnCollisionStay2D(Collision2D other) {

        if (other.gameObject.CompareTag("Trap"))
        {
            HurtSound.Play();
            print("collided");
            CurrentHealth -= 0.2f;
            healthBar.SetHealth(CurrentHealth);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            HurtSound.Play();
            print("trapTrigger");
            CurrentHealth -= 1;
            healthBar.SetHealth(CurrentHealth);
        }
    }

    public void DrinkPotion()
    {
        print("got potion");
        if (CurrentHealth + PotionEffect > MaxHealth)
        {
            healthBar.SetHealth(MaxHealth);
        }
        else
        {
            CurrentHealth += PotionEffect;
            healthBar.SetHealth(CurrentHealth);
        }
    }
    public void EndGame()
    {
        Debug.Log("Game Over");
        EndPanel.SetActive(true);
        GameObject.Find("PanelText").GetComponent<Text>().text ="Well Played! \n Score: "+ GameObject.Find("ScoreValue").GetComponent<Text>().text;
        HurtSound.volume = 0;
        Invoke("Restart", 3f);
       

    }

    public void Restart()
    {
        SceneManager.LoadScene("project");
    }
}
