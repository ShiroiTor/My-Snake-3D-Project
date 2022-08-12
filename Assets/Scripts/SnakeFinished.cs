using UnityEngine;
public class SnakeFinished : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeControls snakeControls))
        {
            snakeControls.ReachedFinish();
        }
    }
}