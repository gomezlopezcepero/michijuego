using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaInteraction : MonoBehaviour
{

    PlayerMovement player;
    ColliderAbajoRoca abajo;
    ColliderArribaRoca arriba;
    ColliderDerechaRoca derecha;
    ColliderIzquierdaRoca izquierda;
    private float moveSpeed = 5f;
    float direction = 0;
    float valorTrans = 0.05f;
    float acumulado = 0;
    int opcion = 0;

    bool boolRoca = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        abajo = FindObjectOfType<ColliderAbajoRoca>();
        arriba = FindObjectOfType<ColliderArribaRoca>();
        derecha = FindObjectOfType<ColliderDerechaRoca>();
        izquierda = FindObjectOfType<ColliderIzquierdaRoca>();

    }

    // Update is called once per frame
    void Update()
    {
        if(boolRoca) {
            movimiento();
        }
    }


    void movimiento() {
        player.boolMover = false;
        if(opcion == 1) {
            if(direction > acumulado) {
                transform.Translate(0, valorTrans,0);
                acumulado = acumulado + valorTrans;
            } else {
                player.boolMover = true;
                boolRoca = false;
                
            }
        }

        if(opcion == 2) {
            if(direction < acumulado) {
                transform.Translate(0, valorTrans,0);
                acumulado = acumulado + valorTrans;
            } else {
                player.boolMover = true;
                boolRoca = false;
                
            }
        }

        if(opcion == 3) {
            if(direction > acumulado) {
                transform.Translate(valorTrans, 0 ,0);
                acumulado = acumulado + valorTrans;
            } else {
                player.boolMover = true;
                boolRoca = false;
                
            }
        }

        if(opcion == 4) {
            if(direction < acumulado) {
                transform.Translate(valorTrans, 0 ,0);
                acumulado = acumulado + valorTrans;
            } else {
                player.boolMover = true;
                boolRoca = false;
                
            }
        }
        
       // transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);

    }
    
    


    void OnMouseDown() {
        player.boolMover = false;
        if(abajo.boolRocaAbajo) {
            Debug.Log("Roca abajo");
            boolRoca = true;
            opcion = 1;
            direction = 7;
            acumulado = 0;
            valorTrans = 0.05f;
        }

        if(arriba.boolRocaArriba) {
            Debug.Log("Roca arriba");
            boolRoca = true;
            opcion = 2;
            direction = -7;
            acumulado = 0;
            valorTrans = -0.05f;
        }

        if(izquierda.boolRocaIzquierda) {
            Debug.Log("Roca izquierda");
            boolRoca = true;
            opcion = 3;
            direction = 7;
            acumulado = 0;
            valorTrans = 0.05f;
        }

        if(derecha.boolRocaDerecha) {
            Debug.Log("Roca derecha");
            boolRoca = true;
            opcion = 4;
            direction = -7;
            acumulado = 0;
            valorTrans = -0.05f;
        }
 StartCoroutine(player.interrumpirMovimiento(0.5f));
        
    }


}
