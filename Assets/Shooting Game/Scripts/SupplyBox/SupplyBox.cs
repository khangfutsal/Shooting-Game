using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShootingGame
{
    public class SupplyBox : MonoBehaviour
    {
        public List<BaseBuff> buffs;
        public BaseBuff curBuff;

        public UnityEvent onCollection = new UnityEvent();

        [SerializeField] private float dropTime;
        [SerializeField] private Vector3 offset;


        private void Start()
        {
            buffs = BuffController.Ins.buffManager.GetListBuffs();
        }



        public void DropAnimation(Transform posSpawn)
        {
            int random = UnityEngine.Random.Range(0, buffs.Count);
            this.gameObject.SetActive(true);
            transform.position = new Vector3(posSpawn.position.x,posSpawn.position.y + offset.y, posSpawn.position.z);
            transform.DOMoveY(posSpawn.position.y + 2.5f, dropTime).OnComplete(() =>
            {
                var targetSpawn = new Vector3(transform.position.x, transform.position.y - 2.5f);
                GameObject obj = ObjectPool.Ins.SpawnFromPool(buffs[random].name, targetSpawn, Quaternion.identity);
                curBuff = obj.GetComponent<BaseBuff>();
                curBuff.onCollect.AddListener(OnEvent);
                InActiveObject();
            });
        }

        public void OnEvent()
        {
            onCollection?.Invoke();
        }

        public void InActiveObject()
        {
            this.gameObject.SetActive(false);
        }


    }
}

