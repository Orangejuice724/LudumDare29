using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float x, y;
	private Vector2 localTransform;
	public int speed;

	void Start () 
	{
		this.x = transform.position.x;
		this.y = transform.position.y;
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
			rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
	}
}
