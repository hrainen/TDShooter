using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform FollowTarget;
    public float CameraHeight;


	// Use this for initialization
	void Start () {
        CameraHeight = -20;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(FollowTarget.position.x, FollowTarget.position.y, CameraHeight);

	}
}
