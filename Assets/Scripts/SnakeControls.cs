using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.ProBuilder.Shapes;

public class SnakeControls : MonoBehaviour
{
    private float _offset = 0.4f;
    public int snakeHP = 0;
    public Text snakeHPText;
    public Rigidbody Rigidbody;
    public GameObject tailPrefab;
    public GameControl gameControl;
    public List<GameObject> tailElements = new List<GameObject>();
    void Start()
    {
        tailElements.Add(gameObject);
    }
    void Update()
    {
        snakeHPText.text = "Snake HP: " + snakeHP.ToString();
    }
    public void AddTailElement() 
    {
        Vector3 newTailPos = tailElements[tailElements.Count - 1].transform.position;
        newTailPos.z -= _offset;
        tailElements.Add(GameObject.Instantiate(tailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out CubeHP cubeHP))
        {
            if (cubeHP.cubeHP > 0) 
            {
                SnakeTakeDamage();
            }
        }
    }
    public void ReachedFinish() 
    {
        gameControl.SnakeWin();
    }
    public void Death() 
    {
        gameControl.SnakeDied();
    }
    public void RemoveTailElements() 
    {
        Vector3 newTailPos = tailElements[tailElements.Count - 1].transform.position;
        tailElements.Remove(GameObject.Instantiate(tailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CubeHP cubeHP))
        {
            Debug.Log("cube was destroyed!");
            GameControl.score++;
            GameControl.bestScore++;
        }
    }
    public void SnakeTakeDamage(int damage = 1)
    {
        snakeHP-=damage;
        RemoveTailElements();
        Debug.Log("Snake received damage: " + damage);
        if (snakeHP <= 0)
        {
            snakeHP = 0;
            Death();
        }
    }
}