using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite blueBird;
    public Sprite redBird;
    public Sprite yellowBird;
    public AnimatorController blueAnim;
    public AnimatorController redAnim;
    public AnimatorController yellowAnim;



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
                animator.runtimeAnimatorController = blueAnim;
                break;
            case 1:
                spriteRenderer.sprite = redBird;
                animator.runtimeAnimatorController = redAnim;
                break;
            case 2:
                spriteRenderer.sprite = yellowBird;
                animator.runtimeAnimatorController = yellowAnim;
                break;
        }
    }
	
}
