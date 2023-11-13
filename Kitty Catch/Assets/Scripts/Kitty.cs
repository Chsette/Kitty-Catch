using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Kitty : MonoBehaviour
{

    public AudioSource kittySaved;
    public AudioSource kittyFail;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<PlayerMovement>().AumentarGatosSalvos();
            kittySaved.Play();
            Debug.Log("Kitty saved");
            Destroy(this.gameObject, 0.5f); 
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            kittyFail.Play();
            Debug.Log("Kitty on the floor");
            Destroy(this.gameObject, 1f);
        }
    }
}
