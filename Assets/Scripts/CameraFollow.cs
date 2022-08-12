using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    void Update()
    {
        Vector3 TransPos = transform.position;
        TransPos.z = Target.position.z;
        transform.position = TransPos + Offset;
        TransPos.x = Target.position.x;
        transform.position = TransPos + Offset;
    }
}