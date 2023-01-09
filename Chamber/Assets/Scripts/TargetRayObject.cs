using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class TargetRayObject : MonoBehaviour
{
    //default miss value
    Vector3 miss;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        miss = new Vector3(-100, -100, -100);

        //Create ray target collider
        transform.gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 20, target.transform.position.z);
    }

    public bool CollidedWithObject()
    {
        return true;
    }

    public Vector3 ShootRayAgainstScene()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(hit.transform.gameObject.GetComponent("TargetRayObject") == null)
            {
                //When you shoot into spawner
                //Debug.Log("Missing Target Script!");
                return miss;
            }

            //Debug.Log("Did Hit Target");
            return hit.transform.gameObject.GetComponent<TargetRayObject>().ActualObjectPosition();          
        }
        else
        {
            //Debug.Log("Did not Hit Target");
            return miss;
        }
    }

    public Vector3 ActualObjectPosition()
    {
        return target.transform.position;
    }
}
