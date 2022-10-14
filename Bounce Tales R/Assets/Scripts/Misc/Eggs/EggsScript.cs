using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsScript : MonoBehaviour
{
	[SerializeField]private GameObject[] ParticleDeathEffect;
	[SerializeField]private GameObject[] Egg;
	[SerializeField]private DestroyEvent DestroyHe;
	[SerializeField]private Collider2D[] Coliders;
	[SerializeField]private GameObject handler;
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Bounce")){
			Handlers.main.EggsCount ++;
			//try destroying the GameObject
			DestroyHe.DestroyEnh(Egg, Coliders , ParticleDeathEffect);
		}
	}
}
