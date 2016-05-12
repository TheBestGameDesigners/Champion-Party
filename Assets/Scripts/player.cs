﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	static public player S; //singleton
	
	public float speed = 30;
	public Bounds bounds;
	
	
	 void Awake()
	 {
	        S = this; //set the Singleton
	        bounds = Utils.CombineBoundsOfChildren(this.gameObject);
    	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xAxis = Input.GetAxis("Horizontal");
	        float yAxis = Input.GetAxis("Vertical");
	
	        Vector3 pos = transform.position;
	        pos.x += xAxis * speed * Time.deltaTime;
	        pos.y += yAxis * speed * Time.deltaTime;
	
	       
	        transform.position = pos;

		
	}
}