using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public int speed;
	public Transform shoot;
	public GameObject president;

	void Start () {
		president = GameObject.FindGameObjectWithTag("president");
		lookAtObj();
		StartCoroutine(wait(5));
	}
	
	void Update () {
		
		//float x = transform.position.x + 1;
		//Vector3 pos = new Vector3(x, 0);
		//rigidbody2D.AddForce(pos);
		
		rigidbody2D.transform.position += transform.up * Time.deltaTime * speed;
		Debug.DrawLine(rigidbody2D.transform.position, transform.up, Color.red);
		//rigidbody2D.transform.Translate(Vector3.forward * Time.deltaTime * speed);
		Vector3 fwd = Vector3.up;
		RaycastHit2D hit = Physics2D.Raycast(shoot.transform.position, fwd, 10.0f);
		if(hit!=null)
		{
			Entity checkJoint = hit.transform.gameObject.GetComponent<Entity>();
			if(checkJoint != null);
			{
				hit.transform.gameObject.GetComponent<Entity>().takeHealth(25);
				Debug.Log (hit.transform);
				GameObject.Destroy(gameObject);
			}
		}
	}
	
	public void lookAtObj()
	{
		Quaternion rot;
		transform.LookAt(president.transform);
		rot = new Quaternion(0, 0, -transform.rotation.z, transform.rotation.w);
		transform.rotation = rot;
		Debug.Log(rot);
	}
	
	IEnumerator wait(int time)
	{
		yield return new WaitForSeconds(time);
		GameObject.Destroy(gameObject);
	}
}
