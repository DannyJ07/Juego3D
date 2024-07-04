using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tesoro : MonoBehaviour
{
    Contador contador;
    private void Start()
    {
        contador = GameObject.FindGameObjectWithTag("Player").GetComponent<Contador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            contador.Cantidad = contador.Cantidad + 1;
            Destroy(gameObject);
            if (contador.Cantidad == 3)
            {
                FinJuego();
            }

        }

    }
    public void FinJuego()
    {

    } 

}

