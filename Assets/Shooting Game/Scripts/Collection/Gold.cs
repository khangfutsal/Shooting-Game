using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private int randomGold;
    [SerializeField] private int firstRandom;
    [SerializeField] private int secondRandom;


    public void RandomGold()
    {
        randomGold = UnityEngine.Random.RandomRange(firstRandom, secondRandom);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }

    private void OnEnable()
    {
        RandomGold();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PLAYERTAG))
        {
            GameController.Ins.manager.AdditiveGold(randomGold);
            ObjectPool.Ins.ReturnToPool("Gold", this.gameObject);
        }
    }
}
