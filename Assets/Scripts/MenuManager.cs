using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()                        // Public para aparecer no On Click() do botão "Jogar"
    {
        SceneManager.LoadScene("jogo");            // Carrega a cena chamada "jogo" (o nome precisa ser idêntico e a cena estar no Build Settings)
    }

    public void QuitGame()                         // Ligue no On Click() do botão "Sair"
    {
        Application.Quit();                        // Fecha o jogo (só funciona no build, no Editor não acontece nada)
    }

}