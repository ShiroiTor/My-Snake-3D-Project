using TMPro;
using UnityEngine;
using Random = System.Random;
public class CubeHP : MonoBehaviour
{
    public int cubeHP;
    public TextMeshPro CubeHPText;
    public Material EasyCubeMaterial;
    public Material NormalCubeMaterial;
    public Material HardCubeMaterial;
    public AudioSource BreackSound;
    public ParticleSystem Parts;
    private void Update()
    {
        CubeHPText.text = cubeHP.ToString();
    }
    private void Start()
    {
        GetCubeHP();
        Parts = GetComponent<ParticleSystem>();
        BreackSound = GetComponent<AudioSource>();

        if (cubeHP < 5)
        {
            GetComponent<Renderer>().sharedMaterial = EasyCubeMaterial;
        }
        else if (cubeHP > 5 && cubeHP <= 7)
        {
            GetComponent<Renderer>().sharedMaterial = NormalCubeMaterial;
        }
        else if (cubeHP > 7)
        {
            GetComponent<Renderer>().sharedMaterial = HardCubeMaterial;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out SnakeControls snakeControls)) 
        {
            CubeTakeDamage();
        }
    }
    public int GetCubeHP()
    {
        Random randomCubeHP = new Random();
        cubeHP = randomCubeHP.Next(1, 10);
        return cubeHP;
    }
    public void CubeTakeDamage(int damage = 1)
    {
        cubeHP-=damage;
        Debug.Log("Ñube received damage: " + damage);
        if (cubeHP <= 0)
        {
            Parts.Play();
            BreackSound.Play();
            Destroy(gameObject, BreackSound .clip.length);
            cubeHP = 0;
        }
    }
}