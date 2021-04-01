using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCreate : MonoBehaviour
{
    public Transform Cube;
    public Rigidbody bead;
    public float absoluteZPosition = 0f;
    public float absoluteZScale = 0.5f;
    private Transform activeObject;
    private Vector3 startPosition;
    public int dontfast = 0;
    public float maxline = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        // foreach (Touch touch in Input.touches){
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 position = Camera.main.ScreenToWorldPoint( touch.position );
        position.z = absoluteZPosition;

        // Left-Click
        if (((Input.GetMouseButton(0)) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)) && (maxline > 0))
        {
            if (dontfast == 0)
            {
                dontfast = 1;
                activeObject = Instantiate(Cube, position, transform.rotation) as Transform;
                startPosition = position;
                maxline--;
                Form(activeObject, startPosition, position);
            }
        }
        else { dontfast = 0; }

        /*            //Right-Click
               if( Input.GetMouseButtonDown(1) ) {
                 Instantiate( bead, position, transform.rotation );  
               }
        */
        if ((Input.GetMouseButton(0)) || (Input.touchCount == 1))
        {
            Form(activeObject, startPosition, position);
        }
        //   }
    }

    private void Form(Transform shape, Vector3 start, Vector3 end)
    {
        Vector3 scale = end - start;
        scale.z = absoluteZScale;
        if ((scale.x >= 0.1f) || (scale.x <= 0.1f)) { scale.y = 0.05f; }
        if (scale.x >= 4) { scale.x = 4; }
        if (scale.x <= -4) { scale.x = -4; }
        if (scale.x > 0 && scale.x < 0.6f) { scale.x = 0.6f; }
        if (scale.x < 0 && scale.x > -0.6f) { scale.x = -0.6f; }
        if (scale.x == 0) { scale.x = 0.6f; }

        Vector3 pos = start + scale / 2;
        pos.z = absoluteZPosition;

        shape.position = pos;
        shape.localScale = scale;
    }
}
