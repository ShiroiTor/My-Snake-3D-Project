using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public GameObject Snake;
    public Transform Finish;
    public Slider Slider;
    private float _startZ;
    private float _minimumReachedZ;
    private void Start()
    {
        _startZ = Snake.transform.position.z;
    }
    private void Update()
    {
        float currentPosZ = Snake.transform.position.z;
        float finishPosZ = Finish.transform.position.z;
        float s = Mathf.InverseLerp(_startZ, finishPosZ, currentPosZ);
        Slider.value = s;
    }
}