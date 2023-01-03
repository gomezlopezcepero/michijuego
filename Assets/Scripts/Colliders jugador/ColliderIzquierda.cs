using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIzquierda : MonoBehaviour
{
   
   
    PlayerMovement player;
    InteractablesPlayer interactable;

    bool colisionIzquierda = true;
     Vector3 sca;
    float trans;
    float valorTrans = 0.75f;



    // Start is called before the first frame update
    void Start()
    {
        sca = transform.localScale;
        player = FindObjectOfType<PlayerMovement>();
        interactable = FindObjectOfType<InteractablesPlayer>();
     }

    // Update is called once per frame
    void Update()
    {
        valorTrans = 70f * Time.deltaTime;
        if(!colisionIzquierda) {
        //    transform.localScale += new Vector3(0,-0.3f,0);
            transform.Translate(0, valorTrans,0);
            trans = trans + valorTrans;
         }

         if(trans > 150 || trans < -150) {
            StartCoroutine(corregirCollider());
         }

    }

    public IEnumerator corregirCollider()
    {
        Debug.Log(trans+ "trans");
        yield return new WaitForSecondsRealtime(1f);

        restaurarEstado();
        colisionIzquierda = false;
        player.reiniciarRastreo();
    } 


    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Walls") {

            colisionIzquierda = true;
            restaurarEstado();
         }

        if(other.tag == "Punto") {

            other.gameObject.SetActive(true);
            Renderer rend = other.gameObject.transform.GetComponent<Renderer>();
            Color matColor = rend.material.color;
            float alphaValue = rend.material.color.a;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 1f);
        }

        if(other.tag == "Miga") {
            interactable.spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            interactable.spriteRenderer.sprite = interactable.newSprite;
           /* Renderer rend = other.gameObject.transform.GetComponent<Renderer>();
            Color matColor = rend.material.color;
            float alphaValue = rend.material.color.a;
            rend.material.color = new Color(1f, 1f, 0, 1f);
            other.gameObject.SetActive(true); */
        }

        if(other.tag == "Cuerpo") {
            colisionIzquierda = true;
            restaurarEstado();

            

        }

    }

    void restaurarEstado() {

        transform.localScale = sca;
        transform.Translate(0, -(trans),0);
        trans = 0;

    }

    public void resetearCollider() {
        colisionIzquierda = false;
    }

}
