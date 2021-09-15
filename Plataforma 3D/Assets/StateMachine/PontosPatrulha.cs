using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontosPatrulha : MonoBehaviour
{
    public Transform[] pontos;
    public Transform player;

    [Header("Campo de Vis�o")]
    public float angulo = 30;
    public float distancia;
    Animator anim;
    public LayerMask layerDoPlayer;

#if UNITY_EDITOR
    //Essa fun��o desenha algo apenas na janela Scene quando o objeto estiver selecionado
    private void OnDrawGizmosSelected()
    {
        //Vamos escolher a cor que ser� desenhada. RGBA, ou seja, a cor abaixo ser�
        //vermelha e meio transparente
        Color corDoGizmo = new Color(1, 0, 0, 0.5f);

        //Todos os Handles que eu criar na fun��o ter�o a cor definida
        UnityEditor.Handles.color = corDoGizmo;
        //Como o �ngulo n�o come�a do centro e sim metade atr�s, ser� negativo e mulitplicado
        //pela metade (0.5)
        Vector3 visaoRotacionada = Quaternion.Euler(0, -angulo * 0.5f, 0) * transform.forward;
        //Desenha um arco na janela Scene.
        UnityEditor.Handles.DrawSolidArc(transform.position,
            Vector3.up, visaoRotacionada, angulo, distancia);
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.OverlapSphere(transform.position,distancia,layerDoPlayer).Length > 0)
        {
            Vector3 direcao = player.position - transform.position;
            if (Vector3.Angle(direcao,transform.forward) < angulo *0.5f)
            {
                anim.SetBool("Vendo O Player", true);
            }
            else
            {
                anim.SetBool("Vendo O Player", false);
            }  
        }
        else
        {
            anim.SetBool("Vendo O Player", false);
        }
    }
}
