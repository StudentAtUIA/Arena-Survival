using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Animator anim;


	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown("a"))
        {
            anim.Play("UD_infantry_07_attack_A");
        }
    }
}
