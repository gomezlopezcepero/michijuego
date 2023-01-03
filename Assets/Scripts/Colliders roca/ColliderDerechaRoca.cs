using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDerechaRoca : MonoBehaviour
{
      PuntoMovimiento puntos;
      RocaInteraction roca;

    public bool boolRocaDerecha = false;
    PlayerMovement player;
    public bool cuerpoDerecha = false;
     public bool boolDentro = false;


    void Start()
    {
        puntos = FindObjectOfType<PuntoMovimiento>();
         player = FindObjectOfType<PlayerMovement>(); 
         roca = FindObjectOfType<RocaInteraction>(); 

    }

    void OnTriggerEnter2D(Collider2D other) {


         if(other.tag == "intPlayer") {
           
           boolRocaDerecha = true;
           Debug.Log(boolRocaDerecha);
           roca.cambiarSprite();

        }

        if(other.tag == "Cuerpo") {
           
           cuerpoDerecha = true;

          }

        }


    


    void OnTriggerExit2D(Collider2D other) {

      if(other.tag == "intPlayer") {
     // boolDentro = false;
      boolRocaDerecha = false;
      roca.cambiarSprite();

        if(other.tag == "Cuerpo") {
      
      cuerpoDerecha = false;
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