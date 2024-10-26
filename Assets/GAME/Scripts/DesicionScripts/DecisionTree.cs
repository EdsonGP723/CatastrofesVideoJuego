using UnityEngine;

public class DecisionTree : MonoBehaviour
{
    public DecisionNode rootNode;

    public void InitializeTree(DecisionNode node)
    {
        rootNode = node;
    }

    void DisplayNode(DecisionNode node)
    {
        if (node == null)
        {
            Debug.LogError("El nodo actual es nulo.");
            return;
        }

        Debug.Log(node.decisionText);
        for (int i = 0; i < node.options.Count; i++)
        {
            Debug.Log($"{i + 1}: {node.options[i].decisionText}");
        }
    }

    public void MakeDecision(int optionIndex)
    {
        if (optionIndex < rootNode.options.Count)
        {
            DisplayNode(rootNode.options[optionIndex]);
            if (!string.IsNullOrEmpty(rootNode.options[optionIndex].consequence))
            {
                Debug.Log(rootNode.options[optionIndex].consequence);
            }
        }
        else
        {
            Debug.Log("Opción no válida");
        }
    }
}
