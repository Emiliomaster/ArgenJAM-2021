using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    [SerializeField] int _bulletCount;
    public int bulletCount { get {return _bulletCount; } set {_bulletCount = value;} }

    void Start()
    {
        bulletCount = 12;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletCount > 0 )
        {
            Shoot();
            bulletCount -= 1;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        string typeTag = col.gameObject.tag;
        switch (typeTag)
        {
            case "AmmoBox":
                bulletCount = col.gameObject.GetComponent<AmmoBoxLogic>().maxAmmo;
                break;
            default:
                break;
        }
    }

}
