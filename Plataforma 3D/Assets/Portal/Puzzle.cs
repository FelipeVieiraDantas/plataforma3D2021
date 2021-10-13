using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puzzle : MonoBehaviour
{
    Color corOriginal;
    Material materialQueEuMudei;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Finish" && materialQueEuMudei == null)
        {
            //Terminou o puzzle
            Renderer r = collision.collider.GetComponent<Renderer>();
            materialQueEuMudei = r.sharedMaterial;
            corOriginal = materialQueEuMudei.color;
            //Pra quem não tem o DOTween, pode fazer dessa forma:
            //r.material.color = Color.green;
            r.sharedMaterial.DOColor(Color.green,1);
        }
    }
    private void OnDisable()
    {
        if (materialQueEuMudei != null)
        {
            materialQueEuMudei.color = corOriginal;
        }
    }
}
