using UnityEngine;

public class GameManajer : MonoBehaviour
{
    public static GameManajer Instance { get; private set; }
    public int PuntosTotales { get { return puntosTotales; } }
    public HUD hud;
    private int puntosTotales;
    private int vidas = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Más de un Game Manager en escena!");
        }
    }

    public void SumarPuntos(int puntosASumar) 
    {
        puntosTotales = puntosTotales+puntosASumar;
        hud.ActualizarPuntos(puntosTotales);
    }

    public void PerderVida() 
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);

        if (vidas == 0)
        {
            FindAnyObjectByType<GameOver>().MostrarGameOver();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
