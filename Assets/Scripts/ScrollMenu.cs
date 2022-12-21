using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMenu : MonoBehaviour
{
   private Plane dragPlane;

    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    private Vector3 offset;
    public bool isDragging  = true;


    private Camera myMainCamera; 
    float y;

    Vector3 posClick;

    void Start()
    {
        myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        y = transform.position.y;
    }

    void OnMouseDown()
    {
        posClick = transform.position;
        
        isDragging = true;
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    void OnMouseDrag()
    {   
        
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;

        transform.position = new Vector2(transform.position.x, y);
        
        
    }

    void OnMouseUp()
    {   
        if(posClick.x == transform.position.x) {
        isDragging = false;
        }
    }
}
