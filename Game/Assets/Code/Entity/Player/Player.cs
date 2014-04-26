using UnityEngine;
using System.Collections;

public class Player : Entity {

	void Start () 
	{
		this.x = transform.position.x;
		this.y = transform.position.y;
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 
		{
			rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
			dir = 0;
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) 
		{
			rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
			dir = 1;
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
			dir = 2;
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
		{
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
			dir = 3;
		}

		if (dir == 0)
			spriteRenderer.sprite = back;
		else if (dir == 1)
			spriteRenderer.sprite = front;
		else if (dir == 2)
			spriteRenderer.sprite = left;
		else if (dir == 3)
			spriteRenderer.sprite = right;
		Physics2D.IgnoreLayerCollision(9, 8, true);
	}
}
