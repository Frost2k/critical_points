using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_line : MonoBehaviour
{
    private LineRenderer line;
    public GameObject cp;
    GameObject _cpLight;
    // Start is called before the first frame update
    void Start()
    {

        line = cp.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //if(_cp.GetComponent<LineRenderer>().enabled == false)
            //  if ( Input.GetMouseButtonDown(0)){
            //     line.enabled = !line.enabled;
            //  }
        // RaycastHit hitInfo = new RaycastHit ();
        //     if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo)) {
        //     Debug.Log ("Object Hit is " + hitInfo.collider.gameObject.name);

        //     //If you want it to only detect some certain game object it hits, you can do that here
        //     if (hitInfo.collider.gameObject.CompareTag ("critical_point")&& Input.GetMouseButtonDown(0)) {
        //         Debug.Log ("Dog hit");
        //         this.line.enabled = !line.enabled;
        //         //do something to dog here
        //     } else if (hitInfo.collider.gameObject.CompareTag ("Cat")) {
        //         Debug.Log ("Cat hit");
        //         //do something to cat here
        //     }
        // } 
        //}
        // if(_cp.GetComponent<LineRenderer>().enabled == true)
        //     if ( Input.GetMouseButtonDown(0)){
        //         _cp.GetComponent<LineRenderer>().enabled = false;
        //    }
        OnMouseOver();
    }

        void OnMouseOver(){
            if(Input.GetMouseButtonDown(0)){
                // Whatever you want it to do.
                //If you want it to only detect some certain game object it hits, you can do that here
                // if (gameObject.CompareTag ("critical_point")) {
                //     Debug.Log ("Dog hit");
                    line.enabled = !line.enabled;
                    //do something to dog here
                // } else if (gameObject.CompareTag ("Cat")) {
                //     Debug.Log ("Cat hit");
                //     //do something to cat here
                // }
            }
        }
}
