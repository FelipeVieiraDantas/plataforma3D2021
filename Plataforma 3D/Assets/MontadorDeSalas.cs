using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontadorDeSalas : MonoBehaviour
{
    public GameObject[] salas;
    public int numeroSalas = 6;

    // Start is called before the first frame update
    private void Start()
    {
        CriarSala(transform.position);
    }

    void CriarSala(Vector3 onde)
    {
        numeroSalas--;
        GameObject novaSala = 
            Instantiate(salas[Random.Range(0, salas.Length)], 
            transform.position, transform.rotation);

        List<Transform> saidas = new List<Transform>();
        foreach (Transform child in novaSala.transform)
        {
            if (child.tag == "Player")
            {
                saidas.Add(child);
            }
        }

        Vector3 novaPos = onde;
        onde.x += novaSala.transform.localScale.x;
        Vector3 dir = novaSala.transform.position - saidas[0].position;
        dir.Normalize();
        novaPos += dir * novaSala.transform.localScale.x;

        novaSala.transform.position = novaPos;

        

        for (int i = 1; i < saidas.Count; i++)
        {
            if(numeroSalas > 0)
            {
                CriarSala(saidas[i].position);
            }
            else
            {
                saidas[i].gameObject.SetActive(false);
            }
        }

    }

}
