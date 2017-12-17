using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    private float enemyHealth;
    private Rigidbody2D rigid;
    private Vector3 initialScale;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        turnAroundEnemy();
        KillEnemy();
    }

    public void SetEnemyHealth(float value)
    {
        enemyHealth = value;
    }

    private void KillEnemy()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void turnAroundEnemy()
    {

        if (rigid.velocity.x < 0)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else if (rigid.velocity.x > 0)
        {
            transform.localScale = new Vector3(initialScale.x * -1, initialScale.y, initialScale.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;
    
        if (other_obj.GetComponent<Weapon>())
        {
            enemyHealth -= other_obj.GetComponent<Weapon>().damageToDeal;
        }
    }
}
