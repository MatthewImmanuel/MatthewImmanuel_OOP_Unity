using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManager LevelManager { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); //hanya menghapus game manager
            return;
        }

        Instance = this;
        LevelManager = GetComponentInChildren<LevelManager>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Main Camera")); // Memastikan kamera tidak dihancurkan
    }
}
