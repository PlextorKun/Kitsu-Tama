using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispShooter : MonoBehaviour
{
    public GameObject projectile;
	public GameObject target;
    public float pauseTime;
    public float fireTime;
    public float fireSpeed;

	public float projectileExistTime = 2;

    private float bulletsLeft = 3;
    private float fireTimer = 0;
    private float pauseTimer = 0;

	private float fireDir = -1;

	private bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!shooting)
        {
			return;
        }
		if (bulletsLeft == 0)
        {
			if (pauseTimer > pauseTime)
			{
				bulletsLeft = 3;
				pauseTimer = 0;
			}
			else
            {
				pauseTimer += Time.deltaTime;
            }
			float dir = target.transform.position.x - transform.position.x;
			if (dir * fireDir < 0)
            {
				fireDir *= -1;
            }
			return;
        }
		if (fireTimer > fireTime)
		{
			fireTimer = 0;
			bulletsLeft -= 1;
							
			Vector2 FireDirection = new Vector2(fireDir, 0);
			FireDirection = FireDirection * fireSpeed;

			GameObject newProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			newProjectile.GetComponent<Rigidbody2D>().velocity = FireDirection;
			Destroy(newProjectile, projectileExistTime);
		}
		else
		{
			fireTimer += Time.deltaTime;
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == target)
        {
			shooting = true;
        }
    }

	void OnTriggerExit2D(Collider2D coll)
    {
		if (coll.gameObject == target)
        {
			shooting = false;
        }
    }
}




