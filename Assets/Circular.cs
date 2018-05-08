using UnityEngine;
using System.Collections;

public class Circular : MonoBehaviour
{
	[SerializeField] private float m_speed = 5f;
	[SerializeField] private float m_amplitude = 5f;

	private Transform m_transform = null;

	public void Awake()
	{
		m_transform = transform;
	}

	public void Update()
	{
		Vector3 position = m_transform.position;
		position.x = m_amplitude * Mathf.Sin(Time.time * m_speed * Mathf.PI);
		position.y = m_amplitude * Mathf.Cos(Time.time * m_speed * Mathf.PI);
		m_transform.position = position;
	}
}
