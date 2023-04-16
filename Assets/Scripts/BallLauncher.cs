using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallLauncher : MonoBehaviour
    {
        public event Action OnLaunched;
        
        [SerializeField] private int _ballsPerLaunch = 20;
        [SerializeField] private float _delayBetweenLaunches = 0.2f;
        
        [SerializeField] private float _launchSpeed = 1f;
        [SerializeField] private Rigidbody2D _ballPrefab;
        [SerializeField] private AimInputProviderBase _inputProvider;

        private void Start()
        {
            _inputProvider.OnLaunch += Launch;
        }

        // срабатывает по подписке - кто то вызвал событие OnLaunch
        private void Launch()
        {
            // отписались, чтобы больше не получать вызов
            _inputProvider.OnLaunch -= Launch;

            StartCoroutine(LaunchAllBalls());
            
            OnLaunched?.Invoke();
        }

        private IEnumerator LaunchAllBalls()
        {
            for (int i = 0; i < _ballsPerLaunch; i++)
            {
                var ball = Instantiate(_ballPrefab);
                ball.position = transform.position;
                // вектор направления из шара в позицию мышки (прицела)
                var shootDirection = _inputProvider.GetAimTarget() - ball.position;
            
                // делаем вектор направления в длину равным скорости запуска
                shootDirection.Normalize();
                shootDirection *= _launchSpeed;
            
                // запускаем шар с полученной силой
                ball.transform.parent = null;
                ball.AddForce(shootDirection, ForceMode2D.Impulse);

                yield return new WaitForSeconds(_delayBetweenLaunches);
            }
        }

        // private void OnDrawGizmos()
        // {
        //     if (!Application.isPlaying) return;
        //     
        //     Gizmos.color = Color.red;
        //
        //     var targetPos = _inputProvider.GetAimTarget();
        //     var initialPos = transform.position;
        //
        //     Gizmos.DrawLine(initialPos, targetPos);
        // }
    }
}