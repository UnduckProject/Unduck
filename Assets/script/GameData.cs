using UnityEngine;

public class GameData
{
    public static string LoadSceneName;
    public static int GameProgress = 0;
    public static int FirstFinalStage = 0;
    public static Vector3 FirstBossTransform;
    public static float FirstBossHP = 100;
    public static Vector3 DuckTransform;
    public static bool HasTalked1 = false;
    public static bool HasTalked2 = false;
    public static bool isBoss = false;
    public static bool NpcTarget = false;
    public static bool winMsg1 = false;
    public static bool winMsg2 = false;

    public static void ResetGameData()
    {
        LoadSceneName = string.Empty; 
        GameProgress = 0;
        FirstFinalStage = 0;
        FirstBossTransform = Vector3.zero;
        FirstBossHP = 100;
        DuckTransform = Vector3.zero;
        HasTalked1 = false;
        HasTalked2 = false;
        isBoss = false;
        NpcTarget = false;
        winMsg1 = false;
        winMsg2 = false;
    }
}
