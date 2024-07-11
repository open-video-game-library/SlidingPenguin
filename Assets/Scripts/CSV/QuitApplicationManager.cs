using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplicationManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        GameDataExport.SaveCSV(ExportData.ScoreData);
        GameDataExport.SaveCSV(ExportData.TrailData);
    }
}
