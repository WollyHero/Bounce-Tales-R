using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField]private Transform[] Positions;
    [SerializeField]private float Speed;
		[SerializeField]private Transform Platform;
    private int index = 0;
    private void Update(){
	if(transform.position != Positions[index].position){
	  Platform.position = Vector3.MoveTowards(Platform.position, Positions[index].position,Speed * Time.deltaTime);
	}
	if((Platform.position - Positions[index].position).magnitude <= .2f){
	    if(index +1 > Positions.Length -1){
		index = 0;
	    }
	    else{ index ++;}
	}
    }
}
