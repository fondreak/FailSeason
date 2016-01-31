using UnityEngine;
using System.Collections;

public class Burnable : Effected {


	protected override void IfSeason(){
		if(sea == Season.Summer)
			Destroy(this.gameObject);
	}
}
