using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class BuffUIItem : MonoBehaviour
    {
        private float _time;
        private Animator anim;
        private const string boolName = "Fade";
        public string nameBuff;

        private void Start()
        {
            anim = GetComponent<Animator>();
            Hide();
        }
        public float time
        {
            set { _time = value; }
        }


        public IEnumerator CoroutineBuff()
        {
            yield return new WaitForSeconds(_time / 2f);
            anim.SetBool(boolName, true);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
            anim.SetBool(boolName, true);
        }

        private void OnEnable()
        {
            StartCoroutine(CoroutineBuff());
        }


    }
}

