using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float placementSpeed;
    [SerializeField] private float damageAmount;
    public GameObject brokenBearTrap; 

    private void Start()
    {
    }


    public virtual void TrapAbility(Collider2D collision)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemy/Generic Enemy Death/Generic Enemy Death", transform.position);


        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Bear Trap/Bear Trap Kill", transform.position);

        var baseEnemy = collision.gameObject.GetComponent<BaseEnemy>();
        if (baseEnemy != null)
        {
            baseEnemy.Die();

        }
        Instantiate(brokenBearTrap, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.2f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //trap sfx 
            //stop enemy moving 
            //send something to ui to alert player 
            FindObjectOfType<Inventory>().KillConfirmed();
            TrapAbility(collision);
        }
    }

}

