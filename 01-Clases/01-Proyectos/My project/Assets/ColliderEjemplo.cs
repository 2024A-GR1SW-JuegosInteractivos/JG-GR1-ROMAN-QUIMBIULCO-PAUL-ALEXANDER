using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    [SerializeField] float delayDestroy = 0.5f;
    [SerializeField] private Color32 tienePaqueteColor = new Color32(255, 0, 0, 255);
    [SerializeField] private Color32 noTienePaqueteColor = new Color32(0, 0, 255, 255);
    private SpriteRenderer spriteRenderer;
    private bool tienePaquete;

    private void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando en trigger!");
        if(other.tag == "Paquete" && !tienePaquete)
        {
            Debug.Log("Recogió paquete");
            tienePaquete = true;
            spriteRenderer.color = tienePaqueteColor;
            Destroy(other.gameObject, delayDestroy);
        }
        if(other.tag == "Cliente" && tienePaquete)
        {
            Debug.Log("Entregó paquete");
            tienePaquete = false;
            spriteRenderer.color = noTienePaqueteColor;
        }
    }
}
