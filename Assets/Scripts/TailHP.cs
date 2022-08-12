using TMPro;
using UnityEngine;
using Random = System.Random;
public class TailHP : MonoBehaviour
{
    public int _tailHP;
    public TextMeshPro TailHPText;
    private void Update()
    {
        TailHPText.text = _tailHP.ToString();
    }
    private void Start()
    {
        GetFoodHP();
    }
    public int GetFoodHP()
    {
        Random randomFoodHP = new Random();
        _tailHP = randomFoodHP.Next(2, 12);
        return _tailHP;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeControls snakeControls))
        {
            Debug.Log("Snake restored: " + _tailHP + " HP");
            snakeControls.snakeHP += _tailHP;
        }
    }
}