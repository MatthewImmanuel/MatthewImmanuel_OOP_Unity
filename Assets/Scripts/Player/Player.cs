using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public static Player Instance { get; private set; }
    PlayerMovement playerMovement;
    Animator animator;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        if (animator != null)
        {
            bool isMoving = playerMovement.IsMoving();
            animator.SetBool("IsMoving", isMoving);
        }
        else
        {
            Debug.LogError("Animator is null!"); // Log jika animator null        
        }
    }
}