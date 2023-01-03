using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirCuerpo : MonoBehaviour
{

    GameObject[] GOs;

    // Start is called before the first frame update
    void Start()
    {
        GOs = GameObject.FindGameObjectsWithTag("Cuerpo");
       gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void destruirCuerpo() {
      //  Destroy(gameObject);
    Debug.Log("importante");

 
    for (int i=0; i<GOs.Length; i++) {
 
      //  GOs[i].transform.SetParent(GameObject.Find("player").transform);
     }   


        
    }
}
