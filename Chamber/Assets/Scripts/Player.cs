using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    
    float playerSpeed = 0.2f;

    static bool playerAlive = true;
    static bool isInputEnabled = true;

    private WeaponSettings gunType;

    public GameObject playerRayTarget;

    public GameObject playerWeapon;

    public GameObject gameManager;

    //Could be used in the future for reviving player feature
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
        InitializePlayer();
        EquipWeapon();
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
        Vector3 collidedObject = playerRayTarget.GetComponent<TargetRayObject>().ShootRayAgainstScene();
        
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

    void InitializePlayer()
    {
        isInputEnabled = true;
        playerAlive = true;

        transform.Find("Character").gameObject.SetActive(true);
        transform.gameObject.GetComponent<NavMeshAgent>().enabled = true;

        Time.timeScale = 1f;
    }

    void EquipWeapon()
    {
        Transform seletedWeapon = playerWeapon.transform;

        gunType = gameManager.GetComponent<GameManager>().LocateSelectedWeapon();
        
        GameObject currentWeapon = Instantiate<GameObject>(gunType.weaponModel);
        currentWeapon.name = gunType.weaponName;
        if (seletedWeapon != null)
        {
            currentWeapon.transform.position = 
                new Vector3(seletedWeapon.transform.position.x, seletedWeapon.transform.position.y, currentWeapon.transform.position.z);
            currentWeapon.transform.SetParent(seletedWeapon);
        }
    }

    public void DamagePlayer()
    {
        //Could make hp system

        DisablePlayer();
    }

    public void DisablePlayer()
    {
        //Remove player visibility
        transform.Find("Character").gameObject.SetActive(false);
        transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;

        //Remove player controls & shooting
        isInputEnabled = false;
        playerAlive = false;

        //Slow time down (fancy end effect)
        Time.timeScale = 0.5f;

        //Play death animation

        //Alert GameManager
        gameManager.GetComponent<GameManager>().GameOver();
    }


    //Getter & Setters
    public bool GetPlayerAliveStatus()
    {
        return playerAlive;
    }
}
