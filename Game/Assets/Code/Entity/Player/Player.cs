using UnityEngine;
using System.Collections;

public class Player : Entity {
	
	public Transform shoot_Bullet;
	
	public Transform shootBack;
	public Transform shootForward;
	public Transform shootLeft;
	public Transform shootRight;
	
	private Transform shootSpot;
	
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
		{
			shootSpot = shootBack;
			spriteRenderer.sprite = back;
		}
		else if (dir == 1)
		{
			shootSpot = shootForward;
			spriteRenderer.sprite = front;
		}
		else if (dir == 2)
		{
			shootSpot = shootLeft;
			spriteRenderer.sprite = left;
		}
		else if (dir == 3)
		{
			shootSpot = shootRight;
			spriteRenderer.sprite = right;
		}
		Physics2D.IgnoreLayerCollision(9, 8, true);
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			level.nextLevel();
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 pos = Input.mousePosition;
			pos.z = shootSpot.position.z - Camera.main.transform.position.z;;
			pos = Camera.main.ScreenToWorldPoint(pos);
			
			Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - shootSpot.position);
			//q.x = 0;
			//q.y = 0;
			GameObject go = Instantiate(shoot_Bullet, shootSpot.position, q) as GameObject;
			go.rigidbody2D.AddForce(go.transform.up * 2 * Time.deltaTime);
		}
		
		if(dead)
			level.playerDeath();
	}
}
