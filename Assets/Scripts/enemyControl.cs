using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour {
    private float rotateSpeed = 5f;
    private float radius = 3f;

    private Vector3 center;
    private float angle;


	// Use this for initialization
	void Start () {
        center = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        angle += rotateSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(angle) * radius , Mathf.Cos(angle) * radius, 0);
        transform.position = center + offset;
	}
}
