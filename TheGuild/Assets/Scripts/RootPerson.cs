using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPerson : Person
{
    public Sexuality sexuality;
    public Relationship relationship;
    public Wealth wealth;

    public RootPerson()
    {
        gender = Generators.RootGender();
        ageGroup = Generators.RootAgeGroup();
        age = Generators.Age(ageGroup);
        sexuality = Generators.RootSexuality(gender);
        wealth = Generators.RootWealth(ageGroup);

        if (sexuality == Sexuality.aroAce)
        {
            relationship = Relationship.single;
        }
        else
        {
            relationship = Generators.RootRelationship(wealth, ageGroup);
        }

        skinColor = Generators.RootSkinColor();
        hairColor = Generators.RootHairColor(skinColor);
        eyeColor = Generators.RootEyeColor(skinColor);
    }
}

public enum Wealth
{
    poor,
    middleClass,
    wealthy
};

public enum Sexuality
{
    straight,
    gay,
    bi,
    pan,
    aroAce
};

public enum Relationship
{
    single,
    dating,
    married
};
