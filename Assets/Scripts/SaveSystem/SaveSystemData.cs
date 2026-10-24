using System;
using UnityEngine;
[Serializable]
public class SaveSystemData
{
    public int maxScore;
}
public interface ISaveSystem
{
    void Save();
    bool HasSaved();
    void Load();
}
