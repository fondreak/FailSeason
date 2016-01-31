using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name.Equals("Player"))
			GameController.NextLvl();
	}
}
