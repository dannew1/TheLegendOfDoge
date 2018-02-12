using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private Image mask;
    private Image healthBar;

    private float enemyHealth;
    private float enemyMaxHealth;
    private float healthBarTimer = 0;
    private Rigidbody2D rigid;
    private Vector3 initialScale;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;

        mask = gameObject.transform.GetChild(0).GetComponent<Image>();
        healthBar = mask.gameObject.transform.GetChild(0).GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        turnAroundEnemy();
        KillEnemy();
        HealthBar();
    }

    public void SetEnemyHealth(float value)
    {
        enemyMaxHealth = value;
        enemyHealth = enemyMaxHealth;
    }

    private void KillEnemy()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HealthBar()
    {
        healthBar.fillAmount = enemyHealth / enemyMaxHealth;

        if (healthBarTimer > 0)
        {
            healthBarTimer -= Time.deltaTime;
        }
        
        if(healthBarTimer <= 0)
        {
            mask.color = new Color(0.8f, 0.8f, 0.8f, 0);
            healthBar.color = new Color(1, 0, 0, 0);
        }
        else if(healthBarTimer > 0 && healthBarTimer < 1)
        {
            mask.color = new Color(0.8f, 0.8f, 0.8f, healthBarTimer);
            healthBar.color = new Color(1, 0, 0, healthBarTimer);
        }
        else
        {
            mask.color = new Color(0.8f, 0.8f, 0.8f, 1);
            healthBar.color = new Color(1, 0, 0, 1);
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
            healthBarTimer = 4;
        }
    }
}
