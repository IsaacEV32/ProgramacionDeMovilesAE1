using System.IO;
using UnityEngine;

public class SaveSystemAndroid : SaveSystem
{
    public override void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "AndroidSavefile.json");
        if (File.Exists(savePath))
        {
            data = JsonUtility.FromJson<SaveSystemData>(File.ReadAllText(savePath));
        }
        else
        {
            data = new SaveSystemData();
        }
        base.Awake();
    }
    public override void Save()
    {
        data.maxScore = HUD.instance.hudBehavior.GetMaxScore();

        string jsonInventory = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonInventory);

    }
    public override bool HasSaved()
    {
        if (File.Exists(savePath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void Load()
    {
        if (HasSaved())
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, data);

            HUD.instance.hudBehavior.SetData(data);
        }
    }
}
