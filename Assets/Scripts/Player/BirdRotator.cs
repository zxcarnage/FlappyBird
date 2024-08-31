using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Transform))]
    public class BirdRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;
        
        private Transform _birdTransform;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Awake()
        {
            _birdTransform = GetComponent<Transform>();
            
        }

        private void Start()
        {
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _birdTransform.rotation = Quaternion.identity;
        }

        private void Update()
        {
            RotateBird();
            
        }
        
        private void RotateBird()
        {
            RotateDown();
            TryRotateUp();
        }

        private void TryRotateUp()
        {
            if (Input.GetMouseButtonDown(0))
                _birdTransform.rotation = _maxRotation;
        }

        private void RotateDown()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}