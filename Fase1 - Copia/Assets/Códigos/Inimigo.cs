using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

   private Transform alvo;

   [SerializeField]
   private float raioVisao;

   [SerializeField]
   private LayerMask layerAreaVisao;

   [SerializeField]
   private float velocidadeMovimento;

   [SerializeField]
   private float distanciaMinima;

   [SerializeField]
   private Rigidbody2D rigidbody;

   [SerializeField]
   private SpriteRenderer spriteRenderer;

   [SerializeField]
   private Animator animator;
   

   private void Update() {
    ProcurarJogador();
    if (this.alvo != null && MudarSprite.invisible == false){
      
    Mover();
    } 
    else {
      PararMovimentacao();
    }
   }

   private void Mover()
   {
      Vector2 posicaoAlvo = this.alvo.position;
      Vector2 posicaoAtual = this.transform.position;

      float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
      if (distancia >= this.distanciaMinima){
      if (posicaoAtual.x < posicaoAlvo.x) {
    
      this.rigidbody.velocity = (this.velocidadeMovimento * Vector2.right);
      this.spriteRenderer.flipX = false;

      } else if (posicaoAtual.x > posicaoAlvo.x) {
      this.rigidbody.velocity = (this.velocidadeMovimento * Vector2.left);
      this.spriteRenderer.flipX = true;
      }
      /*
      if (this.rigidbody.velocity.x > 0) {
        this.spriteRenderer.flipX = false;
      } else if (this.rigidbody.velocity.x < 0) {
        this.spriteRenderer.flipX = true;
      }
      */
      this.animator.SetBool("move", true);
      this.animator.SetBool("parado", false);
   } else {
     PararMovimentacao();
   }
}

private void PararMovimentacao()
{
  this.rigidbody.velocity = Vector2.zero;
  this.animator.SetBool("move", false);
  this.animator.SetBool("parado", true);
}

private void OnDrawGizmos(){
  Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
  if (this.alvo != null) {
    Gizmos.DrawLine(this.transform.position, this.alvo.position);
  }
}

private void ProcurarJogador() {
   
 Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
 if (colisor != null) {
  Vector2 posicaoAtual = this.transform.position;
  Vector2 posicaoAlvo = colisor.transform.position;
  Vector2 direcao = posicaoAlvo - posicaoAtual;
  direcao = direcao.normalized;

  RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao);
  if (hit.transform != null){
    if (hit.transform.CompareTag("player")) {
       this.alvo = hit.transform;
    }
    else{
      this.alvo = null;
    }
  }
  else {
    this.alvo = null;
  }

 }
 else {
  this.alvo = null;
 }
}
}

