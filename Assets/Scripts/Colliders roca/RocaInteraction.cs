using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaInteraction : MonoBehaviour
{
    PuntoMovimiento puntos;
    PlayerMovement player;
    ColliderAbajoRoca abajo;
    ColliderArribaRoca arriba;
    ColliderDerechaRoca derecha;
    ColliderIzquierdaRoca izquierda;

    [SerializeField] AudioClip rocaSFX;
    

    private float moveSpeed = 7f;
    float direction = 0;
    float valorTrans = 0.05f;
    float acumulado = 0;
    int opcion = 0;
    Renderer rend;
    bool rastreo = true;
 
    bool boolRoca = false;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite;


      
    // Start is called before the first frame update
    void Start()
    {
        puntos = FindObjectOfType<PuntoMovimiento>();
        player = FindObjectOfType<PlayerMovement>();
        abajo = FindObjectOfType<ColliderAbajoRoca>();
        arriba = FindObjectOfType<ColliderArribaRoca>();
        derecha = FindObjectOfType<ColliderDerechaRoca>();
        izquierda = FindObjectOfType<ColliderIzquierdaRoca>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boolRoca) {
            
            movimiento();
        }
        

    }

    public void cambiarSprite() {

        if(arriba.boolRocaArriba || abajo.boolRocaAbajo || izquierda.boolRocaIzquierda || derecha.boolRocaDerecha ) {
            /*
            rend = gameObject.transform.GetComponent<Renderer>();
            Color matColor = rend.material.color;
            float alphaValue = rend.material.color.a;
            rend.material.color = new Color(1f, 1f, 0, 1f); */
            spriteRenderer.sprite = newSprite; 
        }

        if(!arriba.boolRocaArriba && !abajo.boolRocaAbajo && !izquierda.boolRocaIzquierda && !derecha.boolRocaDerecha ) {

           spriteRenderer.sprite = oldSprite; 
        

        }

    }


    void movimiento() {
        player.boolMover = false;
        player.enUso = true;

        if(opcion == 1) {
            if(direction > acumulado) {
                
                transform.Translate(0, valorTrans,0);
                acumulado = acumulado + valorTrans;
            } else {
                //player.boolMover = true;
                //player.enUso = false;
                boolRoca = false;
                
            }
            
        }

        if(opcion == 2) {
            if(direction < acumulado) {
                transform.Translate(0, valorTrans,0);
                acumulado = acumulado + valorTrans;
            } else {
                //player.boolMover = true;
                //player.enUso = false;
                boolRoca = false;
                
            }
            
        }

        if(opcion == 3) {
            if(direction > acumulado) {
                transform.Translate(valorTrans, 0 ,0);
                acumulado = acumulado + valorTrans;
            } else {
                //player.boolMover = true;
                //player.enUso = false;
                boolRoca = false;
                
            }
            
        }

        if(opcion == 4) {
            if(direction < acumulado) {
                transform.Translate(valorTrans, 0 ,0);
                acumulado = acumulado + valorTrans;
            } else {
                //player.boolMover = true;
                //player.enUso = false;
                boolRoca = false;
                
            }
            
        }
        
       // transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);

    }
    


    void OnMouseDown() {
        player.boolMover = false;
        boolRoca = false;
        if(abajo.boolRocaAbajo && !arriba.cuerpoArriba) {
            AudioSource.PlayClipAtPoint(rocaSFX, Camera.main.transform.position);
            Debug.Log("Roca abajo");
            boolRoca = true;
            opcion = 1;
            direction = 7;
            acumulado = 0;
            valorTrans = 9f * Time.deltaTime;
            if(rastreo) {
            rastreo = false;
            StartCoroutine(reiniciarRastreo());
            }
        }

        if(arriba.boolRocaArriba && !abajo.cuerpoAbajo) {
            AudioSource.PlayClipAtPoint(rocaSFX, Camera.main.transform.position);
            Debug.Log("Roca arriba");
            boolRoca = true;
            opcion = 2;
            direction = -7;
            acumulado = 0;
            valorTrans = -9f * Time.deltaTime;
            if(rastreo) {
            rastreo = false;
            StartCoroutine(reiniciarRastreo());
            }
        }

        if(izquierda.boolRocaIzquierda && !derecha.cuerpoDerecha) {
            AudioSource.PlayClipAtPoint(rocaSFX, Camera.main.transform.position);
            Debug.Log("Roca izquierda");
            boolRoca = true;
            opcion = 3;
            direction = 7;
            acumulado = 0;
            valorTrans = 9f * Time.deltaTime;;
            if(rastreo) {
            rastreo = false;
            StartCoroutine(reiniciarRastreo());
            }
        }

        if(derecha.boolRocaDerecha && !izquierda.cuerpoIzquierda) {
            AudioSource.PlayClipAtPoint(rocaSFX, Camera.main.transform.position);
            Debug.Log("Roca derecha");
            boolRoca = true;
            opcion = 4;
            direction = -7;
            acumulado = 0;
            valorTrans = -9f * Time.deltaTime;;
            if(rastreo) {
            rastreo = false;
            StartCoroutine(reiniciarRastreo());
            }
        }
        
        
    }


IEnumerator reiniciarRastreo() {
    yield return new WaitForSecondsRealtime(1.0f);
    player.reiniciarRastreo();
    StartCoroutine(puntos.desactivarPuntos());
    rastreo = true;
     player.enUso = false;
}


}
