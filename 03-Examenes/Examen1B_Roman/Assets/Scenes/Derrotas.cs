using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Derrotas : MonoBehaviour
{
    private int derrotas;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Derrotas: "+ derrotas.ToString();
    }

    public void SumarDerrota()
    {
        derrotas += 1;
    }
}
