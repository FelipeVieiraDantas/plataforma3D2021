using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimples : MonoBehaviour
{
    //Vari�veis s�o nomes que podem mudar de valor enquanto o jogo roda
    //Se for p�blica, outros scripts podem acessar e a gente pode trocar pelo Inspector
    public float velocidade = 10;
    //Se n�o for p�blica (privada) a gente tem que dizer o valor dentro do c�digo.
    Rigidbody fisica;

    // Start is called before the first frame update
    void Start()
    {
        //fisica vai ser igual ao componente Rigidbody que est� no mesmo objeto do meu script
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pegamos movimento para esquerda e direita do jogador
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        //Falamos isso na janela Console, s� pra gente, desenvolvedor
        Debug.Log(movimentoHorizontal);
        //Pegamos movimento para cima e para baixo do jogador
        float movimentoVertical = Input.GetAxis("Vertical");

        //Criamos uma vari�vel do tipo Vector3, ou seja, que tenha x, y e z.
        //Ela come�ou sendo igual a velocidade da f�sica. fisica.velocity.
        //Mas eu troquei os valores de x e z para ser o que o jogador est� apertando * a velocidade
        Vector3 novaVelocidade = fisica.velocity;
        novaVelocidade.x = movimentoHorizontal * velocidade;
        novaVelocidade.z = movimentoVertical * velocidade;

        //Por fim, a gente joga essa vari�vel na velocidade da f�sica e a unity trata de calcular
        //o movimento e colis�o de tudo para a gente. Sucesso!
        fisica.velocity = novaVelocidade;

        //INTERVALO voltamos 9:45!
    }
}
