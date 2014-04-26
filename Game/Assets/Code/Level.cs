using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int levelWidth;
	public int levelHeight;

	public Transform grassSprite;
	public Transform woodSprite;
	public Transform whiteBrickSprite;

	void Start () {
		for(int y = 0; y < levelHeight; y++)
		{
			for(int x = 0; x < levelWidth; x++)
			{
				if(y == 0 || y == levelHeight-1)
					Instantiate(grassSprite, new Vector2(x, y), new Quaternion());
				else if(y == 1 || y == levelHeight-2)
					Instantiate(whiteBrickSprite, new Vector2(x, y), new Quaternion());
				else
					Instantiate(woodSprite, new Vector2(x, y), new Quaternion());
			}
		}
	}

	void Update () {
	
	}
}
