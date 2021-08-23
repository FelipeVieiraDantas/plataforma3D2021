using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimples : MonoBehaviour
{
    //Variáveis são nomes que podem mudar de valor enquanto o jogo roda
    //Se for pública, outros scripts podem acessar e a gente pode trocar pelo Inspector
    public float velocidade = 10;
    //Se não for pública (privada) a gente tem que dizer o valor dentro do código.
    Rigidbody fisica;

    // Start is called before the first frame update
    void Start()
    {
        //fisica vai ser igual ao componente Rigidbody que está no mesmo objeto do meu script
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pegamos movimento para esquerda e direita do jogador
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        //Falamos isso na janela Console, só pra gente, desenvolvedor
        Debug.Log(movimentoHorizontal);
        //Pegamos movimento para cima e para baixo do jogador
        float movimentoVertical = Input.GetAxis("Vertical");

        //Criamos uma variável do tipo Vector3, ou seja, que tenha x, y e z.
        //Ela começou sendo igual a velocidade da física. fisica.velocity.
        //Mas eu troquei os valores de x e z para ser o que o jogador está apertando * a velocidade
        Vector3 novaVelocidade = fisica.velocity;
        novaVelocidade.x = movimentoHorizontal * velocidade;
        novaVelocidade.z = movimentoVertical * velocidade;

        //Por fim, a gente joga essa variável na velocidade da física e a unity trata de calcular
        //o movimento e colisão de tudo para a gente. Sucesso!
        fisica.velocity = novaVelocidade;

        //INTERVALO voltamos 9:45!
    }
}
