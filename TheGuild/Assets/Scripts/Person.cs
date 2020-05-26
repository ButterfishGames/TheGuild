using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public PersonType personType;

    public int age;
    public AgeGroup ageGroup;
    public Gender gender;

    public SkinColor skinColor;
    public HairColor hairColor;
    public EyeColor eyeColor;

    public Person()
    {
        personType = PersonType.root;
    }

    public Person (PersonType type, RootPerson root)
    {
        personType = type;

        switch(type)
        {
            case PersonType.partner:
                GenPartner(root);
                break;

            case PersonType.roommate:
                GenRoommate(root);
                break;

            case PersonType.child:
                Debug.LogError("Used non-child constructor to initialize child");
                break;

            default:
                Debug.LogError("Invalid person type");
                break;
        }
    }

    public Person(PersonType type, RootPerson root, int remainingChildren)
    {
        if (type == PersonType.child)
        {
            personType = type;
            GenChild(root, remainingChildren);
        }
        else
        {
            Debug.LogError("Used chlid constructor for non-child");
        }
    }

    public Person(PersonType type, RootPerson parent1, Person parent2, int remainingChildren)
    {
        if (type == PersonType.child)
        {
            personType = type;
            GenChild(parent1, parent2, remainingChildren);
        }
        else
        {
            Debug.LogError("Used child constructor for non-child");
        }
    }

    private void GenPartner(RootPerson root)
    {
        gender = Generators.PartnerGender(root);
        ageGroup = Generators.PartnerAgeGroup(root);
        age = Generators.Age(ageGroup);

        skinColor = Generators.PartnerSkinColor(root);
        hairColor = Generators.RootHairColor(skinColor);
        eyeColor = Generators.RootEyeColor(skinColor);
    }

    private void GenChild(RootPerson root, int remainingChildren)
    {
        gender = Generators.ChildGender(root);
        age = Generators.ChildAge(root, remainingChildren);

        float det = Random.Range(0.0f, 1.0f);
        if (det <= 2.0f/3.0f)
        {
            skinColor = Generators.ChildSkinColor(root);
            hairColor = Generators.ChildHairColor(root);
            eyeColor = Generators.ChildEyeColor(root);
        }
        else
        {
            skinColor = Generators.RootSkinColor();
            hairColor = Generators.RootHairColor(skinColor);
            eyeColor = Generators.RootEyeColor(skinColor);
        }
    }

    private void GenChild(RootPerson parent1, Person parent2, int remainingChildren)
    {
        gender = Generators.ChildGender(parent1, parent2);
        age = Generators.ChildAge(parent1, parent2, remainingChildren);

        float det = Random.Range(0.0f, 1.0f);
        if (GenerationHelpers.SABMatch(parent1, parent2) || det <= 0.1f)
        {
            skinColor = Generators.RootSkinColor();
            hairColor = Generators.RootHairColor(skinColor);
            eyeColor = Generators.RootEyeColor(skinColor);
        }
        else
        {

        }
    }
}

public enum PersonType
{
    root,
    partner,
    roommate,
    child
};

public enum AgeGroup
{
    youngAdult,
    adult,
    middleAged,
    senior,
    child
}

public enum Gender
{
    cisMale,
    cisFemale,
    transMale,
    transFemale,
    dmabNonBinary,
    dfabNonBinary,
};

public enum SkinColor
{
    black,
    brown,
    yellow,
    white
};

public enum HairColor
{
    black,
    brown,
    blonde,
    red
};

public enum EyeColor
{
    brown,
    blue,
    green
};
