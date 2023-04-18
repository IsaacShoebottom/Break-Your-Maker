using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerLogic>().Powerup();
            Destroy(gameObject);
        }
    }
}
