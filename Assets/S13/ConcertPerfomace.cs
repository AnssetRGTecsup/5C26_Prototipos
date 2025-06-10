using UnityEngine;

public class ConcertPerfomace : IStrategy
{
    public void Execute(Member singer)
    {
        Debug.Log($"{singer._name}, de edad: {singer._age} está usando su habilidad: {singer._ability} en un concierto 🔥");
        AudioSource audioSource = new AudioSource();
        audioSource.Play();
    }
}
public class PracticePerformance : IStrategy
{
    public void Execute(Member singer)
    {
        Debug.Log($"{singer._name} está practicando con precisión 🕺");
        GameObject obj = new GameObject();
        obj.SetActive(true);
    }
}

public class InterviewPerformance : IStrategy
{
    public void Execute(Member singer)
    {
        Debug.Log($"{singer._name} responde preguntas con carisma 🎤");
    }
}