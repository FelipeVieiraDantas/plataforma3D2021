using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTerreno : MonoBehaviour
{
    public int profundidade = 20;

    public int largura = 256;
    public int altura = 256;

    public float escala = 20;

    public float offsetX;
    public float offsetY;

    TerrainData GerarTextura(TerrainData dadosAtuais)
    {
        //Ter certeza que a resolução do terreno está certa
        dadosAtuais.heightmapResolution = largura + 1;
        dadosAtuais.size = new Vector3(largura, altura, profundidade);

        float[,] alturasPorPixel = new float[largura, profundidade];

        //Vamos passar por cada pixel em x (largura) e em y (altura) da textura
        for(int x=0; x < largura; x++)
        {
            for(int y=0; y < profundidade; y++)
            {
                float porcentagemX = (float)x / largura * escala + offsetX;
                float porcentagemY = (float)y / profundidade * escala + offsetY;

                //Definir uma cor e aplicar na textura
                float perlin = Mathf.PerlinNoise(porcentagemX,porcentagemY);

                alturasPorPixel[x, y] = perlin;
            }
        }

        dadosAtuais.SetHeights(0, 0, alturasPorPixel);
        return dadosAtuais;
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
        Terrain terreno = GetComponent<Terrain>();
        terreno.terrainData = GerarTextura(terreno.terrainData);

        offsetX += Time.deltaTime * 5;
    }
}
