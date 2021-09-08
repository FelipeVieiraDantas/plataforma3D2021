using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour
{
    ControleMiranha miranha;

    // Start is called before the first frame update
    void Start()
    {
        miranha = FindObjectOfType<ControleMiranha>();
    }

    private void OnBecameVisible()
    {
        if (!miranha.alvosNaTela.Contains(transform))
        {
            miranha.alvosNaTela.Add(transform);
        }
    }

    private void OnBecameInvisible()
    {
        if (miranha.alvosNaTela.Contains(transform))
        {
            miranha.alvosNaTela.Remove(transform);
        }
    }
}
