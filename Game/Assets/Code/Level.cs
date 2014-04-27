using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int levelWidth;
	public int levelHeight;
	
	public GameObject newCam;
	
	public bool doEndingScene;

	public Transform grassSprite;
	public Transform woodSprite;
	public Transform whiteBrickSprite;
	public Transform elevatorSprite;
	public Transform whiteTileSprite;
	public Transform brickSprite;
	public Transform usedElevatorSprite;
	public Transform dirtSprite;
	public Transform redStoneSprite;
	public Transform stoneSprite;
	public Transform concreteWallSprite;
	public Transform concreteTileSprite;
	public Transform concreteLightRightSprite;
	public Transform concreteLightLeftSprite;
	public Transform doorSprite;
	
	public AudioClip[] playerDeathSounds;
	public AudioClip[] presidentDeathSounds;
	
	public Transform SignObj;
	
	public GameObject elevator;

	public Color grassColour;
	public Color woodColour;
	public Color whiteBrickColour;
	public Color spawnColour;
	public Color elevatorColour;
	public Color whiteTileColour;
	public Color brickColour;
	public Color usedElevatorColour;
	public Color enemySpawnColour;
	public Color dirtColour;
	public Color redStoneColour;
	public Color stoneColour;
	public Color concreteWallColour;
	public Color concreteTileColour;
	public Color concreteLightRightColour;
	public Color concreteLightLeftColour;
	public Color doorColour;
	
	private int level;

	private Texture2D levelTexture;

	public Texture2D firstLevel;
	public Texture2D secondLevel;
	public Texture2D thirdLevel;
	public Texture2D fourthLevel;
	public Texture2D finalLevel;

	public Color[] tileColours;
	
	public GameObject enemy;

	public Player player;
	public Obama obama;
	public SecretService secretService;
	
	public Vector2 ElevatorPositionOne;
	public Vector2 ElevatorPositionTwo;
	public Vector2 ElevatorPositionThree;
	
	public Vector2 obamaDeathPos;
	public Vector2 playerDeathPos;

	void Start () {
		level = 0;
		renderNextLevel(false);
		elevator = GameObject.FindGameObjectWithTag("Respawn");
		newCam.SetActive(false);
		DontDestroyOnLoad(this.gameObject);
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
	
	void renderNextLevel(bool removeEntities)
	{
		if(removeEntities)
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
			GameObject[] signsToDelete = GameObject.FindGameObjectsWithTag("Sign");
			for(int i = 0; i < signsToDelete.Length; i++)
			{
				GameObject.Destroy(signsToDelete[i].gameObject);
			}
		}
		level+=1;
		if(level == 1)
		{
			levelTexture = firstLevel;
		}
		if(level == 2)
		{
			levelTexture = secondLevel;
		}
		if(level == 3)
		{
			levelTexture = thirdLevel;
		}
		if(level == 4)
		{
			levelTexture = fourthLevel;
			Instantiate(SignObj, new Vector2(29, 5), Quaternion.identity);
			GameObject go = GameObject.FindGameObjectWithTag("Sign");
			go.GetComponent<Sign>().message = "You're on your way to the concrete bunker";
			go.GetComponent<Sign>().cave = true;
			go.GetComponent<Sign>().player = player;
		}
		if(level == 5)
		{
			levelTexture = finalLevel;
		}
		
		tileColours = new Color[levelTexture.width*levelTexture.height];
		tileColours = levelTexture.GetPixels ();
		for (int y = 0; y < levelTexture.height; y++)
		{
			for (int x = 0; x < levelTexture.width; x++)
			{
				if(tileColours[x+y*levelTexture.width] == grassColour)
				{
					inst(grassSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == whiteBrickColour)
				{
					inst(whiteBrickSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == woodColour)
				{
					inst(woodSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == elevatorColour)
				{
					inst(elevatorSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == whiteTileColour)
				{
					inst(whiteTileSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == brickColour)
				{
					inst(brickSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == usedElevatorColour)
				{
					inst(usedElevatorSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == dirtColour)
				{
					inst(dirtSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == redStoneColour)
				{
					inst(redStoneSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == stoneColour)
				{
					inst(stoneSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == spawnColour)
				{
					inst(woodSprite, x, y);
					player.updatePos(x, y);
					obama.updatePos(x + 1, y);
					secretService.updatePos(x + 2, y);
				}
				if(tileColours[x+y*levelTexture.width] == enemySpawnColour)
				{
					inst(woodSprite, x, y);
					Instantiate(enemy, new Vector2(x, y), new Quaternion());
				}
				
				//Bunker Code
				if(tileColours[x+y*levelTexture.width] == concreteWallColour)
				{
					inst(concreteWallSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == concreteTileColour)
				{
					inst(concreteTileSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == concreteLightRightColour)
				{
					inst(concreteLightRightSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == concreteLightLeftColour)
				{
					inst(concreteLightLeftSprite, x, y);
				}
				if(tileColours[x+y*levelTexture.width] == doorColour)
				{
					inst(doorSprite, x, y);
				}
			}
		}
	}
	
	public void inst(Transform sprite, int x, int y)
	{
		Instantiate(sprite, new Vector2(x, y), new Quaternion());
	}
	
	IEnumerator waitForLevel()
	{
		elevator.audio.Play();
		yield return new WaitForSeconds(5);
		renderNextLevel(true);
		elevator.audio.Stop();
	}
	
	public void obamaDeath()
	{
		player.transform.position = obamaDeathPos;
		GameObject.Destroy(obama.gameObject);
		GameObject.Destroy (secretService.gameObject);
		player.spriteRenderer.enabled = false;
		player.GetComponent<Player>().enabled = false;
		StartCoroutine(waitTillLevelEnd());
		removeEverything();
	}
	
	public void playerDeath()
	{
		player.transform.position = playerDeathPos;
		GameObject.Destroy(obama.gameObject);
		GameObject.Destroy (secretService.gameObject);
		player.spriteRenderer.enabled = false;
		player.GetComponent<Player>().enabled = false;
		StartCoroutine(waitTillLevelEnd());
		removeEverything();
	}
	
	public void partnerDeath()
	{
		GameObject.Destroy (secretService.gameObject);
	}
	
	IEnumerator waitTillLevelEnd()
	{
		yield return new WaitForSeconds(6);
		Application.LoadLevel(0);
	}
	
	public void removeEverything()
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
		GameObject[] signsToDelete = GameObject.FindGameObjectsWithTag("Sign");
		for(int i = 0; i < signsToDelete.Length; i++)
		{
			GameObject.Destroy(signsToDelete[i].gameObject);
		}
	}
	
	public void endScene()
	{
		GameObject.Destroy(obama.gameObject);
		GameObject.Destroy (secretService.gameObject);
		GameObject.Destroy (player.gameObject);
		
		removeEverything();
		
		newCam.SetActive(true);
		newCam.animation.Play("End");
	}
	
	IEnumerator waitForAnim(float time)
	{
		yield return new WaitForSeconds(time);
		Application.LoadLevel(0);
		GameObject mm = GameObject.FindGameObjectWithTag("Respawn");
	}
}
