using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetaMoedaEGanhaPontos : MonoBehaviour
{
    
    Text pontuacao;

    private void Start() {
        pontuacao = GameObject.FindGameObjectWithTag("Pontuacao").GetComponent<Text>();    

        pontuacao.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            Destroy(this.gameObject);

            int pontosAtual = int.Parse(pontuacao.text);
            pontosAtual++;

            pontuacao.text = pontosAtual.ToString();
        
        }
    }


}
