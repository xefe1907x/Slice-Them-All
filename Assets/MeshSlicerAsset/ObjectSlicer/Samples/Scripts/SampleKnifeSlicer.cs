using System;
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

		bool isFirstClick;

		float thrustPower = 1085f;
		
		Rigidbody rb;

		void Start()
		{
			InvokeRepeating(nameof(FindTarget),0f,0.1f);
			DOTween.Init();
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var knife = _blade.GetComponentInChildren<BzKnife>();
				knife.BeginNewSlice();
				MoveBlade();
				//StartCoroutine(SwingSword());
			}
		}

		void MoveBlade()
		{
			RotateBlade();
			if (rb != null)
			{
				if (rb.isKinematic)
					rb.isKinematic = false;
				
				rb.AddForce(Vector3.up * thrustPower);
			}
		}
		
		void RotateBlade()
		{
			if (!isFirstClick)
			{
				_blade.transform.DORotate(new Vector3(260f, 0, 0), 0.65f, RotateMode.LocalAxisAdd);
				isFirstClick = true;
			}

			else
			{
				_blade.transform.DORotate(new Vector3(360, 0, 0), 1f, RotateMode.LocalAxisAdd);
			}
		}

		private void FindTarget()
		{
			_blade = GameObject.FindWithTag("Blade");

			if (_blade)
			{
				rb = GameObject.FindWithTag("Blade").GetComponent<Rigidbody>();
				CancelInvoke();
			}
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