using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodeSerTeletransportado : MonoBehaviour
{
    Rigidbody fisica;

    public GameObject clone;
    public Transform portal1, portal2;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();

        clone = new GameObject();
        clone.SetActive(false);
        MeshFilter mS = clone.AddComponent<MeshFilter>();
        MeshRenderer mR = clone.AddComponent<MeshRenderer>();

        mS.mesh = GetComponent<MeshFilter>().mesh;
        mR.materials = GetComponent<MeshRenderer>().materials;
        clone.transform.localScale = transform.localScale;
    }

    public void Teletransporte(Transform portalQueEuEntrei, Transform portalParaSair)
    {
        //Colocar esse objeto numa posição no portal de saída relativa ao portal de entrada
        Vector3 novaPos = portalQueEuEntrei.InverseTransformPoint(transform.position);
        transform.position = portalParaSair.TransformPoint(novaPos);

        //Fazer o mesmo para a velocidade
        Vector3 velRelativa = portalQueEuEntrei.InverseTransformDirection(fisica.velocity);
        fisica.velocity = -portalParaSair.TransformDirection(velRelativa);
    }

    private void Update()
    {
        if (clone.activeInHierarchy)
        {
            clone.transform.rotation = transform.rotation;

            Vector3 posRelativa = portal1.InverseTransformPoint(transform.position);
            clone.transform.position = portal2.TransformPoint(-posRelativa);
        }
    }
}
