using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody fisica;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float movimentoVertical = Input.GetAxis("Vertical");
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector3 novaVelocidade = Camera.main.transform.forward;
        novaVelocidade *= movimentoVertical * velocidade;
        novaVelocidade.y = fisica.velocity.y;
        fisica.velocity = novaVelocidade;

        if(movimentoVertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(novaVelocidade);
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }
    }
}
