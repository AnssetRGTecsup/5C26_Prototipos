using UnityEngine;

public class test : MonoBehaviour
{
    public Member felixSO;

    void Start()
    {
        Performance performance = new Performance(felixSO);

        //performance.SetStrategy(new PracticePerformance());
        //performance.Perform();

        //performance.SetStrategy(new InterviewPerformance());
        //performance.Perform();

        performance.SetStrategy(new ConcertPerfomace());
        performance.Perform();
    }
}
