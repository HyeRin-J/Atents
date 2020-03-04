using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{	
	bool m_isFinishedDisable = false;
	UnityEngine.Events.UnityAction m_finishedEvent;

	public float type_1_delay;
	public float type_2_delay;
	public float type_1_duration = 0.5f;
	public float type_2_duration = 0.1f;
	public uTools.EaseType type_1_method = uTools.EaseType.spring;
	public uTools.EaseType type_2_method = uTools.EaseType.linear;

	protected void OnFinishedEvent()
	{
		if (true == m_isFinishedDisable)
			gameObject.SetActive(false);

		if (null != m_finishedEvent)
		{
			m_finishedEvent();
		}
	}

	public bool isOpen
	{
		get
		{
			return gameObject.activeSelf;
		}
	}

	public virtual void PlayT1(bool _isDisable = false, UnityEngine.Events.UnityAction _event = null)
	{
		gameObject.SetActive(true);
		m_isFinishedDisable = _isDisable;
		m_finishedEvent = _event;		
	}

	public virtual void PlayT2(bool _isDisable = false, UnityEngine.Events.UnityAction _event = null)
	{
		gameObject.SetActive(true);
		m_isFinishedDisable = _isDisable;
		m_finishedEvent = _event;		
	}
}