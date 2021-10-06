using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Transform mira;

    public Material materialBrilhante;

    public Material materialOriginal;
    public Renderer estouClicando;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posicaoNoMundo = Camera.main.ScreenToWorldPoint(mira.position);
            RaycastHit caraQueEuBati;
            if(Physics.Raycast(posicaoNoMundo,Camera.main.transform.forward, out caraQueEuBati))
            {
                Debug.Log("Eu acertei " + caraQueEuBati.collider);
                Rigidbody rigid = caraQueEuBati.collider.GetComponent<Rigidbody>();
                if (rigid)
                {
                    estouClicando = rigid.GetComponent<Renderer>();
                    materialOriginal = estouClicando.sharedMaterial;
                    estouClicando.sharedMaterial = materialBrilhante;
                    rigid.useGravity = false;
                    offset = rigid.transform.position - posicaoNoMundo;
                }
            }
        }

        if(Input.GetMouseButtonUp(0) && estouClicando != null)
        {
            estouClicando.GetComponent<Rigidbody>().useGravity = true;
            estouClicando.sharedMaterial = materialOriginal;
            estouClicando = null;
        }

        if (estouClicando)
        {
            Vector3 posicaoNoMundo = Camera.main.ScreenToWorldPoint(mira.position);
            estouClicando.transform.position = posicaoNoMundo + Camera.main.transform.forward * offset.magnitude;
        }

    }
}
