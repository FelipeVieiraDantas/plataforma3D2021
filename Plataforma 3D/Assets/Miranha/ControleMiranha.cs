using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControleMiranha : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody fisica;

    public List<Transform> alvosNaTela = new List<Transform>();

    public Transform cruz;

    Transform alvo;

    SpringJoint teia;

    [Header("IK")]
    public Transform alvoMaoDireita;
    public Transform alvoMaoEsquerda;
    Transform ultimoAlvoDireita, ultimoAlvoEsquerda;
    bool bracoDireito = true;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        teia = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //Arrastar a mão do player para o alvo
        //Comentado pois vamos fazer de forma suave quando apertar espaço
        /*if(ultimoAlvoDireita != null)
        {
            alvoMaoDireita.position = ultimoAlvoDireita.position;
        }
        if (ultimoAlvoEsquerda != null)
        {
            alvoMaoEsquerda.position = ultimoAlvoEsquerda.position;
        }*/




        float movimentoVertical = Input.GetAxis("Vertical");
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector3 novaVelocidade = Camera.main.transform.forward * movimentoVertical * velocidade;
        novaVelocidade += Camera.main.transform.right * movimentoHorizontal * velocidade;

        novaVelocidade.y = fisica.velocity.y;
        //fisica.velocity = novaVelocidade;


        //Se não tiver alvo nenhum, sumir com a cruz
        if(alvosNaTela.Count == 0)
        {
            cruz.gameObject.SetActive(false);
        }
        else
        {
            //Se tiver alvo, aparece a cruz e joga ela no alvo
            cruz.gameObject.SetActive(true);

            //Passar por todos os alvos na lista e guardar sua distância para o centro da tela
            float[] distancias = new float[alvosNaTela.Count];
            for (int i = 0; i < alvosNaTela.Count; i++)
            {
                //Pegando a distância do centro da tela (Screen.width e height / 2)
                //E o nosso objeto.
                distancias[i] = Vector2.Distance(
                    new Vector2(Screen.width / 2, Screen.height / 2),
                    Camera.main.WorldToScreenPoint(alvosNaTela[i].position));
            }

            //Guardar a menor distância nesta variável
            float minDistance = Mathf.Min(distancias);

            //Descobrir qual dos alvos na tela é que tem essa menor distância
            for (int i = 0; i < distancias.Length; i++)
            {
                if(distancias[i] == minDistance)
                {
                    //Guardar na variável ALVO quem é o mais perto da tela
                    alvo = alvosNaTela[i];
                    break;
                }
            }

            //Posicionar a cruz no alvo mais perto da tela
            Vector3 posNaTela = Camera.main.WorldToScreenPoint(alvo.position);
            cruz.position = posNaTela;
        }


        //Se o jogador apertar Espaço, ele troca a teia para o alvo
        if(Input.GetKeyDown(KeyCode.Space) && alvo != null)
        {
            teia.connectedBody = alvo.GetComponent<Rigidbody>();
            if (bracoDireito)
            {
                ultimoAlvoDireita = alvo;
                bracoDireito = false;
                alvoMaoDireita.DOMove(alvo.position, 0.5f);
            }
            else
            {
                ultimoAlvoEsquerda = alvo;
                bracoDireito = true;
                alvoMaoEsquerda.DOMove(alvo.position, 0.5f);
            }
            transform.DOLookAt(alvo.position, 1, AxisConstraint.Y);
            GetComponentInChildren<Animator>().SetTrigger("Teia");
        }

    }
}
