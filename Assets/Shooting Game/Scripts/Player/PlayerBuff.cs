using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class PlayerBuff : MonoBehaviour
    {
        private List<BaseBuff> activeBuffs = new List<BaseBuff>();

        public void AddBuff(BaseBuff buff)
        {
            activeBuffs.Add(buff);
            buff.ApplyBuff();

            StartCoroutine(RemoveBuffAfterTime(buff, buff.buffSO.buffData.effectTime));
        }

        private IEnumerator RemoveBuffAfterTime(BaseBuff buff, float duration)
        {
            yield return new WaitForSeconds(duration);
            buff.RemoveBuff(); 
            activeBuffs.Remove(buff); 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.HEALTHBUFF_TAG)){
                BaseBuff baseBuff = collision.GetComponent<BaseBuff>();
                HealthBuff healthBuff = baseBuff as HealthBuff;
                Debug.Log(this.gameObject.GetComponent<Player>());
                healthBuff.SetPlayer(this.gameObject.GetComponent<Player>());
                AddBuff(healthBuff);

                collision.gameObject.SetActive(false);
            }
            if (collision.CompareTag(Constants.SHIELDBUFF_TAG))
            {
                BaseBuff baseBuff = collision.GetComponent<BaseBuff>();
                ShieldBuff shieldBuff = baseBuff as ShieldBuff;
                Debug.Log(this.gameObject.GetComponent<Player>());
                shieldBuff.SetPlayer(this.gameObject.GetComponent<Player>());
                AddBuff(shieldBuff);

                collision.gameObject.SetActive(false);

            }
        }


    }
}

