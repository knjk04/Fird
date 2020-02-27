using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BirdMovementTest
{

    [Test]
    public void BirdMovementTestSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator BirdMovementTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject gameObject = new GameObject();
        Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();

        if (gameObject == null)
        {
            Debug.Log("game object is null");
        }
        else
        {
            Debug.Log("game object is not null");

            if (gameObject.GetComponent<Rigidbody2D>() == null)
            {
                Debug.Log("Game object does not have a rigidbody attached");
            }
            else
            {
                Debug.Log("Game object has a rigidbody attached");

                Vector2 priorVelocity = rigidbody2D.velocity;

                BirdMovement bird = new BirdMovement();

                if (bird != null)
                {
                    Debug.Log("bird is not null");
                }


                Vector2 postVelocity = rigidbody2D.velocity;
            }
        }

        yield return null;
    }
}