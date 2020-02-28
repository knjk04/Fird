using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BirdCollisionTest {

    [Test]
    public void BirdCollisionTestSimplePasses() {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator BirdCollisionTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        GameObject celling = new GameObject();
        celling.transform.position = new Vector3(0f, 4f, 0f);
        

        celling.AddComponent<BoxCollider2D>();
        //celling.collider2D.transform = 
        yield return null;
    }
}
