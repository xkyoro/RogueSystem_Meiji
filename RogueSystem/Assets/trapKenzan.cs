using UnityEngine;
using System.Collections;

public class trapKenzan : MonoBehaviour {
	public GameObject BloodFx;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player") {
			GameObject tgtObj = c.gameObject;
			tgtObj
				.GetComponent<UnityChan.SD_UnityChanControlScriptWithRgidBody> ()
				.dead ();
			Instantiate (
				BloodFx,
				tgtObj.transform.position,
				tgtObj.transform.rotation
			);
			
		}
	}
}
