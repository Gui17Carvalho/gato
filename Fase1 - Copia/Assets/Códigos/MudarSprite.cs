using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Namespace para utilizar a biblioteca UI da Unity

public class MudarSprite : MonoBehaviour
{
    public  Sprite spriteInvisivel; // Variável pública para você colocar o sprite que irá substituir o original
    public  Sprite spriteNormal; // Variável pública para você colocar o sprite que irá substituir o original
    private SpriteRenderer renderSprite; //Varipavel privada do tipo SpriteRenderer, que o objeto 2D possui.
    public static bool invisible = false;
    private bool possoficarinvisivel = true;



    

    void Start ()
    {
        renderSprite = GetComponent<SpriteRenderer>(); //Atribui a variável renderSprite o componente de SpriteRenderer presente no objeto 2D, na inicialização da cena.
        renderSprite.sprite = spriteNormal;


    }

   private IEnumerator esperarTempo(){
         yield return new WaitForSeconds(5);
         voltarNormal();
         possoficarinvisivel = false;
         yield return new WaitForSeconds(5);
         possoficarinvisivel = true;
   }

   private void  ficarInvisivel(){
            renderSprite.sprite = spriteInvisivel;
            invisible = true;
            print(invisible);

            StartCoroutine(esperarTempo());


    

   }
   private void voltarNormal(){
            renderSprite.sprite = spriteNormal;
            invisible = false;
            print(invisible);

   }
 
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E) && invisible == false && possoficarinvisivel == true) //Enquando a cena estiver rodando e pressionar a tecla E, ele irá substituir o sprite original pelo colocado na variável pública spriteInvisivel.
         {
            ficarInvisivel();

         }
         else if(Input.GetKeyDown(KeyCode.E) && invisible == true){
            voltarNormal();
         }
    }
}