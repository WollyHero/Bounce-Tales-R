using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AnimationHdlr : MonoBehaviour
{
    private float input;
    private bool inputjump;
    private bool AnimState = false;
    private float timer;
    private Animator AnimHdlr;
    [Range(0,20)][SerializeField]private float IddlePoint;
    [SerializeField]private CinemachineVirtualCamera VC;
    private void Awake(){
	AnimHdlr = transform.GetComponent<Animator>();
    }
    private void Update(){
	input = Input.GetAxisRaw("Horizontal");
	inputjump = Input.GetButton("Jump");
	timer += Time.deltaTime;
	//check if we're moving
	if(Mathf.Abs(input) > .2f || inputjump == true){
	    timer = 0;
	    AnimState = false;
	    VC.m_Lens.OrthographicSize = Mathf.Lerp(VC.m_Lens.OrthographicSize, 5, Time.deltaTime * 2);
	}
	if(timer > IddlePoint){
	    AnimState = true;
	    VC.m_Lens.OrthographicSize = Mathf.Lerp(VC.m_Lens.OrthographicSize, 3, Time.deltaTime * 2);
	}
	ApplyAnimState(AnimState);
    }
    private void ApplyAnimState(bool x){
	AnimHdlr.SetBool("iddle", x);
    }
}
