using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{

    int puntero;
    [SerializeField] List<GameObject> botones = new List<GameObject>();
    [SerializeField] GameObject flechaDerecha;
    [SerializeField] GameObject flechaIzquierda;

    void Start()
    {


        for (int i=0; i<botones.Count; i++) {
                botones[i].SetActive(false);
        }

        botones[0].SetActive(true);
        flechaIzquierda.SetActive(false);

    }

    void Update()
    {
        
    }

    public void flechaAtras() {
        
        if(puntero != 0) {
            flechaDerecha.SetActive(true);

            botones[puntero].SetActive(false);
            puntero--;
            botones[puntero].SetActive(true);

            if(puntero == 0) {
                flechaIzquierda.SetActive(false);
            } 
        }

    }

    public void flechaAdelante() {
        
        if(puntero != botones.Count-1) {
            flechaIzquierda.SetActive(true);

            botones[puntero].SetActive(false);
            puntero++;
            botones[puntero].SetActive(true);

            if(puntero == botones.Count-1) {
                flechaDerecha.SetActive(false);
            } 

        } 

    }
 


}
