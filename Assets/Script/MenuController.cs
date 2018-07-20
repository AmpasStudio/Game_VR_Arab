using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	//public Animator gazeTime;
	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;

	public bool OnObject = false;
	float time;
	// Use this for initialization
	void Start () {
		time = 0;
	}
		
	// Update is called once per frame
	void Update () {
		if (OnObject) {
			time += Time.deltaTime;
			//gazeTime.Play ("ProgressGaze");
			if (time > 3) {
				StartCoroutine (LoadAsynchronously(2));
				OnObject = false;
			}
		} 
	}

	IEnumerator LoadAsynchronously(int scene){
		AsyncOperation operation = SceneManager.LoadSceneAsync (scene);
		loadingScreen.SetActive (true);
		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress;
			progressText.text = progress*100f+"%";
			yield return null;
		}
	}

	public void setTrueBoolOnObject(){
		OnObject = true;
	}

	public void setFalseBoolOnObject(){
		//gazeTime.Play ("Idle");
		OnObject = false;
	}

	public void GotoSceneGame(){
		SceneManager.LoadScene ("Game");
	}

	public void selectVRMode(){
		StartCoroutine(LoadDevice("Cardboard"));
	}

	public void selectNoneVRMode(){
		SceneManager.LoadScene ("MainMenu_2");
	}

	IEnumerator LoadDevice(string newDevice){
		UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		UnityEngine.XR.XRSettings.enabled = true;
		SceneManager.LoadScene ("MainMenu_2");
	}
}
