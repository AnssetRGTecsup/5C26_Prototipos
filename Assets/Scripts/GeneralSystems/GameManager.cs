using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GeneralSystems
{
    public class GameManager : MonoBehaviour
    {
        public UnityEvent OnStartGame;

        private void Start()
        {
            OnStartGame?.Invoke();
        }
    }
}