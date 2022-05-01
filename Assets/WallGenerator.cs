using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

  [SerializeField]
  GameObject cubePrefab;

  List<GameObject> cubes = new List<GameObject>();

  Color[] colors = {
    new Color(1.0f, 0.0f, 0.0f, 0.4f),
    new Color(0.0f, 1.0f, 0.0f, 0.4f),
    new Color(0.0f, 0.0f, 1.0f, 0.4f),
    new Color(1.0f, 1.0f, 1.0f, 0.4f),
  };

  // Start is called before the first frame update
  void Start()
  {
    initializeWall();
  }

  void initializeWall()
  {
    int index = 0;
    for (int y = 0; y < 5; y++)
    {
      for (int x = 0; x < 5; x++)
      {
        GameObject cube = GameObject.Instantiate(cubePrefab);

        cube.transform.parent = transform;
        cube.transform.localPosition = new Vector3(
            x * cube.transform.localScale.x,
            y * cube.transform.localScale.y,
            0
        );

        cube.GetComponent<Renderer>().material.color = colors[index];

        index++;
        index %= colors.Length;

        cubes.Add(cube);
      }
    }
  }

  public void ResetWall()
  {
    for (int i = 0; i < cubes.Count; i++)
    {
      DestroyImmediate(cubes[i]);
    }
    cubes.Clear();
    initializeWall();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
