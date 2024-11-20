using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DecisionUI : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button optionAButton;
    public Button optionBButton;
    public TextMeshProUGUI optionAText;
    public TextMeshProUGUI optionBText;
    public Action<bool> onDecisionMade;
    private bool isAButtonCorrect;

    void Start()
    {
        optionAButton.onClick.AddListener(() => onDecisionMade?.Invoke(isAButtonCorrect));
        optionBButton.onClick.AddListener(() => onDecisionMade?.Invoke(!isAButtonCorrect));
    }

    public void SetQuestion(string question)
    {
        questionText.text = question;
    }

    public void SetButtonText(string optionAText, string optionBText)
    {
        this.optionAText.text = optionAText;
        this.optionBText.text = optionBText;
    }

    public void SetCorrectButton(bool isAButtonCorrect)
    {
        this.isAButtonCorrect = isAButtonCorrect;
    }

    public void ShowButtons(bool show)
    {
        optionAButton.gameObject.SetActive(show);
        optionBButton.gameObject.SetActive(show);
    }

    public void ShowQuestion(bool show)
    {
        questionText.gameObject.SetActive(show);
    }

    public void ShowUI(bool show)
    {
        ShowQuestion(show);
        ShowButtons(show);
    }
}
