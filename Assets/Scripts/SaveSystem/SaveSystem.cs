using UnityEngine;

public class SaveSystem : MonoBehaviour, ISaveSystem
{
    protected SaveSystemData data;
    protected static string savePath;
    public virtual void Awake()
    {

    }

    public virtual void Save()
    {

    }
    public virtual bool HasSaved()
    {
        return true;
    }
    public virtual void Load()
    {

    }
}
