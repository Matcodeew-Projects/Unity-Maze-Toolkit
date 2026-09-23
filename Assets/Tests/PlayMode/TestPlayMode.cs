using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestPlayMode
{
    [UnityTest]
    public IEnumerator Player_Should_Move_Forward()
    {
        GameObject player = new GameObject();

        Vector3 startPosition = player.transform.position;

        yield return null;

        player.transform.position += Vector3.right * Time.deltaTime;

        Assert.AreNotEqual(startPosition, player.transform.position);

        Object.Destroy(player);
    }
}