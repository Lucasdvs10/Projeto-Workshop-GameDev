using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{


    Rigidbody2D rig;

    [SerializeField]
    float velocidade;
    [SerializeField]
    float forcaPulo;

    bool podePular;

    Animator anim;
    void Start()
    {
        rig  = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        andar();
        pular();
    }


    private void andar(){
        float direcao = Input.GetAxisRaw("Horizontal");
        rotaciona(direcao);
        transitaAnimacoes(1);

        rig.velocity = new Vector2(direcao * velocidade, rig.velocity.y);

        if(direcao == 0 && podePular){ //Quando parado, Idle
            transitaAnimacoes(0);
        }

        if(direcao != 0 && !podePular){ //Quando correndo e pulando, Pulo
            transitaAnimacoes(2);
        }
    }
    
    private void pular(){
        bool inputPulo = Input.GetKeyDown("space");
        if(inputPulo && podePular){
            rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;

            transitaAnimacoes(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D outro) { //Verifica se ele está no chão. Se estiver, pode pular    
        if(outro.gameObject.CompareTag("Chao")){
            podePular = true;
            transitaAnimacoes(0);
        }
    }

    private void rotaciona(float direcao){
       
        if(direcao != 0){
            this.transform.localScale = new Vector3(direcao,1f,1f);
        }
    }

    private void transitaAnimacoes(int idAnimacao){
        anim.SetInteger("Animacao", idAnimacao);
    }

}
