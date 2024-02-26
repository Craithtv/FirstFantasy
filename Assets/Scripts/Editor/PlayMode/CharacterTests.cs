// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using UnityEngine.SceneManagement;
// using UnityEngine.TextCore.Text;
// using UnityEditor.Build;
// using UnityEditor.Experimental.GraphView;
// using System.Data;
// using Core;

// public class CharacterTests
// {
//     private bool isReady = false;
//     private Player sut;

//     [OneTimeSetUp]
//     public void LoadTestScene()
//     {
//         SceneManager.LoadScene(1);
//         SceneManager.sceneLoaded += SceneReady;
//     }

//     public void SceneReady(Scene scene, LoadSceneMode mode)
//     {
//         sut = GameObject.FindObjectOfType<Player>();
//         Debug.Log(sut.name);
//         isReady = true;

//         //SceneManager.sceneLoaded -= SceneReady;
//     }

//     [UnityTest]
//     public IEnumerator Moves_to_correct_cell()
//     {
//         while (!isReady) yield return null;

//        //Moving Left
//        //Arrange
//        Vector2Int current = sut.CurrentCell;
//        //Act
//        sut.Move.TryMove(Direction.Left);
//        yield return new WaitForSeconds(1f);
//        //Assert
//        Assert.AreEqual(current + Direction.Left, sut.CurrentCell);

//        //Moving Right
//        current = sut.CurrentCell;
//        sut.Move.TryMove(Direction.Right);
//        yield return new WaitForSeconds(1f);

//        Assert.AreEqual(current + Direction.Right, sut.CurrentCell);

//        //Moving Down
//        current = sut.CurrentCell;
//        sut.Move.TryMove(Direction.Down);
//        yield return new WaitForSeconds(1f);
//        Assert.AreEqual(current + Direction.Down, sut.CurrentCell);

//        //Moving Up
//        current = sut.CurrentCell;
//        sut.Move.TryMove(Direction.Up);
//        yield return new WaitForSeconds(1f);
//        Assert.AreEqual(current + Direction.Up, sut.CurrentCell);

//     }

//     [UnityTest]
//     public IEnumerator Character_facing_updates_correctly()
//     {
//         while (!isReady) yield return null;

//         sut.Turn.Turn(Direction.Down);
//         Assert.AreEqual(Direction.Down, sut.Facing);

//         sut.Turn.Turn(Direction.Left);
//         Assert.AreEqual(Direction.Left, sut.Facing);

//         sut.Turn.Turn(Direction.Right);
//         Assert.AreEqual(Direction.Right, sut.Facing);

//         sut.Turn.Turn(Direction.Up);
//         Assert.AreEqual(Direction.Up, sut.Facing);
//     }

//     [UnityTest]
//     public IEnumerator Updates_map_dictionary()
//     {
//         while (!isReady) yield return null;
//         Vector2Int originalCell = sut.CurrentCell;

//         Assert.IsTrue(Game.Manager.Map.OccupiedCells.ContainsKey(originalCell));
//         Assert.AreEqual(sut, Game.Manager.Map.OccupiedCells[originalCell]);

//         sut.Move.TryMove(Direction.Left);
//         yield return new WaitForSeconds(1f);
        
//         Assert.IsTrue(Game.Manager.Map.OccupiedCells.ContainsKey(sut.CurrentCell));
//         Assert.IsFalse(Game.Manager.Map.OccupiedCells.ContainsKey(originalCell));
//         Assert.AreEqual(sut, Game.Manager.Map.OccupiedCells[sut.CurrentCell]);
//     }
// }
