using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAbajoRoca : MonoBehaviour
{
   public bool boolRocaAbajo = false;
    
    void OnTriggerStay2D(Collider2D other) {
          if(other.tag == "Player") {
           
           boolRocaAbajo = true;

        }

    }


    void OnTriggerExit2D(Collider2D other) {

            
           boolRocaAbajo = false;

     }


}
