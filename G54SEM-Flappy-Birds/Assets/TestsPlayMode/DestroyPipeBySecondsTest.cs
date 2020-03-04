using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;


public class DestroyPipeBySecondsTest : MonoBehaviour {

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	[UnityTest]
    public IEnumerator DestroyPipeBySecondsTestWithEnumeratorPasses()
	{
        GameObject pipeObject = new GameObject();
        pipeObject.AddComponent<DestroyPipeByTime>();

        GameObject gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();
        gameManager.GetComponent<GameManager>().Awake();

        // wait 8 seconds
        yield return new WaitForSeconds(9);


        // check destroyed
        if(pipeObject == null)
        {
            Debug.Log("pipeObject successfully destroyed after 8 seconds");
        } else
        {
            Debug.Log("pipeObject not destroyed after 8 seconds");
        }

        Assert.IsTrue(pipeObject == null);
	}
}