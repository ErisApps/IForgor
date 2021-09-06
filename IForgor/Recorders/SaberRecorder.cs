﻿using IPA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IForgor
{
	internal class SaberRecorder : MonoBehaviour
	{
		public static SaberRecorder instance { get; private set; }

		private Saber _saberA;
		private Saber _saberB;

		public float saberAAngle = 0.0f;
		public float saberBAngle = 0.0f;

		private void Awake() {
			if (instance != null) {
				Destroy(instance);
			}
			instance = this;
		}

		private void OnEnable() {
			SaberManager saberManager = Resources.FindObjectsOfTypeAll<SaberManager>().First();
			_saberA = saberManager.leftSaber;
			_saberB = saberManager.rightSaber;
		}

		public void RecordSaberAngles() {
			RecordSaberAngle(_saberA, ref saberAAngle);
			RecordSaberAngle(_saberB, ref saberBAngle);
		}

		public void RecordSaberAngle(Saber saber, ref float saberAngle) {
			Vector3 saberVector = saber.saberBladeTopPos - saber.saberBladeBottomPos;
			saberVector.z = 0;
			saberVector.Normalize();

			saberAngle = Mathf.Atan2(saberVector.y, saberVector.x) * Mathf.Rad2Deg;
		}
	}
}