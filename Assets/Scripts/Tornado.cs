using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    private int elapsedTime;

    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
    }

    public IEnumerator Timer()
    {
        while (true)
        {
            elapsedTime += 1;

            if (elapsedTime % 3 == 0)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
                Vector2 direction = Vector2.up;
                player.PushBack(direction, 0.8f);
                player.getHit(1);
            }
        }
    }
}
