using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal outroPortal;
    public float tempoSemFuncionar = 1;
    bool funcionando = true;

    PodeSerTeletransportado encostandoNoPortal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PodeSerTeletransportado>() && funcionando)
        {
            encostandoNoPortal = other.GetComponent<PodeSerTeletransportado>();

            other.GetComponent<Collider>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(encostandoNoPortal != null && other.transform == encostandoNoPortal.transform)
        {
            encostandoNoPortal.clone.SetActive(false);
            encostandoNoPortal = null;
        }
    }


    public void ParaDeFuncionar()
    {
        funcionando = false;
        Invoke("VoltaAFuncionar", tempoSemFuncionar);
    }
    void VoltaAFuncionar()
    {
        funcionando = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (encostandoNoPortal)
        {
            Vector3 objPos = transform.InverseTransformPoint(encostandoNoPortal.transform.position);
            if (objPos.z > 0)
            {
                //other.transform.position = outroPortal.transform.position;
                encostandoNoPortal.
                    Teletransporte(transform, outroPortal.transform);
                outroPortal.ParaDeFuncionar();
                encostandoNoPortal.GetComponent<Collider>().enabled = true;

                encostandoNoPortal.clone.SetActive(false);
            }
            else
            {
                encostandoNoPortal.portal1 = transform;
                encostandoNoPortal.portal2 = outroPortal.transform;
                encostandoNoPortal.clone.SetActive(true);
            }
        }
    }
}
