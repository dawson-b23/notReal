using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRoomDirection
{
    
   
    // A Test behaves as an ordinary method
    [Test]
    public void TestRoomDirectionSimplePasses()
    {
        

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestRoomDirectionWithEnumeratorPasses()
    {

        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
