using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin : MonoBehaviour
{
    public int largura = 256;
    public int altura = 256;

    public float escala = 20;

    public float offsetX;
    public float offsetY;

    Texture2D GerarTextura()
    {
        //Cria uma nova textura com o tamanho definido
        Texture2D novaTextura = new Texture2D(largura, altura);

        //Vamos passar por cada pixel em x (largura) e em y (altura) da textura
        for(int x=0; x < largura; x++)
        {
            for(int y=0; y < altura; y++)
            {
                float porcentagemX = (float)x / largura * escala + offsetX;
                float porcentagemY = (float)y / altura * escala + offsetY;

                //Definir uma cor e aplicar na textura
                float perlin = Mathf.PerlinNoise(porcentagemX,porcentagemY);

                Color novaCor = new Color(perlin, perlin, perlin);
                novaTextura.SetPixel(x, y, novaCor);
            }
        }
        novaTextura.Apply();
        return novaTextura;
    }

    // Start is called before the first frame update
    void Start()
    {
        offsetX = Random.Range(0, 1000);
        offsetY = Random.Range(0, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        Renderer render = GetComponent<Renderer>();
        render.material.mainTexture = GerarTextura();
    }
}
