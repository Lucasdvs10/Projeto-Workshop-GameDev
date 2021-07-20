using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControleDeVidas : MonoBehaviour
{

    int vidas;

    Image barra;

    public bool invulneravel;

    SpriteRenderer spriteJogador;

    void Start()
    {
        vidas = 5;
        barra = GameObject.FindGameObjectWithTag("BarraVida").GetComponent<Image>();
        invulneravel = false;

        spriteJogador = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D outro) {
        if(outro.gameObject.layer == 7){
            tomaDano(1);
        }
    }

    private void tomaDano(int quantidadeDano){
        if(!invulneravel){
            vidas -= quantidadeDano;
            barra.fillAmount -= 0.2f;
            invulneravel = true;
            StartCoroutine(Respawn());

        }
    }

    IEnumerator Respawn(){
        
        for(int i = 0; i<6; i++){
            spriteJogador.enabled = false;
            yield return new WaitForSeconds(0.25f);
            spriteJogador.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }

        invulneravel = false;

    }

}
