using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControll : ThisCharacterControll
{
    [SerializeField] private ScreenControl _input;
    [SerializeField] private ShootControll _shootcontroll;

    private readonly List<Transform> _enemies = new();
    private bool isShooting;
    private int _enemyAmount;

    private void Start()
    {
        _enemyAmount = FindObjectsOfType<EnemyCotroller>().Length;
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_input._direction.x, 0, _input._direction.y);
        Move(-direction);

        if (_enemies.Count > 0)
        {
            transform.LookAt(_enemies[0]);
        }
        else
        {
            transform.LookAt(-direction);
        }
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
        if (other.CompareTag("FinishLine"))
        {
            Win();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            _enemies.Remove(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (!_enemies.Contains(other.transform))
            {
                _enemies.Add(other.transform);
            }

            ShootEnemy();



        }
    }
    private void ShootEnemy()
    {
        IEnumerator Do()
        {
            while (_enemies.Count > 0)
            {
                Transform enemy = _enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction = direction.normalized;
                _shootcontroll.Shoot(direction, transform.position);
                _enemies.RemoveAt(0);
                yield return new WaitForSeconds(_shootcontroll._delay);
            
            }
            isShooting = false;
        }

        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(Do());

        }
    }

    private void Win()
    {
        Debug.Log("Game won");
        var current = FindObjectsOfType<EnemyCotroller>().Length;
        var result = current / (float)_enemyAmount;
        float success = Mathf.Lerp(100, 0, result);
        Debug.Log($"Completed => %{success}");
    }


}

