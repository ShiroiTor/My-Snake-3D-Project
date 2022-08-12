using UnityEngine;
public class SnakeMotion : MonoBehaviour
{
    private float _mouseSpeed = 1.5f;
    public float moveSpeed = 10f;
    public float Sensitivity;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = new Vector3(Input.GetAxis("Mouse X") * _mouseSpeed * Time.deltaTime, 0, 0);
            transform.Translate(delta * _mouseSpeed * Sensitivity);
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}