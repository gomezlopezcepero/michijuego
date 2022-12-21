using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    ScrollMenu scroll;
    Menu menu;



    // Start is called before the first frame update
    void Awake()
    {
        scroll = FindObjectOfType<ScrollMenu>();
        menu = FindObjectOfType<Menu>();

    }

    // Update is calleñd once per frame
    void Update()
    {
        
    }


   public void sinMovimientos() {

    Debug.Log("sin movimientos");

     //   ResetGameSession();

    }

    public void ResetGameSession() {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
 


    public void IniciarJuego() {
        
        if(!scroll.isDragging) {
        SceneManager.LoadScene("Selector Levels");
        }

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
