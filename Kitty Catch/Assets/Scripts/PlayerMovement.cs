using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float velocidadeDoJogador = 15;
    [SerializeField] int gatosSalvos;
    public Animator oAnimador;
    public GameObject GameOverPainel;

    void Start()
    {
        oAnimador = GetComponent<Animator>();
    }
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
        Time.timeScale = 0f;
        GameOverPainel.SetActive(true);
        Debug.Log("Game Over");
    }
}
