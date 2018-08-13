using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public GameObject getCenter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveHorizontal, moveVertical));

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.z = 0;
        dir.Normalize();
        //Debug.Log(dir);

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        getCenter.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        //Quaternion.Euler(0f, 0f, rot_z - 90);

    }
}
