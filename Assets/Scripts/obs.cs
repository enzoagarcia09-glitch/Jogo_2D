using UnityEngine;
using UnityEngine.SceneManagement;

public class obs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Só reinicia se quem colidiu for o Player
        if (other.CompareTag("Player"))
        {
            // Recarrega a cena atual, voltando tudo ao início
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


