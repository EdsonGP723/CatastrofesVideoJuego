using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DecisionTreeUI : MonoBehaviour
{
    public DecisionTree decisionTree;
    public TMP_Text decisionText;
    public Button[] optionButtons;
    private DecisionNode currentNode;

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

        // Cambiar  desiciones según la escena que se cargue
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
        currentNode = node;

        if (currentNode == null)
        {
            Debug.LogError("El nodo actual es nulo.");
            return;
        }

        decisionText.text = currentNode.decisionText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentNode.options.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = currentNode.options[i].decisionText;
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
        if (optionIndex < currentNode.options.Count)
        {
            DecisionNode nextNode = currentNode.options[optionIndex];
            DisplayNode(nextNode);

            if (!string.IsNullOrEmpty(nextNode.consequence))
            {
                Debug.Log(nextNode.consequence);
                decisionText.text = nextNode.consequence;
            }
        }
    }
}
