using UnityEngine;
using System.Collections;

public class SecretService : MonoBehaviour {

	public float x, y;
	public Obama player;
	private Vector2 localTransform;
	public int speed;
	
	void Start () 
	{
		x = transform.position.x;
		y = transform.position.y;
	}
	
	void Update () 
	{
		if (player.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y + 1.5))
			rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
		if (player.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y - 1.5))
			rigidbody2D.rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
		if (player.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x + 1.5))
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
		if (player.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x - 1.5))
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
	}
}
