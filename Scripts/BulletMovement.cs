using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float speed = 3f;
    public Quaternion dir;
    public float damage;
    public bool hasCollided;


	// Use this for initialization
	void Start () {
        damage = -25f;
        hasCollided = false;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += new Vector3( Time.deltaTime * 1.0f, 0 ,0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = col.gameObject.GetComponent<enemyControl>();

        if (enemy != null && !hasCollided)
        {
            enemy.health += damage;
            hasCollided = true;
        }

        if (col.tag != "Player")
        {
            Destroy(this.gameObject);
        }

        
        
    }
}
