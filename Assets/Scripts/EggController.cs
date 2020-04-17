﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;


public class EggController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

    [System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	#region health_variables
	public float maxHealth;
	float currHealth;
	public Slider hpSlider;
	#endregion

	#region animation_variables
	Animator anim;
	public float JumpTime = 0.5f;
	#endregion

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		currHealth = maxHealth;
		hpSlider.value = currHealth / maxHealth;

		anim = GetComponent<Animator>();
	}

    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

    #region health_functions
    public void TakeDamage(int value)
    {
		currHealth -= value;
		hpSlider.value = currHealth / maxHealth;
		if (currHealth <= 0)
		{
			Die();
		}
	}

	public void Heal(int value)
	{
		currHealth += value;
		currHealth = Mathf.Min(currHealth, maxHealth);
		hpSlider.value = currHealth / maxHealth;
	}

	public void Die()
	{
		GameObject gm = GameObject.FindWithTag("GameController");
		gm.GetComponent<GameMaster>().RespawnEgg(this);
	}
	#endregion

	public void Move(float move, bool crouch, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			anim.SetBool("Moving", true);
			if (move == 0)
			{
				anim.SetBool("Moving", false);
			}
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			StartCoroutine(JumpAnim());

			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, Math.Sign(m_Rigidbody2D.gravityScale) * m_JumpForce));
		}
	}

	IEnumerator JumpAnim()
    {
		anim.SetBool("Jumping", true);
		yield return new WaitForSeconds(JumpTime);
		anim.SetBool("Jumping", false);
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void portal(Vector3 portalPosition)
	{
		Debug.Log("attempting to portal");
		transform.position = new Vector3(transform.position.x, transform.position.y - 2 * (transform.position.y - portalPosition.y), transform.position.z);
		transform.Rotate(180, 0, 0, Space.Self);
		m_Rigidbody2D.gravityScale *= -1;

	}
}