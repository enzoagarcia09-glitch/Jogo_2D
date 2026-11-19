using UnityEngine;
using UnityEngine.SceneManagement;          

public class Passarfase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Roda quando algum objeto entra na área do collider (que precisa estar com Is Trigger marcado)
    {
        if (other.CompareTag("Player"))             // Confere se quem entrou foi o player (ele precisa ter a tag "Player")
        {
            SceneManager.LoadScene("jogo2");        // Carrega a cena "jogo2" (nome idêntico e cena no Build Settings)
        }
    }
}