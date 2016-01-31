using UnityEngine;
using System.Collections;


public class WaterIce : Effected {
	Rigidbody2D myRb;


	void Awake(){
		anim = gameObject.GetComponent<Animator>();
		myRb = gameObject.GetComponent<Rigidbody2D>();
	}

	protected override void IfSeason(){
		switch(sea){
		default: break;
		case Season.Winter: anim.SetBool("Frozen", true); 
			myRb.isKinematic = true;break;
		case Season.Summer: anim.SetBool("Frozen", false);
			myRb.isKinematic = false;break;
		}
	}
}
