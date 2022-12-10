using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Game/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _timeBetweenSpawnEnemy;
    [SerializeField] private int _maxEnemiesTogether;

    public float GetTimeBetweenSpawnEnemy => _timeBetweenSpawnEnemy;
    public int GetMaxEnemiesTogether => _maxEnemiesTogether;
}