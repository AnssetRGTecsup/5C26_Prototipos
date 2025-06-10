using UnityEngine;

[CreateAssetMenu(fileName = "Member", menuName = "Scriptable Objects/Member")]
public class Member : ScriptableObject
{
   public string _name;
   public string _ability;
   public int _age;

    // cambios despues de las 12:30
    public AudioClip voiceClip;

}
