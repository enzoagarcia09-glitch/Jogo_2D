using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo;                                      // Objeto que a câmera vai seguir (arraste o Player aqui)
    public Vector3 distancia = new Vector3(0f, 0f, -10f);       // Deslocamento em relação ao alvo (o Z = -10 mantém a câmera 2D à frente do jogo)
    public bool movimentoSuave = true;                          // Liga/desliga o movimento suave
    public float velocidade = 5f;                               // Quanto maior, mais rápido a câmera alcança o alvo


    private void LateUpdate()                                   
    {
        Vector3 posicaoDesejada = alvo.position + distancia;    // Posição onde a câmera deveria estar

        if (movimentoSuave)
        {
            // Lerp aproxima a câmera aos poucos da posição desejada, criando o efeito suave
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = posicaoDesejada;               // Câmera vai direto para a posição, sem suavização
        }
    }
}