using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int levelWidth;
	public int levelHeight;

	public Transform grassSprite;
	public Transform woodSprite;
	public Transform whiteBrickSprite;
	public Transform elevatorSprite;

	public Color grassColour;
	public Color woodColour;
	public Color whiteBrickColour;
	public Color spawnColour;
	public Color elevatorColour;

	public Texture2D levelTexture;

	public Color[] tileColours;

	public Player player;
	public Obama obama;
	public SecretService secretService;

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
}
