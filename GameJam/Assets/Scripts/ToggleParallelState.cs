using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
public enum ParallelState
{
	Present,
	Past,
}
public class ToggleParallelState : MonoBehaviour
{
	public Tilemap tilemapPast;
	public CompositeCollider2D compositeCollider2DPast;
	public Tilemap tilemapPresent;
	public CompositeCollider2D compositeCollider2DPresent;
	public ParallelState state = ParallelState.Present;
	public CinemachineVirtualCamera virtualCamera;
	public Volume volume;
	readonly float changeTime = 0.7f;
	float changeTimeCounter;

	Color colorPast = Color.white;
	Color colorPresent = Color.white;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C) && !LevelManager.Instance.insideWall && changeTimeCounter <= 0f)
		{
			changeTimeCounter = changeTime;
			state = state == ParallelState.Present ? ParallelState.Past : ParallelState.Present;
			StartCoroutine(ShakeCamera());
		}
		if (changeTimeCounter >= 0f)
		{
			changeTimeCounter -= Time.deltaTime;
		}
		if (state == ParallelState.Present)
		{
			colorPast.a = 0.3f;
			colorPresent.a = 1f;
			tilemapPast.color = colorPast;
			tilemapPresent.color = colorPresent;
			compositeCollider2DPast.isTrigger = true;
			compositeCollider2DPresent.isTrigger = false;
		}

		if (state == ParallelState.Past)
		{
			colorPast.a = 1f;
			colorPresent.a = 0.3f;
			tilemapPast.color = colorPast;
			tilemapPresent.color = colorPresent;
			compositeCollider2DPast.isTrigger = false;
			compositeCollider2DPresent.isTrigger = true;
		}
	}

	IEnumerator ShakeCamera()
	{
		CinemachineBasicMultiChannelPerlin cbmp = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

		LensDistortion distortion;
		volume.profile.TryGet(out distortion);
		distortion.intensity.value = 0;
		float _intensity = 0f;
		DOTween.To(() => _intensity, x => _intensity = x, -0.5f, 0.5f)
			.OnUpdate(() =>
			{
				distortion.intensity.value = _intensity;
			});
		cbmp.m_AmplitudeGain = 1;
		yield return new WaitForSeconds(0.5f);
		DOTween.To(() => _intensity, x => _intensity = x, 0f, 0.5f)
			.OnUpdate(() =>
			{
				distortion.intensity.value = _intensity;
			});
		cbmp.m_AmplitudeGain = 0;
	}
}
