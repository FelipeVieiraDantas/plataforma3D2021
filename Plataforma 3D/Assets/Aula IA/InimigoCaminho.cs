using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoCaminho : MonoBehaviour
{
    public Transform[] alvo;
    int alvoAtual;
    NavMeshAgent agente;

    public float distanciaAlvo = 0.5f;

    //Perder velocidade fora do caminho
    public float velocidadeInicial = 10;
    public float multiplicadorForaDaPista = 0.5f;
    public LayerMask layerDaPista;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadeFinal = velocidadeInicial * multiplicadorForaDaPista;

        if (Physics.Raycast(transform.position, -transform.up, Mathf.Infinity, layerDaPista))
        {
            velocidadeFinal = velocidadeInicial;
        }
        agente.speed = velocidadeFinal;





        agente.SetDestination(alvo[alvoAtual].position);

        if(Vector3.Distance(transform.position, alvo[alvoAtual].position) < distanciaAlvo)
        {
            alvoAtual = alvoAtual+1; //Pode ser escrito como alvoAtual++;
            if(alvoAtual >= alvo.Length)
            {
                alvoAtual = 0;
            }
        }
    }
}
