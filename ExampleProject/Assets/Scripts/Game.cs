using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [SerializeField]
    public List<GameObject> Walls;

    [SerializeField]
    public Material RedMaterial;

    private void Awake()
    {
        Instance = this;
    }

    public void OnWallHit()
    {
        foreach (GameObject wall in Walls)
            wall.GetComponent<Renderer>().material = RedMaterial;
    }
}