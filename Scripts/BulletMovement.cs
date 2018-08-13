using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float speed = 3f;
    public Quaternion dir;
    public float damage = 25;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += new Vector3( Time.deltaTime * 1.0f, 0 ,0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = col.gameObject.GetComponent<enemyControl>();
        if (enemy != null)
        {
            enemy.health -= damage;
            Destroy(this.gameObject);
        }

        
        
    }
}
