using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
[CreateAssetMenu(fileName = "New Enemy Pack", menuName = "New Enemy Pack")]
public class EnemyPack : ScriptableObject
{
   [SerializeField] private List<EnemyData> enemies;
   [SerializeField] private List<float> xSpawnCoordiantes;
   [SerializeField] private List<float> ySpawnCoordiantes;

   public List<EnemyData> Enemies => enemies;
   public IReadOnlyList<float> XSpawnCoordinates => xSpawnCoordiantes;
   public IReadOnlyList<float> YSpawnCoordinates => ySpawnCoordiantes;



}
}