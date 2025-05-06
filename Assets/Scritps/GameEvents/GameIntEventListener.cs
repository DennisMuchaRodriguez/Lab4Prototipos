using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scritps.GameEvents
{
    public class GameIntEventListener : MonoBehaviour
    {
        [SerializeField] private GameIntEvent gameEvent;

        [SerializeField] private UnityEvent<int> response;

        private void OnEnable()
        {
            gameEvent.Register(this);
        }

        private void OnDisable()
        {
            gameEvent.Unregister(this);
        }

        public void OnEventRaised(int value)
        {
            response?.Invoke(value);
        }
    }

}
