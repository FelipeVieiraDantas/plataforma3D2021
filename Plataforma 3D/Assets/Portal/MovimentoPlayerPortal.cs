using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayerPortal : MonoBehaviour
{

    Rigidbody fisica;
    public float velocidade = 10;

    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float movimentoH = Input.GetAxis("Horizontal");
        float movimentoV = Input.GetAxis("Vertical");

        Vector3 velocidadeDeVerdade = new Vector3(movimentoH, 0, movimentoV);
        velocidadeDeVerdade *= velocidade;
        velocidadeDeVerdade = Quaternion.Euler(1, Camera.main.transform.rotation.eulerAngles.y, 1)
            * velocidadeDeVerdade;


        velocidadeDeVerdade.y = fisica.velocity.y;
        fisica.velocity = velocidadeDeVerdade;
    }
}
