using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite blueBird;
    public Sprite redBird;
    public Sprite yellowBird;

	// Use this for initialization
	void Start ()
    {
        UpdateBirdSprite();
	}

    public void UpdateBirdSprite()
    {
        // Note: the Random.Range that returns an int is not maximally inclusive
        int random = Random.Range(0, 3);
        Debug.Log("random = " + random);

        switch(random)
        {
            case 0:
                spriteRenderer.sprite = blueBird;
                break;
            case 1:
                spriteRenderer.sprite = redBird;
                break;
            case 2:
                spriteRenderer.sprite = yellowBird;
                break;
        }
    }
	
}
