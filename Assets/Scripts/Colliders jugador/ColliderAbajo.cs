using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAbajo : MonoBehaviour
{

    bool colisionAbajo = true;
    PuntoMovimiento punto;
      Vector3 sca;
      float trans;
      [SerializeField] float valorTrans = -0.05f;



    // Start is called before the first frame update
    void Start()
    {
        sca = transform.localScale;
     }

    // Update is called once per frame
    void Update()
    {
        if(!colisionAbajo) {
            transform.localScale += new Vector3(0,-0.3f,0);
            transform.Translate(0, valorTrans,0);
            trans = trans + valorTrans;
         }

         if(trans < -3) {
 
            StartCoroutine(corregirCollider());
         }

    }


    public IEnumerator corregirCollider()
    {

        yield return new WaitForSecondsRealtime(1f);

        restaurarEstado();
        colisionAbajo = false;
    } 


    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Walls") {
            colisionAbajo = true;

            restaurarEstado();
        }

        if(other.tag == "Punto") {

            Renderer rend = other.gameObject.transform.GetComponent<Renderer>();
            Color matColor = rend.material.color;
            float alphaValue = rend.material.color.a;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 1f);
            other.gameObject.SetActive(true);
        }

        if(other.tag == "Cuerpo") {

            colisionAbajo = true;
            restaurarEstado();
        }

        

    }


    void restaurarEstado() {

        transform.localScale = sca;
        transform.Translate(0, -(trans),0);
        trans = 0;

    }


    public void resetearCollider() {
        colisionAbajo = false;
    }


}
