using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] PeopleFollowing = new GameObject[10];
    private int _noOfPeopleFollowing = 0;
    
    public void AddPerson(GameObject person)
    {
        for (int i = 0; i < PeopleFollowing.Length; i++)
        {
            if (PeopleFollowing[i] == null)
            {
                PeopleFollowing[i] = person;
                break;
            }
        }
        
        _noOfPeopleFollowing++;
    }
    
    public GameObject RemovePerson()
    {
        //Remove the first person in the list
        GameObject person = PeopleFollowing[0];
        
        for (int i = 0; i < PeopleFollowing.Length - 1; i++)
        {
            PeopleFollowing[i] = PeopleFollowing[i + 1];
        }
        _noOfPeopleFollowing--;
        return person;
    }
    
    
    public Vector3 getNewPersonOffset()
    {
        float x = _noOfPeopleFollowing%2 == 0 ? 0.5f : -0.5f;
        float y = - (_noOfPeopleFollowing + 1) / 5;
        
        return new Vector3(x, y, 0);

    }
    
    
    
}
