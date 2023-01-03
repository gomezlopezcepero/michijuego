using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAbajoRoca : MonoBehaviour
{
   PuntoMovimiento puntos;
   PlayerMovement player;
   RocaInteraction roca;

   public bool boolRocaAbajo = false;
   public bool cuerpoAbajo = false;
   public bool boolDentro = false;

      void Start()
    {
        puntos = FindObjectOfType<PuntoMovimiento>();
        player = FindObjectOfType<PlayerMovement>(); 
        roca = FindObjectOfType<RocaInteraction>(); 

    }


    void OnTriggerEnter2D(Collider2D other) {
         Debug.Log("abajosssssss");


          if(other.tag == "intPlayer") {
           
           boolRocaAbajo = true;
           roca.cambiarSprite();

          }

          if(other.GetComponent<Collider>().tag == "Cuerpo") {
           
           cuerpoAbajo = true;

          }

        
        

    }


    void OnTriggerExit2D(Collider2D other) {

      if(other.tag == "intPlayer") {

      boolDentro = false;
           boolRocaAbajo = false;
      roca.cambiarSprite();

         if(other.GetComponent<Collider>().tag == "Cuerpo") {
           
           cuerpoAbajo = false;

          }
      //    StartCoroutine(puntos.desactivarPuntos());
            

        }
            StartCoroutine(reiniciarRastreo());

    }

  IEnumerator reiniciarRastreo() {
    yield return new WaitForSecondsRealtime(0.2f);
      player.enUso = false;
    }


}
