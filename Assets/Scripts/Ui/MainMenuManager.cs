using UnityEngine;

namespace DefaultNamespace.Ui
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _windows;

        public void OpenWindow(string windowName)
        {
            foreach (var window in _windows)
            {
                if (window.name == windowName)
                {
                    window.gameObject.SetActive(true);
                }
                else
                {
                    window.gameObject.SetActive(false);
                }
            }
        }
    }
}