using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControll : ThisCharacterControll
{
    [SerializeField] private ScreenControl _input;
    [SerializeField] private ShootControll _shootcontroll;

    private List<Transform> enemies = new List<Transform>();

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_input._direction.x, 0, _input._direction.y);
        Move(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (!enemies.Contains(other.transform))
            {
                enemies.Add(other.transform);
            }



            var direction = other.transform.position - transform.position;
            direction = direction.normalized;
            _shootcontroll.Shoot(direction, transform.position);
            transform.LookAt(other.transform);

        }
    }


}
