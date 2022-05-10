using UnityEngine;

public class ShootControll: MonoBehaviour
{
    [SerializeField] private BulletController _bulletPrefab;

    public void Shoot(Vector3 direction, Vector3 position)
    {
        var bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
        bullet.Fire(direction);
    }
}
