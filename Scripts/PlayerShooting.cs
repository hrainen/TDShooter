﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed = 1f;
    public float timeBetweenShots;
    public bool isFiring = false;
    public bool CanFire = true;
    public Transform fireLocation;
    public AudioSource colt_1911;

	// Use this for initialization
	void Start () {
        //timeBetweenShots = .1f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFiring = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFiring = false;
        }
        while ( CanFire && isFiring)
        {
            //FireBullet();
            StartCoroutine(FireBullet(timeBetweenShots));
            CanFire = false;
        }
	}

    public IEnumerator FireBullet(float timeBetween)
    {
        //Debug.Log(timeBetween);

        //play sound of gun firing here:
        colt_1911.Play();

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //rot_z - 90w
        //var newBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rot_z - 90));

        var newBullet = Instantiate(bullet, fireLocation.position, Quaternion.Euler(0f, 0f, rot_z - 90));

        //newBullet.GetComponent<BulletMovement>().dir = Quaternion.Euler(0f, 0f, rot_z - 90);
        newBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);

        yield return new WaitForSecondsRealtime(timeBetween);

        CanFire = true;



    }
}


