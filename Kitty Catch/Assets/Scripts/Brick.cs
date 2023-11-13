using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioSource hit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<PlayerMovement>().GameOver();
            Destroy(this.gameObject, 0.6f);
        }
        hit.Play();
    }
}
