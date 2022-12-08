using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDerechaRoca : MonoBehaviour
{
    public bool boolRocaDerecha = false;
    
    void OnTriggerStay2D(Collider2D other) {

         if(other.tag == "Player") {
           
           boolRocaDerecha = true;

        }

    }


    void OnTriggerExit2D(Collider2D other) {

            
           boolRocaDerecha = false;

 
    }
}
