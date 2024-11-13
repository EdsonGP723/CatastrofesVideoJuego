using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecisionNode
{
    public string decisionText;
    public List<DecisionNode> options;
    public string consequence;

    public DecisionNode(string decisionText)
    {
        this.decisionText = decisionText;
        options = new List<DecisionNode>();
    }
}
