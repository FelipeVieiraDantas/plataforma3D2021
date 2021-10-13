using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public GameObject[] portais;
    public Transform mira;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogador clicou com o botão esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            //Pegamos a posição da mira no mundo e fizemos um raycast para a frente da câmera
            Vector3 posicaoNoMundo = Camera.main.ScreenToWorldPoint(mira.position);
            RaycastHit caraQueEuBati;
            if (Physics.Raycast(posicaoNoMundo, Camera.main.transform.forward, out caraQueEuBati))
            {
                //Se o cara que o raycast acertou não tem rigidbody...
                if (!caraQueEuBati.collider.GetComponent<Rigidbody>())
                {
                    portais[0].SetActive(true);
                    portais[0].transform.position = caraQueEuBati.point;
                    portais[0].transform.GetChild(0).gameObject.SetActive(portais[1].activeInHierarchy);
                    portais[0].transform.forward = -caraQueEuBati.normal;
                    if (!portais[1].transform.GetChild(0).gameObject.activeInHierarchy)
                    {
                        portais[1].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }


        //Se o jogador clicou com o botão direito
        if (Input.GetMouseButtonDown(1))
        {
            //Pegamos a posição da mira no mundo e fizemos um raycast para a frente da câmera
            Vector3 posicaoNoMundo = Camera.main.ScreenToWorldPoint(mira.position);
            RaycastHit caraQueEuBati;
            if (Physics.Raycast(posicaoNoMundo, Camera.main.transform.forward, out caraQueEuBati))
            {
                //Se o cara que o raycast acertou não tem rigidbody...
                if (!caraQueEuBati.collider.GetComponent<Rigidbody>())
                {
                    portais[1].SetActive(true);
                    portais[1].transform.position = caraQueEuBati.point;
                    portais[1].transform.GetChild(0).gameObject.SetActive(portais[0].activeInHierarchy);
                    portais[1].transform.forward = -caraQueEuBati.normal;
                    if (!portais[0].transform.GetChild(0).gameObject.activeInHierarchy)
                    {
                        portais[0].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
