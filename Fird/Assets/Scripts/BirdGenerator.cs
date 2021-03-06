﻿using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
//using UnityEngine.Animations;

public class BirdGenerator : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite blueBird;
    public Sprite redBird;
    public Sprite yellowBird;
    public RuntimeAnimatorController blueAnim;
    public RuntimeAnimatorController redAnim;
    public RuntimeAnimatorController yellowAnim;



    // Use this for initialization
    void Start ()
    {
        UpdateBirdSprite();
	}

    /// <summary>
    /// Function renders a random bird sprite so colour is different each time game starts.
    /// </summary>
    public void UpdateBirdSprite()
    {
        // Note: the Random.Range that returns an int is not maximally inclusive
        int random = Random.Range(0, 3);
        // Render sprite based on random number generated
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
