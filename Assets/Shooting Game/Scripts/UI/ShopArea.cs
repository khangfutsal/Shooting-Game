using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class ShopArea : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IShopCustomer shopCustomer = collision.transform.GetComponent<IShopCustomer>();
            if (shopCustomer != null)
            {
                Debug.Log("Test");
                UIController.Ins.manager.GetShopUI().Show(shopCustomer);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            IShopCustomer shopCustomer = collision.transform.GetComponent<IShopCustomer>();
            if (shopCustomer != null)
            {
                UIController.Ins.manager.GetShopUI().Hide();
            }
        }


    }
}

