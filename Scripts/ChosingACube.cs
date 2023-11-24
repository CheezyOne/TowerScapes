using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosingACube : MonoBehaviour
{
    private bool Cube1Selected, Cube2Selected, Cube3Selected, Cube4Selected, Cube5Selected, Cube6Selected, Cube7Selected, Cube8Selected, Cube9Selected, Cube10Selected;
    private List<GameObject> ChosenCubes = new List<GameObject>();
    private MeshRenderer meshrendererCube,temporaryMeshRenderer;
    private int AmountOfUnlockedCubes;
    public Material GreyMaterial;
    public Material NormalMaterial;
    public Material HelpingNormalMaterial;
    public GameObject target;
    public GameObject theCubeItself;
    void Start()
    {
        howMuchIsOurBest();
        meshrendererCube = target.GetComponent<MeshRenderer>();
        NormalMaterial = meshrendererCube.material;
        GreyMaterial.mainTextureScale = NormalMaterial.mainTextureScale;
        SettingAllSelectedCubes();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
#if !UNITY_EDITOR
            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;
#endif
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Cube")
                    {
                        target = hit.transform.gameObject;
                        if (target == theCubeItself)
                        {
                            Iffer();
                            target = null;
                        }
                    }
                }
            }
        }
    }
    private void SettingAllSelectedCubes()
    {
        if (DataHolder.Inst.SelectedToUseCube[0] == true)
        {
            GameObject.Find("Main cube").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[1] == true)
        {
            GameObject.Find("Cube 2").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[2] == true )
        {
            GameObject.Find("Cube 3").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[3] == true)
        {
            GameObject.Find("Cube 4").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[4] == true )
        {
            GameObject.Find("Cube 5").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[5] == true )
        {
            GameObject.Find("Cube 6").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[6] == true )
        {
            GameObject.Find("Cube 7").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[7] == true )
        {
            GameObject.Find("Cube 8").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[8] == true )
        {
            GameObject.Find("Cube 9").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
        if (DataHolder.Inst.SelectedToUseCube[9] == true)
        {
            GameObject.Find("Cube 10").GetComponent<MeshRenderer>().material = GreyMaterial;
        }
    }
    private void Iffer()
    {
        if (target.name == ("Main cube") && PlayerPrefs.GetInt("score") > 0 )
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial == GreyMaterial)
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[0] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
                return;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes< AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[0] = true;
                return;
            }
        }
        else if (target.name == ("Cube 2") && PlayerPrefs.GetInt("score") > 4)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[1] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[1] = true;
            }
        }
        else if (target.name == ("Cube 3") && PlayerPrefs.GetInt("score") > 9)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[2] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[2] = true;
            }
        }
        else if (target.name == ("Cube 4") && PlayerPrefs.GetInt("score") > 14)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[3] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[3] = true;
            }
        }
        else if (target.name == ("Cube 5") && PlayerPrefs.GetInt("score") > 20)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[4] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[4] = true;
            }
        }
        else if (target.name == ("Cube 6") && PlayerPrefs.GetInt("score") > 24)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[5] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[5] = true;
            }
        }
        else if (target.name == ("Cube 7") && PlayerPrefs.GetInt("score") > 34)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[6] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[6] = true;
            }
        }
        else if (target.name == ("Cube 8") && PlayerPrefs.GetInt("score") > 49)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[7] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[7] = true;
            }
        }
        else if (target.name == ("Cube 9") && PlayerPrefs.GetInt("score") > 74)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.SelectedToUseCube[8] = false;
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes - 1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[8] = true;
            }
        }
        else if (target.name == ("Cube 10") && PlayerPrefs.GetInt("score") > 99)
        {
            if (meshrendererCube.material == meshrendererCube.material.name.StartsWith(GreyMaterial.name))
            {
                if (NormalMaterial.name.StartsWith(GreyMaterial.name))
                {
                    meshrendererCube.material = HelpingNormalMaterial;
                }
                else
                {
                    meshrendererCube.material = NormalMaterial;
                }
                DataHolder.Inst.theAmountOfNotSelectedCubes--;
                DataHolder.Inst.SelectedToUseCube[9] = false;
            }
            else if (DataHolder.Inst.theAmountOfNotSelectedCubes < AmountOfUnlockedCubes-1)
            {
                DataHolder.Inst.theAmountOfNotSelectedCubes++;
                meshrendererCube.material = GreyMaterial;
                DataHolder.Inst.SelectedToUseCube[9] = true;
            }
        }
    }
    private void howMuchIsOurBest()
    {
        if (PlayerPrefs.GetInt("score") < 5)
            AmountOfUnlockedCubes = 1;
        else if (PlayerPrefs.GetInt("score") < 10)
            AmountOfUnlockedCubes = 2;
        else if(PlayerPrefs.GetInt("score") < 15)
            AmountOfUnlockedCubes = 3;
        else if(PlayerPrefs.GetInt("score") < 20)
            AmountOfUnlockedCubes = 4;
        else if(PlayerPrefs.GetInt("score") < 25)
            AmountOfUnlockedCubes = 5;
        else if(PlayerPrefs.GetInt("score") < 35)
            AmountOfUnlockedCubes = 6;
        else if(PlayerPrefs.GetInt("score") < 50)
            AmountOfUnlockedCubes = 7;
        else if(PlayerPrefs.GetInt("score") < 75)
            AmountOfUnlockedCubes = 8;
        else if(PlayerPrefs.GetInt("score") < 100)
            AmountOfUnlockedCubes = 9;
        else AmountOfUnlockedCubes = 10;
    }
}
