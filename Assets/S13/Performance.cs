using UnityEngine;
using UnityEngine.Audio;

public class Performance
{
    private IStrategy strategy;
    private Member singer;
    private AudioSource audioSourceP;


    public Performance(Member singerData, AudioSource audioSource)
    {
        singer = singerData;
        audioSourceP = audioSource;
    }

    public void SetStrategy(IStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void Perform()
    {
        if (strategy != null && singer != null)
            strategy.Execute(singer, audioSourceP);
        else
            Debug.Log("Falta asignar estrategia o cantante.");
    }
    public Member GetSinger()
    {
        return singer;
    }
}
