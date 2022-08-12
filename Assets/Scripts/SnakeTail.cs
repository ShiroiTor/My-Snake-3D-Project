using UnityEngine;
public class SnakeTail : MonoBehaviour
{
    public float Speed;
    public Vector3 Target;
    public GameObject Obj;
    public SnakeControls Snake;
    public SnakeMotion Motion;
    void Start()
    {
        Snake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeControls>();
        Speed = Motion.moveSpeed + 1.5f;
        Obj = Snake.tailElements[Snake.tailElements.Count - 2];
    }
    void Update()
    {
        Target = Obj.transform.position;
        transform.LookAt(Target);
        transform.position = Vector3.Lerp(transform.position, Target,Time.deltaTime * Speed);
    }
}