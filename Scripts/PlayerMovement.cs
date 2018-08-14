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

        getCenter.transform.Translate(new Vector3(moveHorizontal, moveVertical), Space.World);

        if (getMouseDist() >= .8f) // dont check distance if mouse is right on top of player
        {
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dir.z = 0;
            //dir.Normalize();


            float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            getCenter.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            //Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    float getMouseDist()
    {
        return Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), getCenter.transform.position);
    }
}

