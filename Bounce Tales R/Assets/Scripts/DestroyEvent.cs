using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
	[SerializeField]private float TimeToDestroy;
	[SerializeField]private bool StateParent = true;
	private bool HasCalled;
	private bool HasInst = false;
	private GameObject ObjPassed;
	private List<GameObject> Instances = new List<GameObject>();
	private GameObject[] Particle;
	private float Timer;
	private void Update() {
		if(HasCalled){
			Timer += Time.deltaTime;
			ObjPassed.SetActive(StateParent);
			if(!HasInst){
				foreach(var item in Particle){
					Instances.Add(Instantiate(item, ObjPassed.transform.position , Quaternion.identity));
				}
				foreach(var item in Instances){
					item.transform.parent = this.transform.parent;
				}
				HasInst = true;
			}
			if(Timer >= TimeToDestroy){
				Destroy(gameObject);
			}
		}
	}
 public void DestroyEnh(GameObject Listener, GameObject[] Particle){
		ObjPassed = Listener;
		this.Particle = Particle;
		HasCalled = true;
	}
}
