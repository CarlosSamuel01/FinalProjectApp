using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour
{
    public GameObject marcador;
    public GameObject puntaje;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            marcador.SetActive(true);
            puntaje.SetActive(false);
        }
    }
}
