using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalhaProcedural : MonoBehaviour
{

    Mesh malha;

    Vector3[] vertices;
    int[] triangulos;

    public int tamanhoX = 20;
    public int tamanhoY = 20;

    WaitForSeconds espera;

    // Start is called before the first frame update
    void Start()
    {
        malha = new Mesh();
        GetComponent<MeshFilter>().mesh = malha;
        espera = new WaitForSeconds(0.025f);
        StartCoroutine(CriarMalha());
    }

    IEnumerator CriarMalha()
    {
        vertices = new Vector3[(tamanhoX +1) * (tamanhoY +1)];

        int atual = 0;
        for (int y = 0; y <= tamanhoY; y++)
        {
            for (int x = 0; x <= tamanhoX; x++)
            {
                float altura = Mathf.PerlinNoise(x * 0.3f, y * 0.3f) * 2;
                vertices[atual] = new Vector3(x, altura, y);
                atual++;
            }
        }

        triangulos = new int[tamanhoX * tamanhoY * 6];

        int vert = 0;
        int tri = 0;

        for (int y = 0; y < tamanhoY; y++)
        {
            for (int x = 0; x < tamanhoX; x++)
            {
                triangulos[tri] = vert;
                triangulos[tri + 1] = vert + tamanhoX + 1;
                triangulos[tri + 2] = vert + 1;
                triangulos[tri + 3] = vert + 1;
                triangulos[tri + 4] = vert + tamanhoX + 1;
                triangulos[tri + 5] = vert + tamanhoX + 2;

                tri += 6;
                vert++;

                yield return espera;
            }
            vert++;
        }
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Atualizar a malha na tela
        malha.Clear();
        malha.vertices = vertices;
        malha.triangles = triangulos;
        malha.RecalculateNormals();
    }
}
