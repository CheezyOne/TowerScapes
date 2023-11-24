using UnityEngine;
public class DataHolder : MonoBehaviour
{
    public static DataHolder Inst = new DataHolder();
    public bool[] SelectedToUseCube =new bool [10];
    public int theAmountOfNotSelectedCubes = 0;
    public bool[] theGameDifficylty = new bool[4];
    public bool firstTimeChangedDifficulty = true;
    public int[] DifferentDifficultiesScore = new int[8];
    public bool theDifficultyHasBennChanged = false;
    public bool[] PlayingMode = new bool[2];
    public bool OpenOptions=false;
    //DataHolder.Inst.array1[0]=true;
}
