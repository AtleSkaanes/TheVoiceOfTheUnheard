using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ProgressiveSadder : MonoBehaviour
{

    [SerializeField] [CanBeNull] private ParticleSystem rain;
    private ParticleSystem.EmissionModule rainEmission;

    private Volume volume;
    private Vignette vignette;
    private Bloom bloom;
    private ColorAdjustments colorAdjustments;


    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out bloom);
        volume.profile.TryGet(out colorAdjustments);

        int lvlIndex = GameManager.currentLevelIndex;

        vignette.intensity.Override((lvlIndex + 1) / 10);

        bloom.intensity.Override(3 / (lvlIndex + 1));

        colorAdjustments.saturation.Override((20 - lvlIndex * 20));

        if (rain != null && lvlIndex > 2)
        {
            rainEmission = rain.emission;
            rainEmission.enabled = true;
            rainEmission.rateOverTime = 300 * lvlIndex;
        }
    }
}
