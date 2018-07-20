using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour {
	float time;
	public Animator gazeTime;
	public bool OnObject = false;
	public bool pindah = false;
	public bool cantChangeNoWay = true;
	public EditorPath pathToFollow;
	public int CurrentWayPointID = 0;
	public float speed;
	public GameObject player;
	public List<Transform> path_objs = new List<Transform> ();
	Transform[] theArray;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (OnObject&&cantChangeNoWay) {
			time += Time.deltaTime;
			gazeTime.Play ("ProgressGaze");
			if (time > 2) {
				pindah = true;
				OnObject = false;
				cantChangeNoWay = false;
			}
		}

		if (pindah) {
			player.transform.position = Vector3.MoveTowards (player.transform.position, pathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime*speed);
			float distance = Vector3.Distance (player.transform.position,pathToFollow.path_objs [CurrentWayPointID].position);
			if (distance < 0.1) {
				pindah = false;
				cantChangeNoWay = true;
			}
		}
	}
	public void setCurrentWayPoint(int point){
		if(cantChangeNoWay){
			CurrentWayPointID = point;
		}
	}

	void OnDrawGizmos(){
		theArray = GetComponentsInChildren<Transform> ();
		path_objs.Clear ();
		foreach (Transform path_obj in theArray) {
			if (path_obj != this.transform&&path_obj.tag=="step") {
				path_objs.Add (path_obj);
			}
		}

		for (int i = 0; i < path_objs.Count; i++) {
			Vector3 position = path_objs [i].position;
			if (i > 0) {
				Vector3 previous = path_objs [i - 1].position;

				Gizmos.DrawWireSphere (position, 2.7f);
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

	public bool isWalking(){
		if (pindah)
			return true;
		else
			return false;
	}
}
