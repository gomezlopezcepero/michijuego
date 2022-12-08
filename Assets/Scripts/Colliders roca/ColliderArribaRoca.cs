using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderArribaRoca : MonoBehaviour
{
 
 
 public bool boolRocaArriba = false;
    
    void OnTriggerStay2D(Collider2D other) {

         if(other.tag == "Player") {
           
           boolRocaArriba = true;

        }

    }


    void OnTriggerExit2D(Collider2D other) {
              
           boolRocaArriba = false;

 
    }

}
