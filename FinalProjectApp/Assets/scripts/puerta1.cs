using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta1 : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("llave"))
        {
            door.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        door.SetActive(false);
    }
}