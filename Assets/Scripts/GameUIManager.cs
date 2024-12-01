using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;  // Untuk menggunakan UI Toolkit

public class GameUIManager : MonoBehaviour
{
    // Referensi untuk berbagai komponen game
    private CombatManager combatManager; 
    private HealthComponent healthComponent;  
    private GameObject player; 

    // Referensi untuk elemen UI Toolkit
    private Label enemiesLeftLabel;  
    private Label healthLabel;  
    private Label pointLabel;  
    private Label waveLabel;  

    private int totalPoints = 0;  // Total poin yang diperoleh

    // Start is called before the first frame update
    void Start()
    {
        // Ambil referensi ke CombatManager
        combatManager = FindObjectOfType<CombatManager>();
        if (combatManager == null)
        {
            Debug.LogError("CombatManager not found in the scene.");
        }

        // Ambil referensi ke player berdasarkan tag
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            healthComponent = player.GetComponent<HealthComponent>();
            if (healthComponent == null)
            {
                Debug.LogError("HealthComponent not found on player object.");
            }
        }
        else
        {
            Debug.LogError("Player object not found in the scene.");
        }

        // Ambil referensi ke elemen UI Toolkit
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;

        enemiesLeftLabel = rootVisualElement.Q<Label>("EnemiesLeft");
        healthLabel = rootVisualElement.Q<Label>("Health");
        pointLabel = rootVisualElement.Q<Label>("Point");
        waveLabel = rootVisualElement.Q<Label>("Wave");

        // Debug jika ada elemen UI yang tidak ditemukan
        if (enemiesLeftLabel == null)
        {
            Debug.LogError("Label 'EnemiesLeft' not found in the UI Document.");
        }
        if (healthLabel == null)
        {
            Debug.LogError("Label 'Health' not found in the UI Document.");
        }
        if (pointLabel == null)
        {
            Debug.LogError("Label 'Point' not found in the UI Document.");
        }
        if (waveLabel == null)
        {
            Debug.LogError("Label 'Wave' not found in the UI Document.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update jumlah musuh yang tersisa
        if (combatManager != null && enemiesLeftLabel != null)
        {
            enemiesLeftLabel.text = "Enemies Left: " + combatManager.totalEnemies.ToString();
        }

        // Update health player
        if (player == null && healthLabel != null)
        {
            healthLabel.text = "Health: 0";
        }
        else if (healthComponent != null && healthLabel != null)
        {
            int currentHealth = healthComponent.GetHealth();
            healthLabel.text = "Health: " + Mathf.Max(currentHealth, 0).ToString();
        }

        // Update poin
        if (pointLabel != null)
        {
            pointLabel.text = "Point: " + totalPoints.ToString();
        }

        // Update wave number
        if (combatManager != null && waveLabel != null)
        {
            waveLabel.text = "Wave: " + combatManager.waveNumber.ToString();
        }
    }

    // Fungsi untuk menambah poin berdasarkan level musuh
    public void AddPoints(Enemy enemy)
    {
        if (enemy != null)
        {
            int pointsToAdd = enemy.Level;  // Poin = Level musuh
            totalPoints += pointsToAdd;
            Debug.Log("Points added: " + pointsToAdd + " | Total Points: " + totalPoints);
        }
    }
}
