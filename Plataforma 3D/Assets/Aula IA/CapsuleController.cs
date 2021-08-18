using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody fisica;

    public float velocidadeDeRotacao = 15;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pegar controle do jogador horizontal e verticalmente
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        //aplicar a velocidade na física dependendo do controle
        //Um detalhe é que o vertical movimenta o eixo Z. 
        //Se movimentasse Y, ele voaria!

        //Desta forma a gente movimenta baseado nas coordenadas do mundo:
        //fisica.velocity = new Vector3(movimentoHorizontal * velocidade, 0, movimentoVertical * velocidade);

        //Desta forma a gente rotaciona o player:
        //transform.Rotate(0, movimentoHorizontal * velocidadeDeRotacao * Time.deltaTime, 0);

        //Desta forma a gente movimenta o player para a sua frente.
        //Um detalhe é que guardamos a velocidade em Y anterior para que a gravidade funcione corretamente
        float velhoY = fisica.velocity.y;
        //Se baseia no transform.forward, ou seja, a minha frente.
        //Vector3 novaVelocidade = transform.forward * movimentoVertical * velocidade;

        //Se baseia no forward da câmera
        Vector3 novaVelocidade = Camera.main.transform.forward;
        novaVelocidade *= movimentoVertical * velocidade;

        //Retorna a velocidade em Y para a anterior
        novaVelocidade.y = velhoY;

        fisica.velocity = novaVelocidade;

        //Se ele estiver se movimento, olhar para onde está indo
        if(movimentoVertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(novaVelocidade);
        }


    }
}
