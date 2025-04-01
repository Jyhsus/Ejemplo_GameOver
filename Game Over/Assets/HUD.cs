using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public GameObject[] vidas;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarPuntos(int puntosTotales) 
    {
        puntos.text = puntosTotales.ToString();
    }

    public void DesactivarVida(int indice) 
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice) 
    {
        vidas[indice].SetActive(true);
    }
}
