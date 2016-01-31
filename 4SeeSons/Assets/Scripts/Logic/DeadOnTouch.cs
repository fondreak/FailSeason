using UnityEngine;
using System.Collections;

public class DeadOnTouch : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name.Equals("Player"))
		   other.gameObject.GetComponent<PlayerController>().Dead();
	}
}
