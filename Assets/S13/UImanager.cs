using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class UImanager : MonoBehaviour
{
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private List<Member> singers;

    private Performance currentPerformance;
    void Start()
    {
        for (int i = 0; i < singers.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.GetComponentInChildren<TMP_Text>().text = singers[i]._name;
            Member singerCopy = singers[i];
            newButton.GetComponent<Button>().onClick.AddListener(() => SelectSinger(singerCopy));
        }
    }
    public void SelectSinger(Member singer)
    {
        currentPerformance = new Performance(singer);
        Debug.Log($"Seleccionado: {singer._name}");
    }

    public void SetConcertStrategy()
    {
        if (currentPerformance != null)
        {
            currentPerformance.SetStrategy(new ConcertPerfomace());
            currentPerformance.Perform();
        }
    }
    public void SetPracticeStrategy()
    {
        if (currentPerformance != null)
        {
            currentPerformance.SetStrategy(new PracticePerformance());
            currentPerformance.Perform();
        }
    }
    public void SetInterviewStrategy()
    {
        if (currentPerformance != null)
        {
            currentPerformance.SetStrategy(new InterviewPerformance());
            currentPerformance.Perform();
        }
    }
}