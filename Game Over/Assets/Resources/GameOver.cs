using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void MostrarGameOver() 
    {
        gameOverPanel.SetActive(true);
    }

    public void ReiniciarNivel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
