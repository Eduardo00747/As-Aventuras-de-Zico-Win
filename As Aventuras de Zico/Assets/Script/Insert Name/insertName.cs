using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class insertName : MonoBehaviour
{
    public InputField nameInputField;
    public Button saveButton;
    public Text numberText;
    public GameObject finalScoreObject; // Refer�ncia ao GameObject que cont�m o FinalScore
    private FinalScore finalScoreComponent; // Refer�ncia ao componente FinalScore
    private string filePath;
    private ScoreData scoreData;

    void Start()
    {
        // Definir o caminho do arquivo JSON
        filePath = Path.Combine(Application.persistentDataPath, "ranking.json");

        // Obter o componente FinalScore do GameObject
        finalScoreComponent = finalScoreObject.GetComponent<FinalScore>();

        // Carregar os dados do ranking
        LoadScores();

        // Definir o n�mero armazenado
        int storedNumber = finalScoreComponent.GetPontuacao();
        Debug.Log("Pontua��o Armazenada: " + storedNumber);

        // Exibir o n�mero armazenado no Text
        numberText.text = "Pontua��o Armazenada: " + storedNumber;

        // Chamar o m�todo AskForName ap�s 5 segundos
        Invoke("AskForName", 5f);

        // Desativar o campo de entrada e o bot�o no in�cio
        nameInputField.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);

        // Adicionar um listener ao bot�o
        saveButton.onClick.AddListener(SaveScore);
    }

    void AskForName()
    {
        // Ativar o campo de entrada de texto e o bot�o para que o jogador insira o nome
        nameInputField.gameObject.SetActive(true);
        saveButton.gameObject.SetActive(true);
    }

    public void SaveScore()
    {
        string playerName = nameInputField.text;
        int playerScore = finalScoreComponent.GetPontuacao();

        // Adicionar a nova entrada no ranking
        scoreData.scores.Add(new ScoreEntry(playerName, playerScore));

        // Organizar o ranking em ordem decrescente
        scoreData.scores = scoreData.scores.OrderByDescending(entry => entry.score).ToList();

        // Converter a lista para JSON e salvar no arquivo
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filePath, json);

        Debug.Log("Score salvo para " + playerName);

        // Limpar o campo de entrada de texto e desativ�-lo
        nameInputField.text = "";
        nameInputField.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);
    }

    void LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
        else
        {
            Debug.LogError("Arquivo do ranking n�o encontrado. Criando um novo arquivo.");
            scoreData = new ScoreData();
            SaveScoreData();
        }
    }

    void SaveScoreData()
    {
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filePath, json);
    }
}

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}

[System.Serializable]
public class ScoreData
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}
