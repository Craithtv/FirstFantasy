using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;

public class CharacterTests
{
    private bool isReady = false;
    private Player sut;

    [OneTimeSetUp]
    public void LoadTestScene()
    {
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += SceneReady;
    }

    public void SceneReady(Scene scene, LoadSceneMode mode)
    {
        sut = GameObject.FindObjectOfType<Player>();
        Debug.Log(sut.name);
        isReady = true;
    }

    [UnityTest]
    public IEnumerator Moves_to_correct_cell()
    {
        while (!isReady) yield return null;

       //Moving Left
       //Arrange
       Vector2Int current = sut.CurrentCell;
       //Act
       sut.Move.TryMove(Direction.Left);
       yield return new WaitForSeconds(1f);
       //Assert
       Assert.AreEqual(current + Direction.Left, sut.CurrentCell);

       //Moving Right
       current = sut.CurrentCell;
       sut.Move.TryMove(Direction.Right);
       yield return new WaitForSeconds(1f);

       Assert.AreEqual(current + Direction.Right, sut.CurrentCell);

       //Moving Down
       current = sut.CurrentCell;
       sut.Move.TryMove(Direction.Down);
       yield return new WaitForSeconds(1f);
       Assert.AreEqual(current + Direction.Down, sut.CurrentCell);

       //Moving Up
       current = sut.CurrentCell;
       sut.Move.TryMove(Direction.Up);
       yield return new WaitForSeconds(1f);
       Assert.AreEqual(current + Direction.Up, sut.CurrentCell);

    }
}
