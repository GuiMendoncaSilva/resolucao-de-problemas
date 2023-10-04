using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalList : MonoBehaviour
{

    public static AnimalList Instance = null; 

    // Start is called before the first frame update
    [SerializeField] List<CharacterStats> animais = new List<CharacterStats>();
    private int selectedAnimalIndex;
    public int selectAnimalIndex{
        get {return selectedAnimalIndex;}
        set{
            if(value<0) {selectedAnimalIndex = animais.Count-1;}
            if(value>animais.Count-1){ selectedAnimalIndex = 0;}
            else {selectedAnimalIndex = value;}
            currentAnimal = animais[selectedAnimalIndex];
        }
    }

    public CharacterStats GetNext(){
        if (selectedAnimalIndex + 1 > animais.Count - 1)
        {
            selectAnimalIndex = 0;
            return animais[selectAnimalIndex];
        }
        else {
            selectAnimalIndex = selectAnimalIndex + 1;
            return (animais[selectAnimalIndex]); }
    }

    public CharacterStats GetPrevious(){
        if (selectedAnimalIndex - 1 < 0)
        {
            selectAnimalIndex = animais.Count - 1;
            return animais[selectAnimalIndex];
        }
        else {
            selectAnimalIndex = selectAnimalIndex - 1;
            return (animais[selectAnimalIndex]); }
    }

    internal CharacterStats currentAnimal;
    void Awake()
    {
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
