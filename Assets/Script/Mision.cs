using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision : MonoBehaviour {
	public List<GameObject> benda;
	int i = 0;
	private GameObject getInventory;
	public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	public void koreksiBenda(string ben){
		i = 0;
		while (i != benda.Count) {
			if (ben == benda [i].name) {
				setInventory(benda[i]);//animasi benda ke ambil
				benda.RemoveAt(i);
				break;
				if(benda==null){
					//selamat
					break;
				}

			} else {
				i++;
			}
		}
		i = 0;
	}
		
	void Update () {
		//animasi benda ke ambil
		if (getInventory!=null) {
			float step = 2 * Time.deltaTime;
			float distance = Vector3.Distance (getInventory.transform.position,player.position);
			getInventory.transform.position = Vector3.MoveTowards(getInventory.transform.position, player.position, step);
			if (distance < 0.1f) {
				Destroy (getInventory);
			}
		}
	}

	void setInventory(GameObject inv){
		getInventory = inv;
	}


}
