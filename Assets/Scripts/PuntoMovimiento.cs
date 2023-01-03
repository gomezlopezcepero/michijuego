using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoMovimiento : MonoBehaviour
{

    PlayerMovement player;
    InteractablesPlayer interactable;

    GameManager game;
    Renderer rend;
    static float pasa = 0.001f;
     [SerializeField] float opacidad = 0f;
    [SerializeField] public bool jodermacho = false;
     GameObject[] GOs;
    public bool aparBool = true;
    // Start is called before the first frame update
    void Start()
    {

        GOs = GameObject.FindGameObjectsWithTag("Punto");

        player = FindObjectOfType<PlayerMovement>();
        interactable = FindObjectOfType<InteractablesPlayer>();
        game = FindObjectOfType<GameManager>();
        rend = gameObject.transform.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, opacidad);
        

        StartCoroutine(iniciarMovimiento(1));
        

    }

    // Update is called once per frame
    void Update()
    {

        
    }


public IEnumerator iniciarMovimiento(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        player.enUso = true;
        var pos =  player.getPosition();
        pos = new Vector3(pos.x,pos.y-13,pos.z);

        player.moverse(pos);
        StartCoroutine(iniciarMaullar(2));
        
    
//    cuerp = cuerpo;
    } 


    public IEnumerator iniciarMaullar(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        game.esperar = false;
        interactable.maullar();
    
//    cuerp = cuerpo;
    }


    void OnMouseDown() {
   //     Debug.Log(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject());

    if(player.enUso) {

    }

   Debug.Log(player.enUso+ "loxo");
        if(!player.enUso && player.iniciado) {
            player.enUso = true;
        player.moverse(transform.position);
        }
 
 
    }

    IEnumerator probarOtraVez() {
        yield return new WaitForSecondsRealtime(1f);
        
        resetearPuntos();

    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player") {
            if(aparBool) {
                aparBool = false;
           player.aparecer(transform.position);
            rend = gameObject.transform.GetComponent<Renderer>();
            Color matColor = rend.material.color;
            float alphaValue = rend.material.color.a;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
            }
        }

        if(other.tag == "Cuerpo") {
            
          // player.aparecer(transform.position);
        }


    }


    void OnTriggerStay2D(Collider2D other){

        if(other.tag == "Player") {




        }

    }



   public  void resetearPuntos() {

    pasa = 0;

    for (int i=0; i<GOs.Length; i++) {
        rend = GOs[i].transform.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        GOs[i].SetActive(true);
       // GOs[i].GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(desactivarPuntos());
     }   

    }


    public IEnumerator desactivarPuntos()
    {
        bool tiene = false;

        yield return new WaitForSecondsRealtime(0.5f);
        int cont = 0;
        for (int i=0; i<GOs.Length; i++) {
            rend = GOs[i].transform.GetComponent<Renderer>();
            if(rend.material.color.a != 1) {
                GOs[i].SetActive(false);
            }
            if(rend.material.color.a == 1) {
                tiene = true;
            }
 
        }


        if(!tiene) {
            
            player.reiniciarRastreo();

        }

        player.enUso = false;
       
    }

 


}
