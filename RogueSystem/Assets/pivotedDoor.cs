using UnityEngine;
using System.Collections;

public class pivotedDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Animator anim = GetComponent<Animator>();
        int trap01Hash = Animator.StringToHash("Base Layer.trap01");
        float startTime = Random.value;
        anim.Play(trap01Hash, 0, startTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
