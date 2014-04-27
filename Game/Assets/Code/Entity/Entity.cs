using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public int health;

	public float x, y;
	protected Vector2 localTransform;
	public int speed;
	
	public GUISkin sskin;

	public Sprite front;
	public Sprite back;
	public Sprite left;
	public Sprite right;
	public SpriteRenderer spriteRenderer;
	
	public Level level;
	
	protected bool canShoot;

	protected int dir;

	protected bool dead = false;

	void Start () {
	
	}

	void Update () {
		
	}

	public void updatePos(int x, int y)
	{
		localTransform.x = x;
		localTransform.y = y;
		rigidbody2D.transform.position = localTransform;
		print ("x: " + x.ToString () + " y: " + y.ToString ());
	}

	public void takeHealth(int amount)
	{
		health -= amount;
		if (health <= 0) 
		{
			dead = true;
		}
	}
}
