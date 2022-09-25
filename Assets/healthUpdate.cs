using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUpdate : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider col) {
        Debug.Log("Player got hit");
        if(col.gameObject.tag == "enemyBullet") {
            Destroy(col.gameObject);
            Debug.Log("Enemy bullet destroyed!");
            Debug.Log(col.gameObject);
            currentHealth = currentHealth - 20;
            updateHealth(currentHealth);
            return;            
        }
    }

    public void updateHealth(int health) {
        Debug.Log("Set health Called");
        healthBar.SetHealth(health);
        Debug.Log("Health set");
    }
    //     public void OnCollisionEnter(Collision col) {
    //     Debug.Log("Got Hit!!!!");
    //     if(col.gameObject.tag == "enemyBullet") {
    //         Destroy(col.gameObject);
    //         Debug.Log("Enemy YOOOOO");
    //         Debug.Log(col.gameObject);
    //         currentHealth = currentHealth - 20;
    //         Debug.Log(currentHealth);
    //         healthBar.SetHealth(currentHealth);
            
    //     }
    // }
}