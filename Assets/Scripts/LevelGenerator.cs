using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    public GameObject[] LevelPrefabs;
    public Transform Finish;
    public int MinAmount;
    public int MaxAmount;
    const float Distance = 80;
    private void Awake()
    {
        int sectorCount = Random.Range(MinAmount, MaxAmount + 1);
        for (int i = 0; i < sectorCount; i++)
        {
            int prefabIndex = Random.Range(0, LevelPrefabs.Length);
            GameObject level = Instantiate(LevelPrefabs[prefabIndex], transform);
            level.transform.localPosition = CalculateLevelPosition(i);
            level.transform.localRotation = Quaternion.identity;
        }
        Finish.localPosition = CalculateLevelPosition(sectorCount);
    }
    private Vector3 CalculateLevelPosition(int levelIndex)
    {
        return new Vector3(0, 0, Distance * levelIndex);
    }
}