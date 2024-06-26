using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    private Rigidbody rb;
    private GameObject pushableObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody adjunto al personaje
    }

    private void Update()
    {
        // Obtener la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D o Izquierda/Derecha
        float moveVertical = Input.GetAxis("Vertical"); // W/S o Arriba/Abajo

        // Crear un vector de movimiento basado en la entrada del teclado
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Mover el personaje
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector3 movement)
    {
        // Aplicar movimiento al Rigidbody utilizando velocidad
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pushable"))
        {
            pushableObject = collision.gameObject;
        }
    }
}
