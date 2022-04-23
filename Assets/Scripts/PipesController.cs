using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0f;
    [SerializeField]
    private float timeToDestroy = 0f;

    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.instance.GameIsPaused)
        {
            Movement();
        }
    }

    private void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }
}
