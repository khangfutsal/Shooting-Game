using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class ShopArea : MonoBehaviour
    {

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                IShopCustomer shopCustomer = collision.transform.GetComponent<IShopCustomer>();
                if (shopCustomer != null)
                {
                    Debug.Log("Test");
                    UIController.Ins.manager.GetShopUI().Show(shopCustomer);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                IShopCustomer shopCustomer = collision.transform.GetComponent<IShopCustomer>();
                if (shopCustomer != null)
                {
                    UIController.Ins.manager.GetShopUI().Hide();
                }
            }
           
        }


    }
}

