
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;

    public void Update()
    {
        transform.Translate(-Vector3.right * _speed * Time.deltaTime);
    }
}
