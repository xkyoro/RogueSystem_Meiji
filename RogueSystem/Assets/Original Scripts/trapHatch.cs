using UnityEngine;
using System.Collections;

public class trapHatch : MonoBehaviour {
	private Animator HatchAnimCont;
	private int      AnimOpenHatchHash = 0;
	private bool _open;
	private bool _opend;
	private float openDelayTimer = 0.15f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		HatchAnimCont = GetComponent<Animator> ();
		AnimOpenHatchHash = Animator.StringToHash ("Base Layer.HatchOpen");
	}
	
	// Update is called once per frame
	void Update () {
		if (_open && !_opend) {
			if (timer >= openDelayTimer) {
				GetComponent<BoxCollider> ().isTrigger = true;
				HatchAnimCont.Play (AnimOpenHatchHash, 0, 0);
				_opend = true;
			} else {
				timer += Time.deltaTime;
			}
		} else {
			timer = 0;
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player") {
			_open = true;
		}
	}
}
