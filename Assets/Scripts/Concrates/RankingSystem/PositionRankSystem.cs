using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PositionRankSystem : MonoBehaviour
{
    [SerializeField] Text _rankText;

    List<GameObject> _allCharacters;

    Dictionary<string, GameObject> _characters = new Dictionary<string, GameObject>();

    void Awake()
    {  
        _allCharacters = GameObject.FindGameObjectsWithTag("Opponent").ToList();//Add All Characters In To The List
        _allCharacters.Add(GameObject.FindGameObjectWithTag("Player"));

        foreach (GameObject character in _allCharacters)//Save The Characters With Key And Value To The Dictionary
        {
            _characters.Add(character.transform.root.name, character);
        }
    }
    void Start()
    {
        StartCoroutine(SetRank());
    }
    IEnumerator SetRank()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            foreach (GameObject character in _allCharacters)
            {
                IOrderedEnumerable<KeyValuePair<string, GameObject>> ranking = _characters.OrderByDescending(x => x.Value.transform.root.position.z); //Descending Order According To All Characters Z Axis Value.

                int i = 0;
                foreach (KeyValuePair<string, GameObject> pair in ranking)
                {
                    if (pair.Value.CompareTag("Player"))
                    {
                        _rankText.text = $"{i + 1} / {_allCharacters.Count}";
                    }
                    i++;
                }
            }
        }
    }


}
