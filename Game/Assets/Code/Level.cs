using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int levelWidth;
	public int levelHeight;

	public Transform grassSprite;
	public Transform woodSprite;
	public Transform whiteBrickSprite;
	public Transform elevatorSprite;
	public Transform whiteTileSprite;
	public Transform brickSprite;
	public Transform usedElevatorSprite;

	public Color grassColour;
	public Color woodColour;
	public Color whiteBrickColour;
	public Color spawnColour;
	public Color elevatorColour;
	public Color whiteTileColour;
	public Color brickColour;
	public Color usedElevatorColour;
	
	private int level;

	public Texture2D levelTexture;
	public Texture2D secondLevel;

	public Color[] tileColours;

	public Player player;
	public Obama obama;
	public SecretService secretService;
	
	public Vector2 ElevatorPositionOne;
	public Vector2 ElevatorPositionTwo;
	public Vector2 ElevatorPositionThree;

	void Start () {
		/*for(int y = 0; y < levelHeight; y++)
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
		}*/
		level = 1;

		tileColours = new Color[levelTexture.width*levelTexture.height];
		tileColours = levelTexture.GetPixels ();
		for (int y = 0; y < levelTexture.height; y++)
		{
			for (int x = 0; x < levelTexture.width; x++)
			{
				if(tileColours[x+y*levelTexture.width] == grassColour)
				{
					Instantiate(grassSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == whiteBrickColour)
				{
					Instantiate(whiteBrickSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == woodColour)
				{
					Instantiate(woodSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == elevatorColour)
				{
					Instantiate(elevatorSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == whiteTileColour)
				{
					Instantiate(whiteTileSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == brickColour)
				{
					Instantiate(brickSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == usedElevatorColour)
				{
					Instantiate(usedElevatorSprite, new Vector2(x, y), new Quaternion());
				}
				if(tileColours[x+y*levelTexture.width] == spawnColour)
				{
					Instantiate(woodSprite, new Vector2(x, y), new Quaternion());
					player.updatePos(x, y);
					obama.updatePos(x + 1, y);
					secretService.updatePos(x + 2, y);
				}
			}
		}
	}

	void Update () {
	
	}
	
	public void nextLevel()
	{
		player.transform.position = ElevatorPositionOne;
		obama.transform.position = ElevatorPositionTwo;
		secretService.transform.position = ElevatorPositionThree;
		StartCoroutine(waitForLevel());
	}
	
	void renderNextLevel()
	{
		GameObject[] objToDelete = GameObject.FindGameObjectsWithTag("LevelTiles");
		for(int i = 0; i < objToDelete.Length; i++)
		{
			GameObject.Destroy(objToDelete[i].gameObject);
		}
		GameObject[] entitiesToDelete = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i = 0; i < entitiesToDelete.Length; i++)
		{
			GameObject.Destroy(entitiesToDelete[i].gameObject);
		}
		level++;
		if(level == 2)
		{
			tileColours = new Color[secondLevel.width*secondLevel.height];
			tileColours = secondLevel.GetPixels ();
			for (int y = 0; y < secondLevel.height; y++)
			{
				for (int x = 0; x < secondLevel.width; x++)
				{
					if(tileColours[x+y*levelTexture.width] == grassColour)
					{
						Instantiate(grassSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == whiteBrickColour)
					{
						Instantiate(whiteBrickSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == woodColour)
					{
						Instantiate(woodSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == elevatorColour)
					{
						Instantiate(elevatorSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == whiteTileColour)
					{
						Instantiate(whiteTileSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == brickColour)
					{
						Instantiate(brickSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == usedElevatorColour)
					{
						Instantiate(usedElevatorSprite, new Vector2(x, y), new Quaternion());
					}
					if(tileColours[x+y*levelTexture.width] == spawnColour)
					{
						Instantiate(woodSprite, new Vector2(x, y), new Quaternion());
						player.updatePos(x, y);
						obama.updatePos(x + 1, y);
						secretService.updatePos(x + 2, y);
					}
				}
			}
		}
	}
	
	IEnumerator waitForLevel()
	{
		yield return new WaitForSeconds(5);
		renderNextLevel();
	}
}
