using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    [SerializeField] int currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        
    }

    public void Hurt()
    {
        CurrentHealth--;
    }


    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instace.Respawn();
            }
            else if(currentHealth >= 0) 
            {
                PlayerController.instance.KnockBack();
            }
        }
    }

    public int MaxHealth
    {
        get => maxHealth;
    }
    
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

}
