using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		if(player != null)
		{
			player.level.nextLevel();
		}
	}
}
