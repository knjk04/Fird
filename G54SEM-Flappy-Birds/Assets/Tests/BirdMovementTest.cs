using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BirdMovementTest
{
    /// <summary>
    /// Tests whether bird moves on input.
    /// </summary>
    /// <returns>Returns IEnumerator.</returns>
    [UnityTest]
    public IEnumerator BirdMovementOnClickTest()
    {
        GameObject gameObject = new GameObject();
        Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();

        // apply input to bird
        Vector2 priorVelocity = rigidbody2D.velocity;
        gameObject.AddComponent<BirdMovement>();
        gameObject.GetComponent<BirdMovement>().MoveOnInput(gameObject.GetComponent<Rigidbody2D>());

        Vector2 postVelocity = rigidbody2D.velocity;
        Debug.Log("\nprior velocity: " + priorVelocity + " postVelocity: " + postVelocity);

        Assert.IsTrue(priorVelocity.y < postVelocity.y);
        yield return null;
    }
}