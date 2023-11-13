using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float velocidadeDoJogador = 15;
    [SerializeField] int gatosSalvos;
    public Animator oAnimador;


    void Start()
    {
        oAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();
    }

    public void MovimentarJogador()
    {
        float comandosDoTeclado = Input.GetAxisRaw("Horizontal") * velocidadeDoJogador * Time.deltaTime;
        transform.position = new Vector3((transform.position.x + comandosDoTeclado), transform.position.y, transform.position.z);

        if(comandosDoTeclado > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(comandosDoTeclado < -0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (comandosDoTeclado == 0)
        {
            oAnimador.Play("idle_player");
        }

        else
        {
            oAnimador.Play("walking_player");
        }
    }

    public void AumentarGatosSalvos()
    {
        gatosSalvos += 1;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
