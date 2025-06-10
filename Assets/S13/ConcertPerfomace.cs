using UnityEngine;

public class ConcertPerfomace : IStrategy
{
    public void Execute(Member singer, AudioSource audioSource)
    {
        Debug.Log($"{singer._name}, de edad: {singer._age} está usando su habilidad: {singer._ability} en un concierto 🔥");
        if (singer.voiceClip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = singer.voiceClip;
            audioSource.Play();
        }
    }
}
public class PracticePerformance : IStrategy
{
    public void Execute(Member singer, AudioSource audioSource)
    {
        Debug.Log($"{singer._name} está practicando con precisión 🕺");
        if (singer.voiceClip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = singer.voiceClip;
            audioSource.Play();
        }
    }
}

public class InterviewPerformance : IStrategy
{
    public void Execute(Member singer, AudioSource audioSource)
    {
        Debug.Log($"{singer._name} responde preguntas con carisma 🎤");
        if (singer.voiceClip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = singer.voiceClip;
            audioSource.Play();
        }
    }
}