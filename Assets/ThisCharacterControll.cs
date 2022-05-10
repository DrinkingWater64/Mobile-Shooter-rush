using UnityEngine;

public class ThisCharacterControll: MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;


    protected void Move(Vector3 direction)
    {
        _rb.velocity = direction * _speed * Time.deltaTime;
    }

}
