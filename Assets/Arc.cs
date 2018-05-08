using UnityEngine;
using System.Collections;

public class Arc : MonoBehaviour 
{
	[SerializeField] private Transform m_target = null;
	[SerializeField] private float m_speed = 1f;

	private Transform m_transform = null;

	public void Awake()
	{
		m_transform = transform;
	}

	public void Update()
	{
		Vector3 position = m_transform.position;

		if(Input.GetMouseButtonDown(0))
		{
						Debug.Log(Screen.height * Input.mousePosition.x + Screen.width * Input.mousePosition.y - Screen.width * Screen.height);

			Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			startPos.z = 0f;
			position = startPos;

			float v = Screen.height * Input.mousePosition.x + Screen.width * Input.mousePosition.y - Screen.width * Screen.height;

			if(v > 0)
			{
				transform.rotation = Quaternion.Euler(Vector3.forward * 30f);
			}
			else if(v < 0)
			{
				transform.rotation = Quaternion.Euler(Vector3.forward * 210f);
			}
		}

		Vector3 targetPos = (m_target.position - position);
		float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);

		position += transform.right * Time.deltaTime * m_speed;




		m_transform.position = position;
	}
}
