﻿using UnityEngine;
using System.Collections;

public class WhoAreWe : Enemy {

    public static float maxHealth = 30;

    public static float range = 300;
    public static float speed = 0.7F;
    public static float baseWaitTime = 2.5F;

    private float waitTime;
    private float goToPosition;
    private float maxRange;
    private float minRange;

    private float stopMargin = 10;

	void Start () {
        Initialize();
        SetEnemyHealth(maxHealth);
        enemyBodyDamage = 40;

        waitTime = baseWaitTime;
        maxRange = transform.position.x + range;
        minRange = transform.position.x - range;
        goToPosition = Random.Range(minRange, maxRange);
    }

	void Update () {
        CustomUpdate();
        Enemy_movement();
    }

    public void Enemy_movement()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            if (transform.position.x + stopMargin >= goToPosition && transform.position.x - stopMargin <= goToPosition)
            {
                rigid.velocity = new Vector2(0, 0);
                goToPosition = Random.Range(minRange, maxRange);
                waitTime = baseWaitTime;
            }
            else if (goToPosition >= transform.position.x)
            {
                rigid.velocity += new Vector2(speed, 0);
            }

            else if (goToPosition <= transform.position.x)
            {
                rigid.velocity += new Vector2(-speed, 0);
            }
        }
    }
}
