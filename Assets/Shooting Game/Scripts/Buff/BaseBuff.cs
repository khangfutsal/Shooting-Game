using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace ShootingGame
{
    public abstract class BaseBuff : MonoBehaviour
    {
        public BuffSO buffSO;
        public UnityEvent onCollect = new UnityEvent();

        public virtual void ApplyBuff()
        {
            Debug.Log("Invoke");
            onCollect?.Invoke();
        }

        public abstract void RemoveBuff();
    }
}
