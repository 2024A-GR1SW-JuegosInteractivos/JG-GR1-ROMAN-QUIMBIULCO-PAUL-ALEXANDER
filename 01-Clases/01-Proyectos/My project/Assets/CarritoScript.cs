using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200.0f;
    [SerializeField] float moveSpeed = 15.0f;
    [SerializeField] float velocidadRapido = 20.0f;
    [SerializeField] float velocidadLento = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fast")
        {
            Debug.Log("Ir Rápido");
            moveSpeed = velocidadRapido;
        }
        
        if (other.tag == "Slow")
        {
            Debug.Log("Ir Lento");
            moveSpeed = velocidadLento;
        }
    }
}
