using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LinkController : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody fisica;
    Animator anim;

    public GameObject cinematicaBau;
    public PlayableDirector diretor;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cinematicaBau.SetActive(true);
            other.enabled = false;
            fisica.isKinematic = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (cinematicaBau.activeInHierarchy)
        {
            if(diretor.state != PlayState.Playing)
            {
                cinematicaBau.SetActive(false);
                anim.transform.localPosition = Vector3.zero;
                anim.transform.localRotation = Quaternion.Euler(Vector3.zero);
                fisica.isKinematic = false;
            }
            
            return;
        }



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
