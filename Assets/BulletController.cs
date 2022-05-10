using UnityEngine;

public class BulletController: MonoBehaviour
{

    [SerializeField] private float _bulletSpeed;
    private Vector3 _movement;
    private void Start()
    {
        Destroy(gameObject, 3);
    }
    public void FixedUpdate()
    {
        transform.position += _movement;
    }

    public void Fire(Vector3 direction)
    {
        _movement = direction * _bulletSpeed * Time.deltaTime;
    }

}
