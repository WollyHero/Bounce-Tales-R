using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Emisor : MonoBehaviour
{
	[Header ("Params")]
	[SerializeField]private Vector3[] Dirs;
	[SerializeField]private GameObject[] Doors;
	//private 
	private bool HasActive = false;
	private List<Vector3>FixedDir = new List<Vector3>();
  private float timer;

	private void Start() {
	try{
	for (int i = 0; i < Dirs.Length; i++)
		{
			FixedDir.Add(Doors[i].transform.position + Dirs[i]);
		}
	}
	catch{
		Debug.Log("Error, make sure you put a door in " + this.transform + " before testing");
	}
	}
	private void Update() {
		if(HasActive){
			timer = Time.deltaTime;
			if(timer >= 4){
				HasActive = false;
			}
			for (int i = 0; i < Doors.Length; i++)
			{
				Doors[i].transform.position = Vector3.Lerp(Doors[i].transform.position, FixedDir[i], Time.deltaTime);
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		HasActive = true;
	}
}
