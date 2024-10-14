using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class SupplyBoxSpawn : MonoBehaviour
    {
        public List<SupplyBox> supplyBoxes = new List<SupplyBox>();
        public List<Transform> listSpawned = new List<Transform>();
        [SerializeField] private float timeSpawn;

        private void Start()
        {
            for (int i = 0; i < supplyBoxes.Count; i++)
            {
                int index = i;

                supplyBoxes[index].onCollection.AddListener(() =>
                {
                    StartCoroutine(SpawnSupplyBox(supplyBoxes[index], listSpawned[index]));
                });

                if (supplyBoxes[index].curBuff == null)
                {
                    StartCoroutine(SpawnSupplyBox(supplyBoxes[index], listSpawned[index]));
                }
            }
        }

        private IEnumerator SpawnSupplyBox(SupplyBox supplyBox, Transform posSpawn)
        {
            Debug.Log("Coroutine");
            yield return new WaitForSeconds(timeSpawn);
            supplyBox.DropAnimation(posSpawn);
        }

    }
}
