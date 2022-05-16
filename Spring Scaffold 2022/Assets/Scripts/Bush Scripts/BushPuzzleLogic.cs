using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushPuzzleLogic : MonoBehaviour
{
    [SerializeField] private GameObject Bush1;
    [SerializeField] private GameObject Bush2;
    [SerializeField] private GameObject Bush3;
    [SerializeField] private GameObject Bush4;
    [SerializeField] private GameObject acorn;
    private int detectedBushIndex;
    private bool[] ActiveBushes = new bool[] {true, true, true, true};

    bool correct;

    // Start is called before the first frame update
    void Start()
    {
        acorn.SetActive(false);
        correct = true;
    }

    public void UpdateBush(ref GameObject bush)
    {
        if (Bush1 == bush)
        {
            detectedBushIndex = 0;
        }
        else if (Bush2 == bush)
        {
            detectedBushIndex = 1;
        }
        else if (Bush3 == bush)
        {
            detectedBushIndex = 2;
        }
        else if (Bush4 == bush)
        {
            detectedBushIndex = 3;
        }
        
        ActiveBushes[detectedBushIndex] = false;
        checkCorrectness(detectedBushIndex);
        Debug.Log(correct);
        bush.GetComponent<Bush>().UnravelBush();

        printActiveBushes();
        if(allBushesDeactivated())
        {
            Debug.Log("All bushes are deactivated.");
            if (correct)
            {

                StartCoroutine(spawnAcorn());
            }
            else
            {
                Debug.Log("Resetting Bushes");
                StartCoroutine(resetBushes());
            }
        }
    }

    bool allBushesDeactivated()
    {
        bool allAreDeactivated = true;

        for (int i = 0; i < 4; i++)
        {
            if (ActiveBushes[i])
            {
                allAreDeactivated = false;
            }
        }

        return allAreDeactivated;
    }

    void checkCorrectness(int deletedBushIndex)
    {
        if(!correct)
        {
            return;
        }
        

        for(int i = 0; i < deletedBushIndex; i++)
        {
            if (ActiveBushes[i] == true)
            {
                correct = false;
                return;
            }
        }    
    }

    IEnumerator resetBushes()
    {
        correct = true;
        for (int i = 0; i < 4; i++)
        {
            ActiveBushes[i] = true;
        }
        yield return new WaitForSeconds(1);
        Bush1.GetComponent<Bush>().RespawnBush();
        Bush2.GetComponent<Bush>().RespawnBush();
        Bush3.GetComponent<Bush>().RespawnBush();
        Bush4.GetComponent<Bush>().RespawnBush();
    }

    IEnumerator spawnAcorn()
    {
        yield return new WaitForSeconds(0.5f);
        acorn.SetActive(true);
    }

    void printActiveBushes()
    {
        string d = "[";
        for(int i = 0; i < 4; i++)
        {
            if (ActiveBushes[i])
            {
                d += "1";
            }
            else
            {
                d += "0";
            }
        }
        d += "]";
        Debug.Log(d);
    }
}
