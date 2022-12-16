using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    
    float playerSpeed = 0.05f;

    static bool playerAlive = true;
    static bool isInputEnabled = true;

    public WeaponSettings gunType;

    public GameObject playerRayTarget;

    public GameObject playerWeapon;

    static private Player _S;
    static public Player S
    {
        get
        {
            return _S;
        }
        set
        {
            if (_S == null)
            {
                _S = value;
            }
            else
            {
                Debug.Log("Trying to overwrite the Player singleton!");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        equipWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputEnabled)
        {
            float xControls = Input.GetAxis("Horizontal");
            float yControls = Input.GetAxis("Vertical");

            Vector3 player_movement = new Vector3(xControls, 0, yControls);
            if (player_movement.magnitude > 1)
            {
                player_movement.Normalize();
            }

            playerAgent.Move(player_movement * playerSpeed);

            if (Input.GetButtonDown("Fire1"))
            {
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        //calculate if collided
        Vector3 collidedObject = playerRayTarget.GetComponent<TargetRayObject>().shootRayAgainstScene();
        
        Debug.Log(collidedObject + " hit position");
        if(collidedObject == new Vector3(-100, -100, -100))
        {
            //Default angle for bullets (i.e perfectly horizontal with weapon object)
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos3D.y = playerWeapon.transform.position.y;
            gunType.weaponModel.GetComponent<IWeaponTemplate>().fireWeapon(gunType.bulletType, playerWeapon.transform, mousePos3D);
        } else
        {
            //Angle bullets toward enemy (closest raycasted enemy)
            gunType.weaponModel.GetComponent<IWeaponTemplate>().fireWeapon(gunType.bulletType, playerWeapon.transform, collidedObject);
        }        
    }

    void equipWeapon()
    {
        Transform seletedWeapon = playerWeapon.transform;

        GameObject currentWeapon = Instantiate<GameObject>(gunType.weaponModel);
        currentWeapon.name = gunType.weaponName;
        if (seletedWeapon != null)
        {
            currentWeapon.transform.position = 
                new Vector3(seletedWeapon.transform.position.x, seletedWeapon.transform.position.y, currentWeapon.transform.position.z);
            currentWeapon.transform.SetParent(seletedWeapon);
        }
    }

    public void disablePlayer()
    {
        //Remove player visibility
        transform.GetChild(0).gameObject.SetActive(false);

        //Remove player controls & shooting
        //Stop player from being affected by physics
        playerAlive = false;
        isInputEnabled = false;
        
        //rigid.isKinematic = true;

        //Play death animation
    }


    //Getter & Setters
    public bool getPlayerAliveStatus()
    {
        return playerAlive;
    }
}
