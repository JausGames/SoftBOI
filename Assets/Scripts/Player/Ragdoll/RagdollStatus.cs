using UnityEngine;
using System.Collections.Generic;

abstract public class RagdollStatus : ScriptableObject {

	//public event System.Action OnValuesUpdated;
	//public bool autoUpdate;

	abstract public void ApplyRagdollStatus(JointsManager joints);


/*#if UNITY_EDITOR

    protected virtual void OnValidate() {
		if (autoUpdate) {
			UnityEditor.EditorApplication.update += NotifyOfUpdatedValues;
		}
	}

	public void NotifyOfUpdatedValues() {
		UnityEditor.EditorApplication.update -= NotifyOfUpdatedValues;
		if (OnValuesUpdated != null) {
			OnValuesUpdated ();
		}
	}

	#endif*/

}
