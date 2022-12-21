using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIzquierda : MonoBehaviour
{
   
   
    PlayerMovement player;

    bool colisionIzquierda = true;
     Vector3 sca;
    float trans;
    float valorTrans = 0.75f;



    // Start is called before the first frame update
    void Start()
    {
        sca = transform.localScale;
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

         if(trans < 350) {

         //   StartCoroutine(player.interrumpirMovimiento(0.5f));

        //    StartCoroutine(corregirCollider());
         }

    }

    public IEnumerator corregirCollider()
    {

        yield return new WaitForSecondsRealtime(1f);

        restaurarEstado();
        colisionIzquierda = false;
        StartCoroutine(player.interrumpirMovimiento(1));
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
