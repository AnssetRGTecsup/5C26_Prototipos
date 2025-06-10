using UnityEngine;

public class Performance
{
    private IStrategy strategy;
    private Member singer;

    public Performance(Member singerData)
    {
        singer = singerData;
    }

    public void SetStrategy(IStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void Perform()
    {
        if (strategy != null && singer != null)
            strategy.Execute(singer);
        else
            Debug.Log("Falta asignar estrategia o cantante.");
    }
    public Member GetSinger()
    {
        return singer;
    }
}
