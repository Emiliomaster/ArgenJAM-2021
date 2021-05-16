using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Text bulletUI;
    public float bulletForce = 20f;


    [SerializeField] int _bulletCount;
    public int bulletCount { get {return _bulletCount; } set {_bulletCount = value;} }

    void Start()
    {
        bulletCount = 12;
        //bulletUI.text = bulletCount.ToString() + "/12";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletCount > 0 && Time.timeScale == 1f)
        {
            Shoot();
            bulletCount -= 1;
        }
        bulletUI.text = bulletCount.ToString() + "/12";
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

  
}
