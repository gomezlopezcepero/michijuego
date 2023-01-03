using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    ScrollMenu scroll;
    PlayerMovement player;
    Menu menu;
    [SerializeField] AudioClip transSFX;
    
    [SerializeField] AudioClip backgroundSFX;
     [SerializeField] GameObject transicion;
     GameObject[] volume;

    public Sprite volumeon;
    public Sprite volumeoff;
    public bool esperar = true;

    // Start is called before the first frame update
    void Awake()
    {
         scroll = FindObjectOfType<ScrollMenu>();
        menu = FindObjectOfType<Menu>();
      //  
        

    }

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        volume = GameObject.FindGameObjectsWithTag("volume");


        if(AudioListener.volume == 1) {
            GameObject.Find("Volume").GetComponent<Image>().sprite = volumeon;
        } else {
            GameObject.Find("Volume").GetComponent<Image>().sprite = volumeoff;
        }

        AudioSource.PlayClipAtPoint(backgroundSFX, Camera.main.transform.position);

     }

    // Update is calleñd once per frame
    void Update()
    {
        
    }

    public void changeVolume() {
        Debug.Log(AudioListener.volume);
        if(AudioListener.volume == 1) {
            AudioListener.volume = 0;
            GameObject.Find("Volume").GetComponent<Image>().sprite = volumeoff;
        } else {
            AudioListener.volume = 1;
            GameObject.Find("Volume").GetComponent<Image>().sprite = volumeon;
        }
    }

   public void sinMovimientos() {

    Debug.Log("sin movimientos");

     //   ResetGameSession();

    }

    public void ResetGameSession() {
       // Debug.Log("isTrans");
        Debug.Log(esperar);
        if(!esperar) {
        
        esperar = true;
        StartCoroutine(player.desaparecerPlayer());
        


        AudioSource.PlayClipAtPoint(transSFX, Camera.main.transform.position);
        var cuerpa =Instantiate(transicion);
            StartCoroutine(reset());

        }

    }

    public void ResetMenu() {
       // Debug.Log("isTrans");
       Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }


    IEnumerator reset() {
        yield return new WaitForSecondsRealtime(2f);

         Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

  }
 


    public void IniciarJuego() {
        
        SceneManager.LoadScene("Selector Levels");
        

    }

    public void volverMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");

    }


    public void selectLevel(string level) {
        
        if(!scroll.isDragging) {
        SceneManager.LoadScene(level);
        }

    }


    public void SalirJuego() {

        Application.Quit();

    }

    public void abrirMenu() {
        
        menu.abrirMenu();
    }




}
