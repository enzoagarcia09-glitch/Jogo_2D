using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()                        
    {
        SceneManager.LoadScene("jogo");            // Carrega a cena chamada "jogo" (o nome precisa ser idêntico e a cena estar no Build Settings)
    }

    public void QuitGame()                       
    {
        Application.Quit();                        // Fecha o jogo (só funciona no build, no Editor não acontece nada)
    }

}