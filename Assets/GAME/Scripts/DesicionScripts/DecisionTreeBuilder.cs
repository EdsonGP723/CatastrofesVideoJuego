using System.Collections.Generic;
using UnityEngine;

public class DecisionTreeBuilder
{
    public static DecisionNode Earthquake()
    {
        // Crear nodos específicos para la escena del terremoto
        DecisionNode rootNode = new DecisionNode("¿Quieres tomar el camino de la izquierda o de la derecha?");
        DecisionNode leftPath = new DecisionNode("Has elegido el camino de la izquierda.");
        DecisionNode rightPath = new DecisionNode("Has elegido el camino de la derecha.");
        
        rootNode.options.Add(leftPath);
        rootNode.options.Add(rightPath);

        // Primera ronda
        rightPath.consequence = "El camino está bloqueado por un árbol caído. Fin del juego.";

        DecisionNode secondDecision = new DecisionNode("Encuentras un río. ¿Cruzar o rodear?");
        leftPath.options.Add(secondDecision);

        // Segunda ronda
        DecisionNode thirdDecision = new DecisionNode("Encuentras un puente. ¿Cruzar o buscar otra ruta?");
        DecisionNode wrongSecondDecision = new DecisionNode("El río estaba infestado de cocodrilos. Fin del juego.");
        secondDecision.options.Add(thirdDecision);
        secondDecision.options.Add(wrongSecondDecision);

        // Tercera ronda
        DecisionNode finalDecision = new DecisionNode("Encuentras un tesoro. ¿Tomar o dejar?");
        DecisionNode wrongThirdDecision = new DecisionNode("El puente se derrumbó. Fin del juego.");
        thirdDecision.options.Add(finalDecision);
        thirdDecision.options.Add(wrongThirdDecision);

        // Consecuencia final correcta
        finalDecision.consequence = "Tomaste el tesoro sin problemas y ganaste. Fin del juego.";

        return rootNode;
    }

    public static DecisionNode Fire()
    {
        // Crear nodos específicos para la escena del incendio
        DecisionNode rootNode = new DecisionNode("¿Quieres ir hacia la duna o hacia el oasis?");
        DecisionNode dunePath = new DecisionNode("Has elegido ir hacia la duna.");
        DecisionNode oasisPath = new DecisionNode("Has elegido ir hacia el oasis.");
        
        rootNode.options.Add(dunePath);
        rootNode.options.Add(oasisPath);

        // Primera ronda
        dunePath.consequence = "La duna es muy alta y te cansas. Fin del juego.";

        DecisionNode secondDecision = new DecisionNode("Encuentras un caravanero. ¿Hablar o evitar?");
        oasisPath.options.Add(secondDecision);

        // Segunda ronda
        DecisionNode thirdDecision = new DecisionNode("Encuentras un campamento. ¿Descansar o seguir?");
        DecisionNode wrongSecondDecision = new DecisionNode("El caravanero era un impostor. Fin del juego.");
        secondDecision.options.Add(thirdDecision);
        secondDecision.options.Add(wrongSecondDecision);

        // Tercera ronda
        DecisionNode finalDecision = new DecisionNode("Encuentras un mapa. ¿Seguir o descartar?");
        DecisionNode wrongThirdDecision = new DecisionNode("El campamento está abandonado. Fin del juego.");
        thirdDecision.options.Add(finalDecision);
        thirdDecision.options.Add(wrongThirdDecision);

        // Consecuencia final correcta
        finalDecision.consequence = "Seguiste el mapa y encontraste un oasis. Fin del juego.";

        return rootNode;
    }

    public static DecisionNode Flood()
    {
        // Crear nodos específicos para la escena de la inundación
        DecisionNode rootNode = new DecisionNode("¿Quieres ir hacia el parque o hacia el centro comercial?");
        DecisionNode parkPath = new DecisionNode("Has elegido ir hacia el parque.");
        DecisionNode mallPath = new DecisionNode("Has elegido ir hacia el centro comercial.");
        
        rootNode.options.Add(parkPath);
        rootNode.options.Add(mallPath);

        // Primera ronda
        mallPath.consequence = "El centro comercial está cerrado. Fin del juego.";

        DecisionNode secondDecision = new DecisionNode("Encuentras una feria. ¿Participar o ignorar?");
        parkPath.options.Add(secondDecision);

        // Segunda ronda
        DecisionNode thirdDecision = new DecisionNode("Encuentras un túnel. ¿Entrar o evitar?");
        DecisionNode wrongSecondDecision = new DecisionNode("La feria estaba desierta. Fin del juego.");
        secondDecision.options.Add(thirdDecision);
        secondDecision.options.Add(wrongSecondDecision);

        // Tercera ronda
        DecisionNode finalDecision = new DecisionNode("Encuentras una balsa. ¿Usar o dejar?");
        DecisionNode wrongThirdDecision = new DecisionNode("El túnel estaba inundado. Fin del juego.");
        thirdDecision.options.Add(finalDecision);
        thirdDecision.options.Add(wrongThirdDecision);

        // Consecuencia final correcta
        finalDecision.consequence = "Usaste la balsa y llegaste a un lugar seguro. Fin del juego.";

        return rootNode;
    }
}
