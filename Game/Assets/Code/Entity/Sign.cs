using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour {

	public string message;
	public Player player;
	
	public GUISkin mainSkin;
	
	private bool showText;
	
	public Color col;
	
 	public bool cave;
	
	void Start () {
	
	}
	
	
	void Update () {
		if(Vector2.Distance(player.transform.position, transform.position) < 2)
		{
			showText = true;
		}
		else
			showText = false;
	}
	
	void OnGUI()
	{
		if(showText)
		{
			GUI.skin = mainSkin;
			Vector2 size = GUI.skin.label.CalcSize(new GUIContent(message));
			if(!cave)
				GUI.Label(new Rect(Screen.width / 2 - (size.x / 2), 20, size.x, 60), message);
			else
				GUI.Label(new Rect(Screen.width / 2 - (size.x / 2), 20, size.x, 60), message, "cave");
			print ("Doing shit");
		}
	}
}
