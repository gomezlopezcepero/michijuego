using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractablesPlayer : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 5f;
    [SerializeField] int migaObjetivo = 3;
    [SerializeField] GameObject puertaMiga;
    Animator myAnimator;
    int contMigas = 0;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Finish") {
            Destroy(other.gameObject,0.5f);
            myAnimator.SetBool("isEating", true);

            StartCoroutine(LoadNextLevel());


        }

        if(other.tag == "Miga") {
            contMigas++;
            Destroy(other.gameObject,0.5f);
            Debug.Log(contMigas);
            if(migaObjetivo == contMigas) {
                migasCompletado();
            }

        }

        if(other.tag == "Roca") {
           
           

        }

    }


    void migasCompletado() {
        Destroy(puertaMiga,0.5f);
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
