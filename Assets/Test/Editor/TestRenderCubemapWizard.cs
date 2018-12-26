using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestRenderCubemapWizard : ScriptableWizard {

	public Transform renderFromPosition;
	public Cubemap cubemap;

	void OnWizardUpdate() {
		string helpString = "Select transform to render from and cubemap to render into";
		bool isValid = (renderFromPosition != null) && (cubemap != null);
	}

	void OnWizardCreate() {
		GameObject go = new GameObject("CubemapCamera");
		go.AddComponent<Camera>();

		go.transform.position = renderFromPosition.position;
		go.transform.rotation = Quaternion.identity;

		go.GetComponent<Camera>().RenderToCubemap(cubemap);

		DestroyImmediate(go);
	}

	[MenuItem("GameObject/Render/Test Rendr into Cubemap")]
	static void RenderCubemap() {
		TestRenderCubemapWizard.DisplayWizard<TestRenderCubemapWizard>("Render Cubemap", "Render!");
	}
}
