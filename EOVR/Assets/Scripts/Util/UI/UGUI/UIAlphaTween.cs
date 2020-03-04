using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAlphaTween : UITween
{
	public uTools.TweenAlpha tw;
	public float type_1;
	public float type_2;


	void Awake()
	{
		if (null == tw)
			tw = gameObject.GetComponent<uTools.TweenAlpha>();

		if (null != tw)
			tw.onFinished.AddListener(OnFinishedEvent);
	}
	

	public override void PlayT1( bool _isDisable = false, UnityEngine.Events.UnityAction _event = null)
	{
		base.PlayT1(_isDisable, _event);

		tw.from = type_1;
		tw.to = type_2;
		tw.delay = type_1_delay;
		tw.method = type_1_method;
		tw.duration = type_1_duration;
		tw.ResetToBeginning();
		tw.PlayForward();
	}

	public override void PlayT2(bool _isDisable = false, UnityEngine.Events.UnityAction _event = null)
	{
		base.PlayT2(_isDisable, _event);

		tw.from = type_2;
		tw.to = type_1;
		tw.delay = type_2_delay;
		tw.method = type_2_method;
		tw.duration = type_2_duration;
		tw.ResetToBeginning();
		tw.PlayForward();
	}
}

