using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHdlr : MonoBehaviour
{
	[SerializeField]private GameObject[] Layers;
	[Range(0,200)][SerializeField]private float SpeedOfRotation;
	private Rigidbody2D rb;
	private float x;
	private void Awake() {
		rb = transform.GetComponent<Rigidbody2D>();
	}
	private void Update() {
		RotateLayers();
	}
	private void RotateLayers(){
		x -= rb.velocity.x * Time.deltaTime * SpeedOfRotation;
		foreach(GameObject Items in Layers){
			Items.transform.localRotation = Quaternion.Euler(0,0,x);
		}
	}
}
