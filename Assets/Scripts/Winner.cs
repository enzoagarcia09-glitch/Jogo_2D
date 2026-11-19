using UnityEngine;
using UnityEngine.SceneManagement;            

public class Winner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Roda quando algum objeto entra na área do collider (precisa estar com Is Trigger marcado)
    {
        if (other.CompareTag("Player"))             // Confere se quem entrou foi o player (tag "Player")
        {
            SceneManager.LoadScene("jogo3");        // Carrega a cena "jogo3" (nome idêntico e cena no Build Settings)
        }
    }
}