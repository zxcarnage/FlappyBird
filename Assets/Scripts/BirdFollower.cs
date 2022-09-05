using UnityEngine;

public class BirdFollower : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _cameraOffsetX;

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x + _cameraOffsetX, 0, -10);
    }
}
