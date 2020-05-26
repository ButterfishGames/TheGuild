using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generators
{
    private static int remainingTwins = 0;
    private static int prevAge;

    public static Gender RootGender()
    {
        float det = Random.Range(0.0f, 1.0f);
        if (det <= 0.47f)
        {
            return Gender.cisMale;
        }
        else if (det <= 0.94f)
        {
            return Gender.cisFemale;
        }
        else if (det <= 0.96f)
        {
            return Gender.transMale;
        }
        else if (det <= 0.98f)
        {
            return Gender.transFemale;
        }
        else if (det <= 0.99f)
        {
            return Gender.dmabNonBinary;
        }
        else
        {
            return Gender.dfabNonBinary;
        }
    }
    public static Gender PartnerGender(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);

        switch (root.sexuality)
        {
            case Sexuality.straight:
                switch (root.gender)
                {
                    case Gender.cisMale:
                        if (det <= 0.98f)
                        {
                            return Gender.cisFemale;
                        }
                        else
                        {
                            return Gender.transFemale;
                        }

                    case Gender.cisFemale:
                        if (det <= 0.98f)
                        {
                            return Gender.cisMale;
                        }
                        else
                        {
                            return Gender.transMale;
                        }

                    case Gender.transMale:
                        if (det <= 0.9f)
                        {
                            return Gender.cisFemale;
                        }
                        else
                        {
                            return Gender.transFemale;
                        }

                    case Gender.transFemale:
                        if (det <= 0.9f)
                        {
                            return Gender.cisMale;
                        }
                        else
                        {
                            return Gender.transMale;
                        }
                }
                break;

            case Sexuality.gay:
                switch (root.gender)
                {
                    case Gender.cisMale:
                        if (det <= 0.95f)
                        {
                            return Gender.cisMale;
                        }
                        else
                        {
                            return Gender.transMale;
                        }

                    case Gender.cisFemale:
                        if (det <= 0.95f)
                        {
                            return Gender.cisFemale;
                        }
                        else
                        {
                            return Gender.transFemale;
                        }

                    case Gender.transMale:
                        if (det <= 0.95f)
                        {
                            return Gender.cisMale;
                        }
                        else
                        {
                            return Gender.transMale;
                        }

                    case Gender.transFemale:
                        if (det <= 0.95f)
                        {
                            return Gender.cisFemale;
                        }
                        else
                        {
                            return Gender.transFemale;
                        }
                }
                break;

            case Sexuality.bi:
                if (det <= 0.47f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.5f)
                {
                    return Gender.transMale;
                }
                else if (det <= 0.97f)
                {
                    return Gender.cisFemale;
                }
                else
                {
                    return Gender.transFemale;
                }

            case Sexuality.pan:
                if (det <= 0.15f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.3f)
                {
                    return Gender.cisFemale;
                }
                else if (det <= 0.45f)
                {
                    return Gender.transMale;
                }
                else if (det <= 0.6f)
                {
                    return Gender.transFemale;
                }
                else if (det <= 0.8f)
                {
                    return Gender.dmabNonBinary;
                }
                else
                {
                    return Gender.dfabNonBinary;
                }
        }
        return Gender.dfabNonBinary;
    }
    public static Gender ChildGender(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);

        switch (root.gender)
        {
            case Gender.cisMale:
            case Gender.cisFemale:
                if (det <= 0.49f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.98f)
                {
                    return Gender.cisFemale;
                }
                else if (det <= 0.99f)
                {
                    return Gender.dmabNonBinary;
                }
                else
                {
                    return Gender.dfabNonBinary;
                }

            case Gender.transMale:
            case Gender.transFemale:
                if (det <= 0.4f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.8f)
                {
                    return Gender.cisFemale;
                }
                else if (det <= 0.9f)
                {
                    return Gender.dmabNonBinary;
                }
                else
                {
                    return Gender.dfabNonBinary;
                }

            case Gender.dmabNonBinary:
            case Gender.dfabNonBinary:
                if (det <= 0.25f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.5f)
                {
                    return Gender.cisFemale;
                }
                else if (det <= 0.75f)
                {
                    return Gender.dmabNonBinary;
                }
                else
                {
                    return Gender.dfabNonBinary;
                }
        }

        return Gender.cisMale;
    }
    public static Gender ChildGender(RootPerson parent1, Person parent2)
    {
        if (GenerationHelpers.GenderTypeMatch(parent1, parent2))
        {
            return ChildGender(parent1);
        }
        else
        {
            float det = Random.Range(0.0f, 1.0f);

            if (GenerationHelpers.IsNB(parent1) || GenerationHelpers.IsNB(parent2))
            {
                if (det <= 0.35f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.7f)
                {
                    return Gender.cisFemale;
                }
                else if (det <= 0.85f)
                {
                    return Gender.dmabNonBinary;
                }
                else
                {
                    return Gender.dfabNonBinary;
                }
            }
            else
            {
                if (det <= 0.45f)
                {
                    return Gender.cisMale;
                }
                else if (det <= 0.9f)
                {
                    return Gender.cisFemale;
                }
                else if (det <= 0.95f)
                {
                    return Gender.dmabNonBinary;
                }
                else
                {
                    return Gender.dfabNonBinary;
                }
            }
        }
    }

    public static AgeGroup RootAgeGroup()
    {
        float det = Random.Range(0.0f, 1.0f);
        if (det <= 0.1f)
        {
            return AgeGroup.youngAdult;
        }
        else if (det <= 0.45f)
        {
            return AgeGroup.adult;
        }
        else if (det <= 0.8f)
        {
            return AgeGroup.middleAged;
        }
        else
        {
            return AgeGroup.senior;
        }
    }
    public static AgeGroup PartnerAgeGroup(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);

        if (root.wealth == Wealth.wealthy)
        {
            switch (root.ageGroup)
            {
                case AgeGroup.youngAdult:
                    if (det <= 0.5f)
                    {
                        return AgeGroup.youngAdult;
                    }
                    else if (det <= 0.99f)
                    {
                        return AgeGroup.adult;
                    }
                    else
                    {
                        return AgeGroup.middleAged;
                    }

                case AgeGroup.adult:
                    if (det <= 0.45f)
                    {
                        return AgeGroup.youngAdult;
                    }
                    else if (det <= 0.9f)
                    {
                        return AgeGroup.adult;
                    }
                    else
                    {
                        return AgeGroup.middleAged;
                    }

                case AgeGroup.middleAged:
                    if (det <= 0.45f)
                    {
                        return AgeGroup.youngAdult;
                    }
                    else if (det <= 0.7f)
                    {
                        return AgeGroup.adult;
                    }
                    else
                    {
                        return AgeGroup.middleAged;
                    }

                case AgeGroup.senior:
                    if (det <= 0.4f)
                    {
                        return AgeGroup.youngAdult;
                    }
                    else if (det <= 0.65f)
                    {
                        return AgeGroup.adult;
                    }
                    else if (det <= 0.7f)
                    {
                        return AgeGroup.middleAged;
                    }
                    else
                    {
                        return AgeGroup.senior;
                    }
            }
        }
        else
        {
            if (det <= 0.5f)
            {
                return root.ageGroup;
            }
            else if (det <= 0.99f)
            {
                switch (root.ageGroup)
                {
                    case AgeGroup.youngAdult:
                        return AgeGroup.adult;

                    case AgeGroup.adult:
                        det = Random.Range(0.0f, 1.0f);
                        if (det <= 0.5f)
                        {
                            return AgeGroup.youngAdult;
                        }
                        else
                        {
                            return AgeGroup.middleAged;
                        }

                    case AgeGroup.middleAged:
                        det = Random.Range(0.0f, 1.0f);
                        if (det <= 0.5f)
                        {
                            return AgeGroup.adult;
                        }
                        else
                        {
                            return AgeGroup.senior;
                        }

                    case AgeGroup.senior:
                        return AgeGroup.middleAged;
                }
            }
            else
            {
                switch (root.ageGroup)
                {
                    case AgeGroup.youngAdult:
                        return AgeGroup.middleAged;

                    case AgeGroup.adult:
                        return AgeGroup.senior;

                    case AgeGroup.middleAged:
                        return AgeGroup.youngAdult;

                    case AgeGroup.senior:
                        return AgeGroup.adult;
                }
            }
        }

        return root.ageGroup;
    }

    public static int Age(AgeGroup group)
    {
        switch (group)
        {
            case AgeGroup.youngAdult:
                return Random.Range(18, 25);

            case AgeGroup.adult:
                return Random.Range(25, 40);

            case AgeGroup.middleAged:
                return Random.Range(40, 60);

            case AgeGroup.senior:
                return Random.Range(60, 91);
        }

        return 0;
    }
    public static int ChildAge(RootPerson root, int remainingChildren)
    {
        if (remainingTwins > 0)
        {
            remainingTwins--;
            return prevAge;
        }
        else
        {
            int maxAge = Mathf.Min(22, root.age - 18, prevAge-1);
            int minAge = Mathf.Max(0, remainingChildren);

            int age = Random.Range(minAge, maxAge + 1);

            if (remainingChildren > 0)
            {
                float det = Random.Range(0.0f, 1.0f);

                if (det <= 0.05f || root.age == 18)
                {
                    remainingTwins = 1;
                }
                else if (det <= 0.06f)
                {
                    remainingTwins = 2;
                }
            }

            prevAge = age;
            return age;
        }
    }
    public static int ChildAge(RootPerson parent1, Person parent2, int remainingChildren)
    {
        if (remainingTwins > 0)
        {
            remainingTwins--;
            return prevAge;
        }
        else
        {
            Person baseParent = GenerationHelpers.GetBaseParent(parent1, parent2);

            int maxAge = Mathf.Min(22, baseParent.age - 18, prevAge - 1);
            int minAge = Mathf.Max(0, remainingChildren);

            int age = Random.Range(minAge, maxAge + 1);

            if (remainingChildren > 0)
            {
                float det = Random.Range(0.0f, 1.0f);

                if (det <= 0.05f || baseParent.age == 18)
                {
                    remainingTwins = 1;
                }
                else if (det <= 0.06f)
                {
                    remainingTwins = 2;
                }
            }

            prevAge = age;
            return age;
        }
    }

    public static Wealth RootWealth(AgeGroup group)
    {
        float det = Random.Range(0.0f, 1.0f);

        if (group == AgeGroup.youngAdult)
        {
            if (det <= 0.6f)
            {
                return Wealth.poor;
            }
            else if (det <= 0.99f)
            {
                return Wealth.middleClass;
            }
            else
            {
                return Wealth.wealthy;
            }
        }
        else
        {
            if (det <= 0.2f)
            {
                return Wealth.poor;
            }
            else if (det <= 0.98f)
            {
                return Wealth.middleClass;
            }
            else
            {
                return Wealth.wealthy;
            }
        }
    }
    public static Sexuality RootSexuality(Gender gender)
    {
        float det = Random.Range(0.0f, 1.0f);

        switch (gender)
        {
            case Gender.cisMale:
            case Gender.cisFemale:
                if (det <= 0.9f)
                {
                    return Sexuality.straight;
                }
                else if (det <= 0.96f)
                {
                    return Sexuality.gay;
                }
                else if (det <= 0.98f)
                {
                    return Sexuality.bi;
                }
                else if (det <= 0.99f)
                {
                    return Sexuality.pan;
                }
                else
                {
                    return Sexuality.aroAce;
                }

            case Gender.transMale:
            case Gender.transFemale:
                if (det <= 0.2f)
                {
                    return Sexuality.straight;
                }
                else if (det <= 0.4f)
                {
                    return Sexuality.gay;
                }
                else if (det <= 0.55f)
                {
                    return Sexuality.bi;
                }
                else if (det <= 0.85f)
                {
                    return Sexuality.pan;
                }
                else
                {
                    return Sexuality.aroAce;
                }

            case Gender.dmabNonBinary:
            case Gender.dfabNonBinary:
                if (det <= 0.01f)
                {
                    return Sexuality.bi;
                }
                else if (det <= 0.9f)
                {
                    return Sexuality.pan;
                }
                else
                {
                    return Sexuality.aroAce;
                }
        }

        return Sexuality.straight;
    }
    public static Relationship RootRelationship(Wealth wealth, AgeGroup group)
    {
        float det = Random.Range(0.0f, 1.0f);

        switch (group)
        {
            case AgeGroup.youngAdult:
                switch (wealth)
                {
                    case Wealth.poor:
                        if (det <= 0.7f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.95f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.middleClass:
                        if (det <= 0.6f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.9f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.wealthy:
                        if (det <= 0.2f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.8f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }
                }
                break;

            case AgeGroup.adult:
                switch (wealth)
                {
                    case Wealth.poor:
                        if (det <= 0.55f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.75f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.middleClass:
                        if (det <= 0.3f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.6f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.wealthy:
                        if (det <= 0.1f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.5f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }
                }
                break;

            case AgeGroup.middleAged:
                switch (wealth)
                {
                    case Wealth.poor:
                        if (det <= 0.3f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.5f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.middleClass:
                        if (det <= 0.2f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.35f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.wealthy:
                        if (det <= 0.1f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.4f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }
                }
                break;

            case AgeGroup.senior:
                switch (wealth)
                {
                    case Wealth.poor:
                        if (det <= 0.25f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.3f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.middleClass:
                        if (det <= 0.15f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.25f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }

                    case Wealth.wealthy:
                        if (det <= 0.1f)
                        {
                            return Relationship.single;
                        }
                        else if (det <= 0.3f)
                        {
                            return Relationship.dating;
                        }
                        else
                        {
                            return Relationship.married;
                        }
                }
                break;
        }

        return Relationship.single;
    }

    public static SkinColor RootSkinColor()
    {
        float det = Random.Range(0.0f, 1.0f);

        if (det <= 0.25f)
        {
            return SkinColor.black;
        }
        else if (det <= 0.5f)
        {
            return SkinColor.brown;
        }
        else if (det <= 0.75f)
        {
            return SkinColor.yellow;
        }
        else
        {
            return SkinColor.white;
        }
    }
    public static SkinColor PartnerSkinColor(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);

        if (det <= 0.5f)
        {
            return root.skinColor;
        }
        else
        {
            return RootSkinColor();
        }
    }
    public static SkinColor ChildSkinColor(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);

        if (det <= 0.5f)
        {
            return root.skinColor;
        }
        else
        {
            det = Random.Range(0.0f, 1.0f);

            switch (root.skinColor)
            {
                case SkinColor.black:
                    if (det <= 0.5f)
                    {
                        return SkinColor.black;
                    }
                    else
                    {
                        return SkinColor.brown;
                    }

                case SkinColor.brown:
                    if (det <= 0.25f)
                    {
                        return SkinColor.black;
                    }
                    else
                    {
                        return SkinColor.brown;
                    }

                case SkinColor.yellow:
                    if (det <= 0.5f)
                    {
                        return SkinColor.brown;
                    }
                    else
                    {
                        return SkinColor.yellow;
                    }

                case SkinColor.white:
                    if (det <= 0.5f)
                    {
                        return SkinColor.brown;
                    }
                    else if (det <= 0.75f)
                    {
                        return SkinColor.yellow;
                    }
                    else
                    {
                        return SkinColor.white;
                    }
            }

            return SkinColor.brown;
        }
    }

    public static HairColor RootHairColor(SkinColor skin)
    {
        float det = Random.Range(0.0f, 1.0f);

        if (skin == SkinColor.white)
        {
            if (det <= 0.2f)
            {
                return HairColor.black;
            }
            else if (det <= 0.7f)
            {
                return HairColor.brown;
            }
            else if (det <= 0.9f)
            {
                return HairColor.blonde;
            }
            else
            {
                return HairColor.red;
            }
        }
        else
        {
            if (det <= 0.8f)
            {
                return HairColor.black;
            }
            else
            {
                return HairColor.brown;
            }
        }
    }
    public static HairColor ChildHairColor(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);
        
        if (det <= 0.5f)
        {
            return root.hairColor;
        }
        else
        {
            det = Random.Range(0.0f, 1.0f);

            switch (root.hairColor)
            {
                case HairColor.black:
                    if (det <= 0.5f)
                    {
                        return HairColor.black;
                    }
                    else if (det <= 0.875f)
                    {
                        return HairColor.brown;
                    }
                    else if (det <= 0.9375f)
                    {
                        return HairColor.blonde;
                    }
                    else
                    {
                        return HairColor.red;
                    }

                case HairColor.brown:
                    if (det <= 0.125f)
                    {
                        return HairColor.black;
                    }
                    else if (det <= 0.75f)
                    {
                        return HairColor.brown;
                    }
                    else if (det <= 0.875f)
                    {
                        return HairColor.blonde;
                    }
                    else
                    {
                        return HairColor.red;
                    }

                case HairColor.blonde:
                    if (det <= 0.0625f)
                    {
                        return HairColor.black;
                    }
                    else if (det <= 0.3125f)
                    {
                        return HairColor.brown;
                    }
                    else if (det <= 0.875f)
                    {
                        return HairColor.blonde;
                    }
                    else
                    {
                        return HairColor.red;
                    }

                case HairColor.red:
                    if (det <= 0.0625f)
                    {
                        return HairColor.black;
                    }
                    else if (det <= 0.3125f)
                    {
                        return HairColor.brown;
                    }
                    else if (det <= 0.4375f)
                    {
                        return HairColor.blonde;
                    }
                    else
                    {
                        return HairColor.red;
                    }
            }

            return HairColor.black;
        }
    }

    public static EyeColor RootEyeColor(SkinColor skin)
    {
        float det = Random.Range(0.0f, 1.0f);

        switch (skin)
        {
            case SkinColor.black:
                return EyeColor.brown;

            case SkinColor.brown:
                if (det <= 0.6f)
                {
                    return EyeColor.brown;
                }
                else if (det <= 0.85f)
                {
                    return EyeColor.blue;
                }
                else
                {
                    return EyeColor.green;
                }

            case SkinColor.yellow:
                if (det <= 0.8f)
                {
                    return EyeColor.brown;
                }
                else
                {
                    return EyeColor.green;
                }

            case SkinColor.white:
                if (det <= 0.45f)
                {
                    return EyeColor.brown;
                }
                else if (det <= 0.8f)
                {
                    return EyeColor.blue;
                }
                else
                {
                    return EyeColor.green;
                }
        }
        return EyeColor.brown;
    }
    public static EyeColor ChildEyeColor(RootPerson root)
    {
        float det = Random.Range(0.0f, 1.0f);

        if (det <= 0.5f)
        {
            return root.eyeColor;
        }
        else
        {
            det = Random.Range(0.0f, 1.0f);

            switch (root.eyeColor)
            {
                case EyeColor.brown:
                    if (det <= 2.0f/3.0f)
                    {
                        return EyeColor.brown;
                    }
                    else if (det <= 5.0f/6.0f)
                    {
                        return EyeColor.blue;
                    }
                    else
                    {
                        return EyeColor.green;
                    }

                case EyeColor.blue:
                    if (det <= 1.0f / 6.0f)
                    {
                        return EyeColor.brown;
                    }
                    else if (det <= 5.0f / 6.0f)
                    {
                        return EyeColor.blue;
                    }
                    else
                    {
                        return EyeColor.green;
                    }

                case EyeColor.green:
                    if (det <= 1.0f / 6.0f)
                    {
                        return EyeColor.brown;
                    }
                    else if (det <= 1.0f / 3.0f)
                    {
                        return EyeColor.blue;
                    }
                    else
                    {
                        return EyeColor.green;
                    }
            }

            return EyeColor.brown;
        }
    }
}
