using UnityEngine;
using System.Collections;

public class Taliban : Entity {
	
	public Entity president;
	public int distance = 3;
	public RaycastHit2D hit;
	
	public Transform shootOne;
	public Transform shootTwo;
	
	public Transform tailbanBullet;
	
	private Transform shoot;
	
	void Start () 
	{
		canShoot = true;
		shoot = shootOne;
	}
	
	void Update () 
	{
		if (dir == 0)
			spriteRenderer.sprite = back;
		else if (dir == 1)
			spriteRenderer.sprite = front;
		else if (dir == 2)
		{
			spriteRenderer.sprite = right;
			shoot = shootOne;
		}
		else if (dir == 3)
		{
			spriteRenderer.sprite = left;
			shoot = shootTwo;
		}
		
		/*Debug.DrawLine (shoot.transform.position, president.rigidbody2D.transform.position, Color.blue);
		hit = Physics2D.Raycast(shoot.transform.position, president.rigidbody2D.transform.position, Mathf.Infinity);
		if(hit != null)
		{
			Debug.Log (hit.transform);
			Debug.DrawLine (shoot.transform.position, hit.transform.position, Color.green);
			//if (hit.transform.name == "Obama")
			//{
			//	print ("hi");
			//}
		}*/
		
		if (president.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y))
		{
			dir = 0;
		}
		if (president.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y))
		{
			dir = 1;
		}
		if (president.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x))
		{
			dir = 2;
		}
		if (president.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x))
		{
			dir = 3;
			shoot = shootTwo;
		}
	
		if (president.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y + distance))
		{
			rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
			dir = 0;
		}
		if (president.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y - distance))
		{
			rigidbody2D.rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
			dir = 1;
		}
		if (president.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x + distance))
		{
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
			dir = 2;
		}
		if (president.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x - distance))
		{
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
			dir = 3;
		}
		
		if (president.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y + distance) & president.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y))
		{
			rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
		}
		if (president.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y - distance) && president.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y))
		{
			rigidbody2D.rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
		}
		if (president.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x + distance) && president.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x))
		{
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
		}
		if (president.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x - distance) && president.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x))
		{
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
		}
		
		if(canShoot)
		{
			shootGun();
		}
	}
	
	private void shootGun()
	{
		GameObject Inst_Bullet = Instantiate(tailbanBullet, shoot.position, new Quaternion()) as GameObject;
		//Inst_Bullet.GetComponent<bullet>().lookAtObj(president.transform);
		canShoot = false;
		StartCoroutine(waitForLength(5));
	}
	
	public IEnumerator waitForLength(int time)
	{
		yield return new WaitForSeconds(time);
		canShoot = true;
	}
}
