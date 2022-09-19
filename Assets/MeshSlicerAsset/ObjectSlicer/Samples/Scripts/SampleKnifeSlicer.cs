﻿using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace BzKovSoft.ObjectSlicer.Samples
{
	/// <summary>
	/// Knife visual effect implementation
	/// </summary>
	public class SampleKnifeSlicer : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField]
		private GameObject _blade;
#pragma warning restore 0649

		

		void Start()
		{
			// InvokeRepeating(nameof(FindTarget),0f,0.1f);
		}

		void Update()
		{
			FindTarget();
			if (Input.GetMouseButtonDown(0))
			{
				var knife = _blade.GetComponentInChildren<BzKnife>();
				knife.BeginNewSlice();
				//StartCoroutine(SwingSword());
			}
		}

		void FindTarget()
		{
			if (!_blade)
			{
				_blade = GameObject.FindWithTag("Blade");
			}

			// if (_blade)
			// {
			// 	CancelInvoke();
			// }
		}

		IEnumerator SwingSword()
		{
			var transformB = _blade.transform;
			transformB.position = Camera.main.transform.position;
			transformB.rotation = Camera.main.transform.rotation;

			const float seconds = 0.5f;
			for (float f = 0f; f < seconds; f += Time.deltaTime)
			{
				float aY = (f / seconds) * 180 - 90;
				float aX = (f / seconds) * 60 - 30;
				//float aX = 0;

				var r = Quaternion.Euler(aX, -aY, 0);

				transformB.rotation = Camera.main.transform.rotation * r;
				yield return null;
			}
		}
	}
}