using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSort : MonoBehaviour
{
    [SerializeField] private Transform player;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerMove>().transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            sprite.sortingOrder = 3;
        }
        else
        {
            sprite.sortingOrder = 1;
        }
    }
}
