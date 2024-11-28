using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text healthText;
    public Text pointsText;
    public Text waveText;
    public Text enemyCountText;

    private int health = 100;
    private int points = 0;
    private int wave = 1;
    private int enemiesInWave = 5;

    void Update()
    {
       
        healthText.text = "Health: " + health;
        pointsText.text = "Points: " + points;
        waveText.text = "Wave: " + wave;
        enemyCountText.text = "Enemies: " + enemiesInWave;
    }

   
    public void KillEnemy(int enemyLevel)
    {
        points += enemyLevel; 
        enemiesInWave--; 
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
           
        }
    }
}
