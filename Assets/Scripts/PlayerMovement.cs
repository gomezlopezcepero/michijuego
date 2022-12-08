using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    PuntoMovimiento puntos;
    ColliderAbajo abajo;
    ColliderArriba arriba;
    ColliderDerecha derecha;
    ColliderIzquierda izquierda;

    private Vector2 screenPoint;
     Rigidbody2D myRigidbody;
     BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;

     Vector2 posActual;
    public bool boolMover = false;
    bool unaVez = false;

    List<Vector3> pasos = new List<Vector3>();
    Coroutine theCoroutine;


    float posActualX = 0;
    float posActualY = 0;
    int ultimo = 2;



    private Vector3 touchPosition;
    private Vector3 direction;
    private float moveSpeed = 5f;
    float ajusteCuerpo = 4;
    float ajusteGiro = 0.5f;
    public bool enUso = false;
    bool giro = false;
    public bool iniciado = false;


//Colliders que rastrean las posibilidades de movimeinto

    List<GameObject> cuerpos = new List<GameObject>();
    [SerializeField] GameObject cuerpo;
    [SerializeField] GameObject cuerpoGiro;
    GameObject cuerp; 

 


    void Start()
    {
        enUso = false;
        cuerp = null;
        puntos = FindObjectOfType<PuntoMovimiento>();
        abajo = FindObjectOfType<ColliderAbajo>();
        arriba = FindObjectOfType<ColliderArriba>();
        derecha = FindObjectOfType<ColliderDerecha>();
        izquierda = FindObjectOfType<ColliderIzquierda>();

        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        posActualX = transform.position.x;
        posActualY = transform.position.y;
        pasos.Add(transform.position);

        StartCoroutine(interrumpirMovimiento(1));

    }



    void Update()
    {
         
       if(boolMover && iniciado)  {
        movimiento();
       } 

     }


    void movimiento() {

       // theCoroutine = StartCoroutine(interrumpirMovimiento());

        float step = moveSpeed;

        transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);
        

        if(direction == transform.position) {
            reiniciarRastreo();
        }  


        float y = Mathf.Abs(direction.y) - Mathf.Abs(pasos[pasos.Count-2].y);
        float x =Mathf.Abs(direction.x) - Mathf.Abs(pasos[pasos.Count-2].x);
                
            if(Mathf.Abs(y) > Mathf.Abs(x)) {

 
                if(direction.y < pasos[pasos.Count-2].y && unaVez) {
                    if(ultimo != 2) {
                     //   cuerp = cuerpoGiro;
                     transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,transform.position.y-ajusteGiro,transform.position.z), direction, 5f);
                         
                         giro = true;
                    } else {
                        cuerp = cuerpo;
                        giro = false;
                        
                    //    var cuerpa =Instantiate(cuerpo, pasos[pasos.Count-2], transform.rotation);
                    }

                    transform.rotation =  new Quaternion(0,0,0,0);
                    ultimo = 2;
                } else if(direction.y > pasos[pasos.Count-2].y && unaVez) {
                    if(ultimo != 3) {
                     //   cuerp = cuerpoGiro;
                     transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,transform.position.y+ajusteGiro,transform.position.z), direction, 5f);
                        
                        giro = true;
                    } else {
                        cuerp = cuerpo;
                        giro = false;
                        
                    //    var cuerpa =Instantiate(cuerpo, pasos[pasos.Count-2], transform.rotation);
                    }
                    transform.rotation =  new Quaternion(0,0,180,0);
                    ultimo = 3;
                }
                  

             
            } else if(Mathf.Abs(y) < Mathf.Abs(x)) {
                

                //registra cuando se ha recorrido la distancia equivalente a su collider
                
                if(direction.x < pasos[pasos.Count-2].x && unaVez) {
                    
                    if(ultimo != 0) {
                     //   cuerp = cuerpoGiro;
                     transform.position = Vector3.MoveTowards(new Vector3(transform.position.x-ajusteGiro,transform.position.y,transform.position.z), direction, 5f);
                         
                        giro = true;
                    } else {
                        cuerp = cuerpo;
                        giro = false;
                         
                    //    var cuerpa = Instantiate(cuerpo, pasos[pasos.Count-2], transform.rotation);
                    //    cuerpa.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                    }
                    transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
                    ultimo = 0;
                } else if(direction.x > pasos[pasos.Count-2].x && unaVez){
                    
                    if(ultimo != 1) {
                     //   cuerp = cuerpoGiro;
                     transform.position = Vector3.MoveTowards(new Vector3(transform.position.x+ajusteGiro,transform.position.y,transform.position.z), direction, 5f);
                         
                         giro = true;
                    } else {
                        cuerp = cuerpo;
                        giro = false;
                       
                    //    var cuerpa = Instantiate(cuerpo, pasos[pasos.Count-2], transform.rotation);
                    //    cuerpa.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));

                    }
                    
                    transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                    ultimo = 1;
                }


                
                    
                //    var cuerpa = Instantiate(cuerpo, pasos[pasos.Count-2], transform.rotation);
                //    cuerpa.transform.Rotate(0,0,90);

                     // nuevoCuerpo.transform.parent = gameObject.transform;


 
            } 
            // myRigidbody.velocity = new Vector2(direction.x, direction.y) * moveSpeed;                


        
        unaVez = false;
        
     }


public IEnumerator interrumpirMovimiento(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        iniciado = true;
        reiniciarRastreo();
    
//    cuerp = cuerpo;
    } 


    public void reiniciarRastreo()
    {
        puntos.resetearPuntos();
        //estos reseteos son necesarios para que los colliders  se puedan disparar una y otra vez
        arriba.resetearCollider();
        abajo.resetearCollider();
        derecha.resetearCollider();
        izquierda.resetearCollider();
        
        boolMover = false;

    } 

    public IEnumerator aparecerCuerpo(Vector3 pos)
    {
        float velocidadSpawn;

        if(giro) {
            velocidadSpawn = 0f;
            giro = false;
        } else {
            velocidadSpawn = 0.5f;
        }

        if(ultimo == 2) {
            pos = new Vector3(pos.x,(pos.y+ajusteCuerpo),pos.z);
        } else if(ultimo == 3) {
            pos = new Vector3(pos.x,(pos.y-ajusteCuerpo),pos.z);
        } else if(ultimo == 0) {
            pos = new Vector3((pos.x+ajusteCuerpo), pos.y,pos.z);
        } else if(ultimo == 1) {
            pos = new Vector3((pos.x-ajusteCuerpo), pos.y,pos.z);
        }
        yield return new WaitForSecondsRealtime(velocidadSpawn);

    cuerpos.Add(cuerpo);
    var cuerpa =Instantiate(cuerpo, pos, transform.rotation);
//    cuerp = cuerpo;
    } 

    public void aparecer(Vector3 pos) {

        StartCoroutine(aparecerCuerpo(pos));
        

    }

   public void moverse(Vector3 pos) {
        direction = pos;
        pasos.Add(direction);
        boolMover = true;
        unaVez = true;
    }
 

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Punto") {
           // Destroy(other.gameObject,0.5f);
        }

    }

    

    void OnTriggerExit2D(Collider2D other) {

 
    }


}
