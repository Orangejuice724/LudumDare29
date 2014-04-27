using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Vector2 mainPos;
	public Vector2 controlsPos;
	public Vector2 EndGamePos;
	
	public GUISkin sskin;
	
	public int currentMenu;
	private int oldMenu;
	
	public bool canDraw;
	
	private int selected;
	
	GameObject go;
	
	void Start () {
		go = GameObject.FindGameObjectWithTag("Respawn");
		currentMenu = go.GetComponent<GlobalManager>().finGame;
		Vector3 npos = new Vector3(EndGamePos.x, EndGamePos.y, -10);
		if(currentMenu == 2)
			camera.transform.position = npos;
		oldMenu = currentMenu;
		selected = 0;
	}
	
	void Update () 
	{
		if(oldMenu != currentMenu)
		{
			print ("heey");
			moveCamera(currentMenu);
			canDraw = false;
		}
		else
		{
			canDraw = true;
		}
	
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && currentMenu == 0)
		{
			selected+=1;
			if(selected > 3)
				selected = 0;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && currentMenu == 0)
		{
			selected-=1;
			if(selected < 0)
				selected = 3;
		}
		
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(currentMenu == 0 && canDraw)
			{
				if(selected == 0)
					Application.LoadLevel(1);
				if(selected == 2)
				{
					canDraw = false;
					currentMenu = 1;
				}
				if(selected == 3)
					Application.Quit();
				print ("hi");
			}
			if(currentMenu == 1 && canDraw)
			{
				canDraw = false;
				currentMenu = 0;
				print ("howdy");
			}
			if(currentMenu == 2 && canDraw)
			{
				canDraw = false;
				go.GetComponent<GlobalManager>().finGame = 0;
				currentMenu = 0;
				print ("To infinity and beyond!");
			}
		}
	}
	
	void OnGUI()
	{
		GUI.skin = sskin;
		if(currentMenu == 0 && canDraw == true)
		{	
			GUI.Label(new Rect(60, 80, 200, 50), "Start Game", "menu");
			GUI.Label(new Rect(60, 120, 200, 50), "Multiplayer", "gray");
			GUI.Label(new Rect(60, 160, 200, 50), "Controls", "menu");
			GUI.Label(new Rect(60, 200, 200, 50), "Exit Game", "menu");
			
			if(selected == 0)
				GUI.Label(new Rect(60, 80, 200, 50), ">             <", "menu");
			if(selected == 1)
				GUI.Label(new Rect(60, 120, 200, 50), ">             <", "menu");
			if(selected == 2)
				GUI.Label(new Rect(60, 160, 200, 50), ">             <", "menu");
			if(selected == 3)
				GUI.Label(new Rect(60, 200, 200, 50), ">             <", "menu");
		}	
	}
	
	public void moveCamera(int menu_id)
	{
		print ("yo!");
		if(menu_id == 0)
		{
			Vector3 pos = new Vector3(mainPos.x, mainPos.y);
			pos.z = -10;
			if(camera.transform.position != pos)
				camera.transform.position = Vector3.Lerp(camera.transform.position, pos, 3.0f * Time.deltaTime);
			else
				oldMenu = currentMenu;
			if(Vector2.Distance(camera.transform.position, mainPos) < 0.3)
				oldMenu = currentMenu;
		}
		else if(menu_id == 1)
		{
			Vector3 pos = new Vector3(controlsPos.x, controlsPos.y);
			pos.z = -10;
			if(camera.transform.position != pos)
				camera.transform.position = Vector3.Lerp(camera.transform.position, pos, 3.0f * Time.deltaTime);
			else
				oldMenu = currentMenu;
			if(Vector2.Distance(camera.transform.position, controlsPos) < 0.3)
				oldMenu = currentMenu;
		}
		else if(menu_id == 0)
		{
			Vector3 pos = new Vector3(EndGamePos.x, EndGamePos.y);
			pos.z = -10;
			if(camera.transform.position != pos)
				camera.transform.position = Vector3.Lerp(camera.transform.position, pos, 3.0f * Time.deltaTime);
			else
				oldMenu = currentMenu;
			if(Vector2.Distance(camera.transform.position, EndGamePos) < 0.3)
				oldMenu = currentMenu;
		}
	}
}
