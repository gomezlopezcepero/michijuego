using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractablesPlayer : MonoBehaviour
{
    [SerializeField] AudioClip comerPatataSFX;
    [SerializeField] AudioClip comerSFX;
    [SerializeField] AudioClip abrirSFX;
    [SerializeField] AudioClip maullarSFX;

    PlayerMovement player;
    PuntoMovimiento puntos;

    [SerializeField] float levelLoadDelay = 5f;
    [SerializeField] int migaObjetivo = 3;
    [SerializeField] GameObject puertaMiga;
    Animator myAnimator;
    int contMigas = 0;
    GameObject[] GOs;
    Renderer rend;
    bool boolMiga = true;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite;



    // Start is called before the first frame update
    void Start()
    {
        puntos = FindObjectOfType<PuntoMovimiento>();
         player = FindObjectOfType<PlayerMovement>();
        GOs = GameObject.FindGameObjectsWithTag("Miga");
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Finish") {
            AudioSource.PlayClipAtPoint(comerPatataSFX, Camera.main.transform.position);
            Destroy(other.gameObject,0.5f);
            myAnimator.SetBool("isEating", true);

            StartCoroutine(LoadNextLevel());


        }

        if(other.tag == "Miga") {
            if(boolMiga) {

                boolMiga = false;
                contMigas++;
                myAnimator.SetBool("isEating", true);
                AudioSource.PlayClipAtPoint(comerSFX, Camera.main.transform.position);

                other.gameObject.SetActive(false);
                
                Debug.Log(contMigas);
               // StartCoroutine(puntos.desactivarPuntos());
                if(migaObjetivo == contMigas) {
                    StartCoroutine(completado());
                    }
                StartCoroutine(StopEating());
            }   

        }

        if(other.tag == "Roca") {
           
           

        }

    }

    IEnumerator completado() {
        yield return new WaitForSecondsRealtime(1f);
        migasCompletado();
    }


    public void maullar() {

        myAnimator.SetBool("isMeowing", true);
        AudioSource.PlayClipAtPoint(maullarSFX, Camera.main.transform.position);

        StartCoroutine(StopMeowing());

    }

    void migasCompletado() {
        Destroy(puertaMiga,0.5f);
       
        StartCoroutine(reiniciarRastreo());
    }


public  void resetearMigas() {


    for (int i=0; i<GOs.Length; i++) {
      /*  rend = GOs[i].transform.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;
        rend.material.color = new Color(1f, 1f, 1f, 1f); */
        
        spriteRenderer = GOs[i].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = oldSprite;
      //  GOs[i].SetActive(true);
       // GOs[i].GetComponent<BoxCollider2D>().enabled = false;
     }   

    }

IEnumerator reiniciarRastreo() {
    yield return new WaitForSecondsRealtime(0.5f);
    player.reiniciarRastreo();
     AudioSource.PlayClipAtPoint(abrirSFX, Camera.main.transform.position);
    
}

IEnumerator StopEating() {
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("llegada");
        myAnimator.SetBool("isEating", false);
        boolMiga = true;
        StartCoroutine(puntos.desactivarPuntos());

    }


    IEnumerator StopMeowing() {
        yield return new WaitForSecondsRealtime(2f);

        myAnimator.SetBool("isMeowing", false);

    }


IEnumerator LoadNextLevel() {

        yield return new WaitForSecondsRealtime(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        } 

        //FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);

    }


}
