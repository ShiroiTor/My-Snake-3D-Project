using UnityEngine;
public class CubesMaterial : MonoBehaviour
{
    public Material EasyCubeMaterial;
    public Material NormalCubeMaterial;
    public Material HardCubeMaterial;
    public int testHP;
    private void Awake()
    {
        if (testHP < 5)
        {
            GetComponent<Renderer>().sharedMaterial = EasyCubeMaterial;
        }
        else if (testHP > 5 && testHP <= 7)
        {
            GetComponent<Renderer>().sharedMaterial = NormalCubeMaterial;
        }
        else if (testHP > 7) 
        {
            GetComponent<Renderer>().sharedMaterial = HardCubeMaterial;
        }
    }
}