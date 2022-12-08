using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoMovimiento : MonoBehaviour
{
    [SerializeField] GameObject playerMovement;

    PlayerMovement player;
    GameManager game;
    Renderer rend;
    static float pasa = 0.001f;
     [SerializeField] float opacidad = 0f;
[SerializeField] public bool jodermacho = false;
GameObject[] GOs;

    // Start is called before the first frame update
    void Start()
    {

        GOs = GameObject.FindGameObjectsWithTag("Punto");

        player = FindObjectOfType<PlayerMovement>();
        game = FindObjectOfType<GameManager>();
        rend = gameObject.transform.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, opacidad);

    }

    // Update is called once per frame
    void Update()
    {

        
    }


    void OnMouseDown() {
        
        if(!player.enUso && player.iniciado) {
            player.enUso = true;
        player.moverse(transform.position);
        }
 
 
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player") {
           player.aparecer(transform.position);
            rend = gameObject.transform.GetComponent<Renderer>();
            Color matColor = rend.material.color;
            float alphaValue = rend.material.color.a;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
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
            
            game.sinMovimientos();

        }

        player.enUso = false;
       
    }

 


}
