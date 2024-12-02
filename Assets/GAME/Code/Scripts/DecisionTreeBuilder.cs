using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class DecisionTreeBuilder : MonoBehaviour
{
    public DecisionUI decisionUI;
    public DecisionTimer decisionTimer; // Referencia al temporizador
    public GameObject[] correctPlayableObjects;
    public GameObject[] incorrectPlayableObjects;
    public GameObject[] intermediatePlayableObjects; // Animaciones intermedias
    public GameObject winPanel, gameOverPanel;
    private int currentRound = 0; // Empezamos en la ronda 0
    private string sceneName;
    private int previousIntermediateRound = -1; // Para rastrear la animación intermedia anterior
    private int previousCorrectRound = -1; // Para rastrear la animación buena anterior

    void Start()
    {
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        decisionUI.onDecisionMade += HandleDecision;
        decisionTimer.onTimerEnd += OnTimerEnd; // Suscribir al evento de finalización del temporizador
        StartRound();
    }

    void StartRound()
    {
        HideAllPlayables();
        decisionUI.ShowUI(false); // Asegurar que la UI esté oculta al empezar una nueva ronda
        decisionTimer.ShowTimer(false); // Ocultar el temporizador al empezar una nueva ronda
        PlayIntermediateAnimation(); // Reproducir animación intermedia antes de mostrar las decisiones
    }

    void HideAllPlayables()
    {
        foreach (var obj in correctPlayableObjects)
        {
            obj.SetActive(false);
        }
        foreach (var obj in incorrectPlayableObjects)
        {
            obj.SetActive(false);
        }
        foreach (var obj in intermediatePlayableObjects)
        {
            obj.SetActive(false);
        }
    }

    void SetupRoundEscena1()
    {
        switch (currentRound)
        {
            case 0:
                SetRandomQuestion("Comienza el sismo. ¿Te quedas en una columna o te metes debajo del escritorio de madera del profesor?", "Te quedas en una columna", "Te metes debajo del escritorio de madera del profesor");
                break;
            case 1:
                SetRandomQuestion("El sismo continúa. ¿Regresas por tu mochila o la dejas?", "Dejar la mochila y seguir evacuando", "Regresas por la mochila");
                break;
            case 2:
                SetRandomQuestion("Encuentras las escaleras y el elevador. ¿Cuál usas para evacuar?", "Usar las escaleras", "Usar el elevador");
                break;
            default:
                decisionUI.SetQuestion("¡Has ganado!");
                decisionUI.ShowUI(true); // Mostrar la UI al ganar el juego
                decisionTimer.ShowTimer(false); // Ocultar el temporizador al ganar el juego
                StartCoroutine(WaitForOneSecond());
                winPanel.SetActive(true);
                break;
        }
    }

    void SetupRoundEscena2()
    {
        // Configurar preguntas y opciones para Escena 2
    }

    void SetupRoundEscena3()
    {
        // Configurar preguntas y opciones para Escena 3
    }

    void SetRandomQuestion(string question, string correctOption, string incorrectOption)
    {
        decisionUI.SetQuestion(question);

        if (Random.Range(0, 2) == 0)
        {
            decisionUI.SetButtonText(correctOption, incorrectOption);
            decisionUI.SetCorrectButton(true); // A es correcta
        }
        else
        {
            decisionUI.SetButtonText(incorrectOption, correctOption);
            decisionUI.SetCorrectButton(false); // B es correcta
        }

        decisionUI.ShowUI(true); // Mostrar la UI con los textos actualizados durante la animación intermedia
        decisionTimer.StartTimer(); // Iniciar el temporizador
    }

    void HandleDecision(bool isCorrect)
    {
        PlayableDirector director;

        decisionUI.ShowUI(false); // Ocultar la UI al comenzar cualquier animación
        decisionTimer.StopTimer(); // Detener el temporizador

        // Desactivar la animación intermedia actual si está activa
        if (previousIntermediateRound >= 0)
        {
            intermediatePlayableObjects[previousIntermediateRound].SetActive(false);
        }

        if (isCorrect)
        {
            if (previousCorrectRound >= 0)
            {
                correctPlayableObjects[previousCorrectRound].SetActive(false); // Desactivar la animación buena anterior
            }

            correctPlayableObjects[currentRound].SetActive(true);
            director = correctPlayableObjects[currentRound].GetComponent<PlayableDirector>();
            director.stopped += OnCorrectPlayableDirectorStopped;
            director.Play();
            previousCorrectRound = currentRound; // Actualizar el índice de la animación buena anterior
        }
        else
        {
            incorrectPlayableObjects[currentRound].SetActive(true);
            director = incorrectPlayableObjects[currentRound].GetComponent<PlayableDirector>();
            director.stopped += OnIncorrectPlayableDirectorStopped;
            director.Play();
        }
    }

    void PlayIntermediateAnimation()
    {
        if (previousIntermediateRound >= 0)
        {
            intermediatePlayableObjects[previousIntermediateRound].SetActive(false); // Desactivar la animación intermedia anterior
        }

        if (currentRound < intermediatePlayableObjects.Length)
        {
            intermediatePlayableObjects[currentRound].SetActive(true);
            var director = intermediatePlayableObjects[currentRound].GetComponent<PlayableDirector>();
            director.stopped += OnIntermediatePlayableDirectorStopped;
            previousIntermediateRound = currentRound;
            director.Play();
        }
        else
        {
            previousIntermediateRound = -1;
            ShowRoundChoices();
        }
    }

    void ShowRoundChoices()
    {
        switch (sceneName)
        {
            case "Earthquake":
                SetupRoundEscena1();
                break;
            case "Escena2":
                SetupRoundEscena2();
                break;
            case "Escena3":
                SetupRoundEscena3();
                break;
        }
    }

    void OnCorrectPlayableDirectorStopped(PlayableDirector director)
    {
        currentRound++; // Avanzar a la siguiente ronda
        PlayIntermediateAnimation(); // Reproducir la siguiente animación intermedia
    }

    void OnIntermediatePlayableDirectorStopped(PlayableDirector director)
    {
        decisionUI.ShowUI(true); // Mostrar la UI después de la animación intermedia
        decisionTimer.StartTimer(); // Iniciar el temporizador
        decisionTimer.ShowTimer(true); // Mostrar el temporizador
        ShowRoundChoices(); // Mostrar las decisiones de la ronda siguiente
    }

    void OnIncorrectPlayableDirectorStopped(PlayableDirector director)
    {
        decisionUI.SetQuestion("Respuesta incorrecta. Fin del juego.");
        decisionUI.ShowQuestion(true); // Mostrar solo el texto al final de la animación incorrecta
        decisionUI.ShowButtons(false); // Asegurar que los botones no estén visibles
        decisionTimer.ShowTimer(false); // Ocultar el temporizador
        StartCoroutine(WaitForOneSecond());
        gameOverPanel.SetActive(true);

    }

    void OnTimerEnd()
    {
        // Ejecutar automáticamente la decisión incorrecta cuando el temporizador llegue a 0
        HandleDecision(false);
    }

    private IEnumerator WaitForOneSecond() 
    { 
        yield return new WaitForSeconds(3f); 
        
    }
    
}
