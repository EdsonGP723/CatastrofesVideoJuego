using UnityEngine;

public class DecisionTree : MonoBehaviour
{
    public DecisionNode rootNode;
    public DecisionNode currentNode;

    public void InitializeTree(DecisionNode node)
    {
        rootNode = node;
        currentNode = node;
    }

    public void DisplayNode(DecisionNode node)
    {
        if (node == null)
        {
            Debug.LogError("El nodo actual es nulo.");
            return;
        }

        currentNode = node;

        Debug.Log(node.decisionText);
        for (int i = 0; i < node.options.Count; i++)
        {
            Debug.Log($"{i + 1}: {node.options[i].decisionText}");
        }
    }

    public void MakeDecision(int optionIndex)
    {
        if (optionIndex < currentNode.options.Count)
        {
            DecisionNode nextNode = currentNode.options[optionIndex];
            if (!string.IsNullOrEmpty(nextNode.consequence) && nextNode.options.Count == 0)
            {
                Debug.Log(nextNode.consequence);
            }
            else
            {
                UpdateDecisionText(optionIndex, "Esta opción ya ha sido elegida.");
                DisplayNode(nextNode);
            }
        }
        else
        {
            Debug.Log("Opción no válida");
        }
    }

    public void UpdateDecisionText(int optionIndex, string newText)
    {
        if (optionIndex < currentNode.options.Count)
        {
            currentNode.options[optionIndex].decisionText = newText;
        }
    }
}
