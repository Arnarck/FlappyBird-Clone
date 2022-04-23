using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float Speed = 0f;

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
        if (transform.position.x <= -7.4f)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }
}
