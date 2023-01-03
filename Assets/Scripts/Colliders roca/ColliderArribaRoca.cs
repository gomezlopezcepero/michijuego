using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderArribaRoca : MonoBehaviour
{
    PuntoMovimiento puntos;
    RocaInteraction roca;

    public bool cuerpoArriba = false;
    public bool boolRocaArriba = false;
    public bool boolDentro = false;
    PlayerMovement player;


  void Start()
    {
        puntos = FindObjectOfType<PuntoMovimiento>();
         player = FindObjectOfType<PlayerMovement>(); 
      roca = FindObjectOfType<RocaInteraction>(); 
    }

    void OnTriggerEnter2D(Collider2D other) {
      
           Debug.Log("arribassssssss");
   

         if(other.tag == "intPlayer") {
           boolDentro = true;      
           boolRocaArriba = true;
           roca.cambiarSprite();

        }

        if(other.tag == "Cuerpo") {
           
          cuerpoArriba = true;

        }


    }


    void OnTriggerExit2D(Collider2D other) {

      if(boolDentro) {

  if(other.tag == "intPlayer") {

  Debug.Log("tio que cojones pasa no se tio");
        boolDentro = false;
        boolRocaArriba = false;
        roca.cambiarSprite();
        if(other.tag == "Cuerpo") {
            
          cuerpoArriba = false;

        }
      //  StartCoroutine(puntos.desactivarPuntos());


        boolDentro = false;

        }

      }
        StartCoroutine(reiniciarRastreo());

    }

  IEnumerator reiniciarRastreo() {
    yield return new WaitForSecondsRealtime(0.2f);
      player.enUso = false;
    }

}
