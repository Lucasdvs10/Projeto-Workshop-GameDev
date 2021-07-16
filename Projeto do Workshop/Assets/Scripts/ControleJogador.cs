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
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        andar();
        pular();
    }


    private void andar(){
        float direcao = Input.GetAxisRaw("Horizontal");
        rotaciona(direcao);

        rig.velocity = new Vector2(direcao * velocidade, rig.velocity.y);
    }
    
    private void pular(){
        bool inputPulo = Input.GetKeyDown("space");
        if(inputPulo && podePular){
            rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D outro) { //Verifica se ele está no chão. Se estiver, pode pular    
        if(outro.gameObject.CompareTag("Chao")){
            podePular = true;
        }
    }

    private void rotaciona(float direcao){
       
        if(direcao != 0){
            this.transform.localScale = new Vector3(direcao,1f,1f);
        }
    }

}
