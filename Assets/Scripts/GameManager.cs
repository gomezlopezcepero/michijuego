using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void sinMovimientos() {

    Debug.Log("sin movimientos");

     //   ResetGameSession();

    }

    public void ResetGameSession() {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
 


    public void IniciarJuego() {

        SceneManager.LoadScene("Level 1");

    }


    public void SalirJuego() {

        Application.Quit();

    }




}
