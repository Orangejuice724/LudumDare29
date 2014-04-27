using UnityEngine;
using System.Collections;

public class CloseManager : MonoBehaviour {
	
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel(0);
	}
}
