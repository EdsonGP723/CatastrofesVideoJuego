using System.Collections.Generic;
using UnityEngine;

public class DecisionTreeBuilder
{
    public static DecisionNode Earthquake()
    {
        DecisionNode rootNode = new DecisionNode("Comienza el sismo. ¿Te quedas en una columna o te metes debajo del escritorio de madera del profesor?");

        DecisionNode columnPath = new DecisionNode("Te quedas en una columna");
        DecisionNode deskPath = new DecisionNode("Te metes debajo del escritorio de madera del profesor");

        rootNode.options.Add(columnPath);
        rootNode.options.Add(deskPath);

        deskPath.consequence = "Te cae un pedazo de techo y te aplasta.";

        DecisionNode secondDecision = new DecisionNode("El sismo continúa. ¿Regresas por tu mochila o la dejas?");
        DecisionNode leaveBackpackPath = new DecisionNode("Dejar la mochila y seguir evacuando");
        DecisionNode retrieveBackpackPath = new DecisionNode("Regresas por la mochila");

        columnPath.options.Add(secondDecision);

        secondDecision.options.Add(leaveBackpackPath);
        secondDecision.options.Add(retrieveBackpackPath);

        retrieveBackpackPath.consequence = "Al regresar, el techo se desprende y te aplasta, pero con tu mochila en mano.";

        DecisionNode thirdDecision = new DecisionNode("Encuentras las escaleras y el elevador. ¿Cuál usas para evacuar?");
        DecisionNode elevatorPath = new DecisionNode("Usar el elevador");
        DecisionNode stairsPath = new DecisionNode("Usar las escaleras");

        leaveBackpackPath.options.Add(thirdDecision);

        thirdDecision.options.Add(elevatorPath);
        thirdDecision.options.Add(stairsPath);

        elevatorPath.consequence = "El sismo se intensifica y el elevador se desploma.";
        stairsPath.consequence = "Logras reunirte con tus compañeros en el punto de evacuación. ¡Sobreviviste al temblor!";

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
