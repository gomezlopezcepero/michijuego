using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIzquierdaRoca : MonoBehaviour
{
    public bool boolRocaIzquierda = false;
    
    void OnTriggerStay2D(Collider2D other) {

         if(other.tag == "Player") {
           
           boolRocaIzquierda = true;

        }

    }


    void OnTriggerExit2D(Collider2D other) {
           
           boolRocaIzquierda = false;

        

    }
}
