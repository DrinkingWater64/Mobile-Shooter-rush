using UnityEngine;

public class BulletController: MonoBehaviour
{

    [SerializeField] private float _bulletSpeed;
    private Vector3 _movement;
    public void FixedUpdate()
    {
        transform.position += _movement;
    }

    public void Fire(Vector3 direction)
    {
        _movement = direction * _bulletSpeed * Time.deltaTime;
    }

}
