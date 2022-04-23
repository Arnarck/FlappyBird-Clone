using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float timeToSpawnPipes = 0f, timeToSpawnGround = 0f;
    [SerializeField]
    private float max_Y_Pos = 0f, min_Y_Pos = 0f;

    [SerializeField] private GameObject pipesPrefab, groundPrefab;

    private bool CanSpawnPipes = true, CanSpawnGround = true;

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.instance.GameIsPaused)
        {
            if (CanSpawnPipes)
            {
                SpawnPipes();
            }

            if (CanSpawnGround)
            {
                SpawnGround();
            }
        }

    }

    private void SpawnPipes()
    {
        float randomY = Random.Range(min_Y_Pos, max_Y_Pos);
        Vector2 SpawnPos = new Vector2(transform.position.x, randomY);

        Instantiate(pipesPrefab, SpawnPos, Quaternion.identity);
        StartCoroutine("PipesSpawner");
    }

    private void SpawnGround()
    {
        Instantiate(groundPrefab, new Vector2(8.30f, -4.60f), Quaternion.identity);
        StartCoroutine("GroundSpawner");
    }

    private IEnumerator PipesSpawner()
    {
        CanSpawnPipes = false;

        yield return new WaitForSeconds(timeToSpawnPipes);

        CanSpawnPipes = true;
    }

    private IEnumerator GroundSpawner()
    {
        CanSpawnGround = false;

        yield return new WaitForSeconds(timeToSpawnGround);

        CanSpawnGround = true;
    }
}
