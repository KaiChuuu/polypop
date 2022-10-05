using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody rigid;
    float player_speed = 3;

    static bool playerAlive = true;
    static bool isInputEnabled = true;

    public WeaponSettings gunType;

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
        rigid = GetComponent<Rigidbody>();
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

            rigid.velocity = player_movement * player_speed;

            if (Input.GetButtonDown("Fire1"))
            {
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3D.y = 0f;
        //Debug.Log(mousePos3D.z + " " + mousePos3D.y + " " + mousePos3D.x);

        gunType.weaponModel.GetComponent<IWeaponTemplate>().fireWeapon(gunType.bulletType, transform, mousePos3D);
        
    }

    void equipWeapon()
    {
        GameObject currentWeapon = Instantiate<GameObject>(gunType.weaponModel);
        currentWeapon.name = gunType.weaponName;
        if (transform.Find("Character").Find("Weapon") != null)
        {
            currentWeapon.transform.SetParent(transform.Find("Character").Find("Weapon"));
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
        rigid.isKinematic = true;

        //Play death animation
    }


    //Getter & Setters
    public bool getPlayerAliveStatus()
    {
        return playerAlive;
    }
}
