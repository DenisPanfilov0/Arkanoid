using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MouseHorizontalInput : HorizontalInputProviderBase
    {
        [SerializeField] private BallLauncher _ballLauncher;
        
        private Vector3 _mousePosOld;
        private bool _ballWasLaunched = false;

        private void Awake()
        {
            _ballLauncher.OnLaunched += OnBallLaunched;
        }

        private void OnBallLaunched()
        {
            _ballWasLaunched = true;
        }

        private void Update()
        {
            _mousePosOld = Input.mousePosition;
        }

        public override float GetCurrentInput(float currentPosition, float speed)
        {
            if (!_ballWasLaunched) return 0f;
            return currentPosition + -(_mousePosOld - Input.mousePosition).x * speed;
        }
    }
}