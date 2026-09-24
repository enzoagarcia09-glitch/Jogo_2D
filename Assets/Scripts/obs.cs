using UnityEngine;
using UnityEngine.SceneManagement;

public class obs : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Só reinicia se quem colidiu for o Player
        if (other.CompareTag("Player"))
        {
            // Recarrega a cena voltando pro começo 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


