using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CerrarMenu() {
        player.enUso = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }


    public void abrirMenu() {
        player.enUso = true;
         Time.timeScale = 0;
        gameObject.SetActive(true);

    }


}
