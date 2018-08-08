using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider healthbar;
    public Text healthValueText;

    // Use this for initialization
    void Start () {
        MaxHealth = 100;
        // set player health to full on game load
        CurrentHealth = 100;

        healthbar.value = CalcHealth();
        healthValueText.text = CurrentHealth + "/" + MaxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DealDamage(30);
        }
		
	}

    void DealDamage(float dmg)
    {
        CurrentHealth -= dmg;

        if (CurrentHealth <= 0)
        {
            Die();
        }

        // update health after taking dmg
        healthbar.value = CalcHealth(); 
        healthValueText.text = CurrentHealth + "/" + MaxHealth;

        
    }

    float CalcHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("Player is dead! X X");
    }
}
