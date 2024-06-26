using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ayuda : MonoBehaviour
{
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            texto.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        texto.SetActive(false);
    }
}
