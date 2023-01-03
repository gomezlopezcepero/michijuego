using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocaHueco : MonoBehaviour
{

    PlayerMovement player;
    [SerializeField] AudioClip abrirSFX;

    [SerializeField] GameObject puertaRoca;
        [SerializeField] int huecoObjetivo = 1;

    int contHuecos = 0;
     bool boolHueco = true;
     

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Hueco") {
          if(boolHueco) {
            contHuecos++;
            Debug.Log(contHuecos+"lol");
            //boolHueco = false;

            if(huecoObjetivo <= contHuecos) {
                    huecosCompletado();
            }

          }
        }

    }


    void huecosCompletado() {
        Destroy(puertaRoca,0.5f);
        Debug.Log("sisisisisisi");
          AudioSource.PlayClipAtPoint(abrirSFX, Camera.main.transform.position);
        StartCoroutine(reiniciarRastreo());
    }

    IEnumerator reiniciarRastreo() {
    yield return new WaitForSecondsRealtime(1.0f);
      
    player.reiniciarRastreo();
    
}


}
