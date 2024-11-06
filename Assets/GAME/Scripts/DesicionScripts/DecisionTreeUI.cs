using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DecisionTreeUI : MonoBehaviour
{
    public DecisionTree decisionTree;
    public TMP_Text decisionText;
    public Button[] optionButtons;

    void Start()
    {
        if (decisionTree == null)
        {
            Debug.LogError("DecisionTree no está asignado en el Inspector.");
            return;
        }

        if (decisionText == null)
        {
            Debug.LogError("DecisionText no está asignado en el Inspector.");
            return;
        }

        if (optionButtons == null || optionButtons.Length == 0)
        {
            Debug.LogError("OptionButtons no están asignados o el arreglo está vacío.");
            return;
        }

        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        DecisionNode rootNode = null;

        switch (sceneName)
        {
            case "Earthquake":
                rootNode = DecisionTreeBuilder.Earthquake();
                break;
            case "Fire":
                rootNode = DecisionTreeBuilder.Fire();
                break;
            case "Flood":
                rootNode = DecisionTreeBuilder.Flood();
                break;
            default:
                Debug.LogError("Escena no reconocida.");
                return;
        }

        decisionTree.InitializeTree(rootNode);
        DisplayNode(rootNode);
    }

    void DisplayNode(DecisionNode node)
    {
        decisionText.text = node.decisionText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < node.options.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = node.options[i].decisionText;
                int optionIndex = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void OnOptionSelected(int optionIndex)
    {
        decisionTree.MakeDecision(optionIndex);
        DisplayNode(decisionTree.currentNode);
    }
}
