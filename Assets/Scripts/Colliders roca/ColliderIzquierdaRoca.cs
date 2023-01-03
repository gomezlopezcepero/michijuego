using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIzquierdaRoca : MonoBehaviour
{
       PuntoMovimiento puntos;
       RocaInteraction roca;

    public bool boolRocaIzquierda = false;
    PlayerMovement player;
    public bool cuerpoIzquierda = false;
     public bool boolDentro = false;

    void Start()
    {
         puntos = FindObjectOfType<PuntoMovimiento>();
         player = FindObjectOfType<PlayerMovement>(); 
         roca = FindObjectOfType<RocaInteraction>(); 

    }


    void OnTriggerEnter2D(Collider2D other) {

         boolDentro = true;

         if(other.tag == "intPlayer") {
           
           boolRocaIzquierda = true;
           roca.cambiarSprite();

        }

        if(other.tag == "Cuerpo") {
           
           cuerpoIzquierda = true;

          }


    }


    void OnTriggerExit2D(Collider2D other) {

      if(other.tag == "intPlayer") {

      boolDentro = false;
           boolRocaIzquierda = false;
      roca.cambiarSprite();
           
        
        if(other.tag == "Cuerpo") {
           
           cuerpoIzquierda = false;

          }
    //  StartCoroutine(puntos.desactivarPuntos());
      
      }
      StartCoroutine(reiniciarRastreo());
    
    }

  IEnumerator reiniciarRastreo() {
    yield return new WaitForSecondsRealtime(0.2f);
      player.enUso = false;
    }
    
}
