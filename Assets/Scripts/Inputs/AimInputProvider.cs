using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AimInputProvider : AimInputProviderBase
    {
        public override event Action OnLaunch;
        private Vector3 _aimTarget;

        public void Update()
        {
            ProcessLaunchInput();
            ProcessAimInput();
        }

        public override Vector2 GetAimTarget()
        {
            return _aimTarget;
        }

        private void ProcessAimInput()
        {
            _aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void ProcessLaunchInput()
        {
            // если щёлкнули лкм или нажали пробел
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                OnLaunch?.Invoke(); // с проверкой на null, исключение не падает

                // такая же запись, более длинная
                // if (OnLaunch != null)
                // {
                //     OnLaunch.Invoke();
                // }


                // OnLaunch(); // без проверки на null. Если никто не подписан, то упадёт исключение
            }
        }
    }
}