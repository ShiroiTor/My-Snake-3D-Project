using UnityEngine;
public class Food : MonoBehaviour
{
    public AudioSource TakeItemSound;
    private void Start()
    {
        TakeItemSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead")) 
        {
            other.GetComponent<SnakeControls>().AddTailElement();
            TakeItemSound.Play();
            Destroy(gameObject, TakeItemSound.clip.length);
        }
    }
}