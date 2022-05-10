using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCotroller : ThisCharacterControll
{
    [SerializeField] private PlayerControll _player;

    private void FixedUpdate()
    {
        var delta = _player.transform.position - transform.position;
        var direction = delta.normalized;
        Move(direction);
        transform.LookAt(_player.transform);
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag($"Bullet"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
