using UnityEngine;
using System.Collections;

public class SecretService : Entity {

	public Entity player;
	
	void Start () 
	{
		x = transform.position.x;
		y = transform.position.y;
	}
	
	void Update () 
	{
		if (player.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y + .8))
		{
			rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
			dir = 0;
		}
		if (player.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y - .8))
		{
			rigidbody2D.rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
			dir = 1;
		}
		if (player.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x + 1.1))
		{
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
			dir = 2;
		}
		if (player.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x - 1.1))
		{
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
			dir = 3;
		}
		
		if (dir == 0)
			spriteRenderer.sprite = back;
		else if (dir == 1)
			spriteRenderer.sprite = front;
		else if (dir == 2)
			spriteRenderer.sprite = right;
		else if (dir == 3)
			spriteRenderer.sprite = left;
			
		if(dead)
			level.partnerDeath();
	}
	
	void OnGUI()
	{
		GUI.skin = sskin;
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		pos.y = pos.y += 107;
		pos.y = Screen.height - pos.y;
		GUI.Label(new Rect(pos.x - 250, pos.y, 500, 50), "Health: " + health.ToString());
	}
}
