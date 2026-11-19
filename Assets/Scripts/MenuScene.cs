using UnityEngine;
using UnityEngine.SceneManagement;                  

public class MenuScene : MonoBehaviour
{
    public GameObject painelPause;                      // Painel do pause (arraste do Canvas)
    public GameObject painelGameOver;                   // Painel do game over (arraste do Canvas)

    bool pausado = false;                               // Indica se o jogo está pausado
    bool JogoAcabou = false;                            // Indica se o jogador já perdeu (impede pausar depois do game over)

    void Start()
    {
        painelPause.SetActive(false);                   // Começa com os dois painéis escondidos
        painelGameOver.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))           // Ao apertar Esc, alterna entre pausar e continuar
        {
            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        if (JogoAcabou == false)                         // Só pausa se o jogo ainda não acabou
        {
            pausado = true;
            painelPause.SetActive(true);                // Mostra a tela de pause
            Time.timeScale = 0f;                        // Congela o jogo (física, animações e movimentos)
        }
    }

    public void Continuar()                             // Ligue no botão "Continuar" do pause
    {
        pausado = false;
        painelPause.SetActive(false);
        Time.timeScale = 1f;                            // Volta o tempo ao normal
    }

    public void MostrarGameOver()                       // Chame esta função quando o player morrer
    {
        JogoAcabou = true;
        painelGameOver.SetActive(true);
        Time.timeScale = 0f;                            // Congela o jogo atrás da tela de game over
    }

    public void Reiniciar()                             // Ligue no botão "Reiniciar"
    {
        Time.timeScale = 1f;                            // Importante: sem isso a cena reinicia congelada
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // Recarrega a cena atual
    }

    public void VoltarMenu()                            // Ligue no botão "Menu"
    {
        Time.timeScale = 1f;                            // Também precisa descongelar antes de trocar de cena
        SceneManager.LoadScene(0);                      // Carrega a cena de índice 0 (o menu, primeira no Build Settings)
    }
}