using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool collidedWithObject()
    {
        return true;
    }

    public Vector3 shootRayAgainstScene()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(hit.transform.gameObject.GetComponent("TargetRayObject") == null)
            {
                //Should not occur
                Debug.Log("Missing Target Script!");
                return miss;
            }

            Debug.Log("Did Hit Target");
            return hit.transform.gameObject.GetComponent<TargetRayObject>().actualObjectPosition();          
        }
        else
        {
            Debug.Log("Did not Hit Target");
            return miss;
        }
    }

    public Vector3 actualObjectPosition()
    {
        return target.transform.position;
    }
}
