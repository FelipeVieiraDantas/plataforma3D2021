using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HPDoPlayer : MonoBehaviour
{
    //HP máximo e atual serem variáveis separadas para poder calcular porcentagem
    public int hpMaximo = 10;
    int hpAtual;

    public Image barra;
    public Transform canvas;
    public Image barraAviso;

    public void TomouPorrada(int dano)
    {
        hpAtual -= dano;
        float porcentagem = (float)hpAtual / (float)hpMaximo;
        barra.fillAmount = porcentagem;
        barraAviso.DOFillAmount(porcentagem, 0.5f).SetDelay(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        hpAtual = hpMaximo;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.LookAt(transform.position + Camera.main.transform.forward);
    }
}
