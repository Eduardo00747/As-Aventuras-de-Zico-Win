using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ranking : MonoBehaviour
{
    public GameObject entryPrefab;
    public Transform entryParent;

    private string filePath;
    private ScoreData scoreData;

    void Start()
    {
        // Definir o caminho do arquivo JSON
        filePath = Path.Combine(Application.persistentDataPath, "ranking.json");

        // Carregar os dados do ranking
        LoadScores();

        // Exibir os 10 primeiros no ranking
        DisplayTopScores();
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
            Debug.LogError("Arquivo do ranking não encontrado. Criando um novo arquivo.");
            scoreData = new ScoreData();
            SaveScoreData();
        }
    }

    void SaveScoreData()
    {
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filePath, json);
    }

    void DisplayTopScores()
    {
        foreach (Transform child in entryParent)
        {
            Destroy(child.gameObject);
        }

        var topScores = scoreData.scores.OrderByDescending(entry => entry.score).Take(10).ToList();
        foreach (var scoreEntry in topScores)
        {
            GameObject entry = Instantiate(entryPrefab, entryParent);
            TMP_Text[] texts = entry.GetComponentsInChildren<TMP_Text>();
            texts[0].text = scoreEntry.playerName;
            texts[1].text = scoreEntry.score.ToString();
        }
    }
}
