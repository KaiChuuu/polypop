using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LightBullet : MonoBehaviour, IBulletTemplate
{      
    static private Transform _BULLET_ANCHOR;
    static Transform BULLET_ANCHOR
    {
        get
        {
            if(_BULLET_ANCHOR == null)
            {
                GameObject go = new GameObject("BulletAnchor");
                _BULLET_ANCHOR = go.transform;
            }
            return _BULLET_ANCHOR;
        }
    }

    private int bulletDamage = -1;
    private float bulletSpeed = 20;
    private float lifeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(BULLET_ANCHOR, true);

        Invoke("DestroyMe", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMe()
    {
        //if i wanted to add bullet pierce, it would be here.

        Destroy(gameObject);
    }

    public void FireBullet()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
