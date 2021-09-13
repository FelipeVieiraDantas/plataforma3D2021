using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourPatrulha : StateMachineBehaviour
{
    PontosPatrulha pontosPatrulha;
    int pontoAtual;
    public float distanciaAceitavel = 0.5f;
    NavMeshAgent agente;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pontosPatrulha != null)
            return;

        pontosPatrulha = animator.GetComponent<PontosPatrulha>();
        agente = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("Patrulha"))
        {
            return;
        }

        //Manda o inimigo seguir um ponto
        agente.SetDestination(pontosPatrulha.pontos[pontoAtual].position);

        //Descobre a distância do inimigo e do ponto
        float distancia = Vector3.Distance(animator.transform.position, 
            pontosPatrulha.pontos[pontoAtual].position);
        //Se a distância estiver muito próxima
        if (distancia <= distanciaAceitavel)
        {
            if (pontoAtual == 0 || pontoAtual == pontosPatrulha.pontos.Length - 1)
            {
                animator.SetBool("Patrulha", false);
                agente.SetDestination(animator.transform.position);
            }

            //Manda seguir para o próximo ponto
            pontoAtual++;
            //Se não existe o próximo ponto, volta para o primeiro
            if(pontoAtual >= pontosPatrulha.pontos.Length)
            {
                pontoAtual = 0;
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
