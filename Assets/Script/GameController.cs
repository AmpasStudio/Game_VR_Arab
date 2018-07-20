using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public Animator gazeTime;
	public bool OnObject = false;
	string objectNameSelect;
	float time;
	private Mision ms;
	// Use this for initialization
	void Start () {
		time = 0;
		ms = gameObject.GetComponent<Mision> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (OnObject) {
			time += Time.deltaTime;
			gazeTime.Play ("ProgressGaze");
			if (time > 3) {
				
				Debug.Log (objectNameSelect);
				ms.koreksiBenda (objectNameSelect);
				OnObject = false;
			}
		} 
	}
	public void setTrueBoolOnObject(){
		OnObject = true;
	}

	public void setFalseBoolOnObject(){
		gazeTime.Play ("Idle");
		OnObject = false;
		time = 0;
	}

	public void setObjectName(string name){
		objectNameSelect = name;
	}

	public void setNullObjectName(){
		objectNameSelect = null;
	}



}
