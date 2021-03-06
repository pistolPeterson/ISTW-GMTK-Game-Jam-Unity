using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    [SerializeField] private ItemType type;
    [SerializeField] private int amt;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;

        if(time > 60f)
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        return;
        if (collision.CompareTag("Player"))
        {
            amt = Random.Range(1, 7);
            collision.gameObject.GetComponent<Inventory>().Add(type, amt);

            Destroy(this.gameObject);
        }
    }
}

public enum ItemType
{
    NONE,
    THORNY_BRANCH,
    BROKEN_BEAR_TRAP,
    ROPE,
    VINE, 
    WINE_GLASS
}
