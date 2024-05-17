using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int value = 1;
    public GameManager gameManager;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            gameManager.SumarPuntos(value);
            Destroy(this.gameObject);
        }
    }
}
