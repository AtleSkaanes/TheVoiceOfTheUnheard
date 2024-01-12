using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Slider progressBarSlider;
    [SerializeField] private TextMeshProUGUI metersRematiningTxt;
    [SerializeField] private GameObject pressEBox;
    [SerializeField] private Transition transition;

    [Header("UI Properties")]
    [SerializeField] private Color sliderHighlightColor;

    private Color sliderNormalColor;
    private Image sliderFillImage;

    private float maxDist;

    void Start()
    {
        maxDist = ObjectiveLocation.Instance.Distance(transform.position);
        sliderFillImage = progressBarSlider.fillRect.GetComponent<Image>();
        sliderNormalColor = sliderFillImage.color;
    }

    void Update()
    {
        float dist = ObjectiveLocation.Instance.Distance(transform.position);
        HandleDistanceUI(dist);
        HandleNearTargetActions(dist);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transition.FadeOut();
            StartCoroutine(GameManager.ChangeSceneWithDelay(SceneType.MainMenu, 0.5f));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            transition.FadeOut();
            StartCoroutine(GameManager.ChangeSceneWithDelay(SceneType.CurrentLevel, 0.5f));
        }
    }

    void HandleDistanceUI(float dist)
    {
        if (dist < 10f)
        {
            metersRematiningTxt.text = dist.ToString("0.0") + " m";
        }
        else
        {
            metersRematiningTxt.text = dist.ToString("0") + " m";
        }

        float pct = dist / maxDist;
        progressBarSlider.value = 1 - pct;
    }

    void HandleNearTargetActions(float dist)
    {
        if (!ObjectiveLocation.Instance.AtLocation(transform.position))
        {
            sliderFillImage.color = sliderNormalColor;
            pressEBox.SetActive(false);
            return;
        }
        
        sliderFillImage.color = sliderHighlightColor;
        pressEBox.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            transition.FadeOut();
            StartCoroutine(GameManager.ChangeSceneWithDelay(SceneType.Diary, 0.5f));
        }
    }
}
