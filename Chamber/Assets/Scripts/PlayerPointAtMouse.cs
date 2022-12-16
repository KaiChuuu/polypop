using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointAtMouse : MonoBehaviour
{

    
    Vector3 mousePointIn3d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePointIn3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePointIn3d.y = transform.position.y;

        transform.LookAt(mousePointIn3d);
    }
}
