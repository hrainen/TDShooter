using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed = .1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dir.Normalize();
            //Debug.Log(dir);

            float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //rot_z - 90w
            var newBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rot_z - 90));
            //newBullet.GetComponent<BulletMovement>().dir = Quaternion.Euler(0f, 0f, rot_z - 90);
            newBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse); 


        }
	}
}
