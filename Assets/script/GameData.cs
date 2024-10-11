using UnityEngine;

public class GameData
{
    public static string LoadSceneName;
    public static int GameProgress = 0;
    public static int FirstFinalStage = 0;
    public static Vector3 FirstBossTransform;
    public static float FirstBossHP = 100;
    public static float FirstPlayerHP=100;
    public static Vector3 DuckTransform;
    public static Vector3 BeforeDuckTransform = new Vector3(-41.0f, 20.0f, -14.0f);
    public static bool HasTalked1 = false;
    public static bool HasTalked2 = false;
    public static bool HasTalked3 = false;
    public static bool HasTalked4 = false;
    public static bool HasTalked5 = false;
    public static bool isBoss = false;
    public static bool NpcTarget = false;
    public static bool winMsg1 = false;
    public static bool winMsg2 = false;
    public static bool winMsg3 = false;
    public static bool winMsg4 = false;
    public static bool winMsgOn = false;
    public static bool GameEND = false;
    public static bool Win = false;
    public static bool returnTo=false;
    public static bool minigameOn=false;
    public static int Winprogress =0;
    public static bool FirstStage = true;
    public static bool duckwan=false;
    public static bool Demo=false;

    public static void ResetGameData()
    {
        LoadSceneName = string.Empty; 
        GameProgress = 0;
        duckwan=false;
        FirstFinalStage = 0;
        FirstBossTransform = Vector3.zero;
        FirstBossHP = 100;
        FirstPlayerHP=100;
        DuckTransform = Vector3.zero;
        BeforeDuckTransform = Vector3.zero;
        HasTalked1 = false;
        HasTalked2 = false;
        HasTalked3 = false;
        HasTalked4 = false;
        HasTalked5 = false;
        isBoss = false;
        NpcTarget = false;
        winMsg1 = false;
        winMsg2 = false;
        returnTo=false;
        winMsgOn = false;
        minigameOn=false;
        Winprogress =0;
        Win = false;
        FirstStage = true;
        Demo=false;
    }
}
