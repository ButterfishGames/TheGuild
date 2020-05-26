using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerationHelpers
{
    public static bool SABMatch(Person person1, Person person2)
    {
        return ((person1.gender == Gender.cisMale || person1.gender == Gender.transFemale || person1.gender == Gender.dmabNonBinary)
            && (person2.gender == Gender.cisMale || person2.gender == Gender.transFemale || person2.gender == Gender.dmabNonBinary))
            || ((person1.gender == Gender.cisFemale || person1.gender == Gender.transMale || person1.gender == Gender.dfabNonBinary)
            && (person2.gender == Gender.cisFemale || person2.gender == Gender.transMale || person2.gender == Gender.dfabNonBinary));
    }

    public static bool GenderTypeMatch(Person person1, Person person2)
    {
        return ((person1.gender == Gender.cisMale || person1.gender == Gender.cisFemale)
            && (person2.gender == Gender.cisMale || person2.gender == Gender.cisFemale))
            || ((person1.gender == Gender.transMale || person1.gender == Gender.transFemale)
            && (person2.gender == Gender.transMale || person2.gender == Gender.transFemale))
            || ((person1.gender == Gender.dmabNonBinary || person1.gender == Gender.dfabNonBinary)
            && (person2.gender == Gender.dmabNonBinary || person2.gender == Gender.dfabNonBinary));
    }

    public static bool IsCis(Person person)
    {
        return person.gender == Gender.cisMale || person.gender == Gender.cisFemale;
    }

    public static bool IsTrans(Person person)
    {
        return person.gender == Gender.transMale || person.gender == Gender.transFemale;
    }

    public static bool IsNB(Person person)
    {
        return person.gender == Gender.dmabNonBinary || person.gender == Gender.dfabNonBinary;
    }

    public static Person GetBaseParent(Person parent1, Person parent2)
    {
        if ((parent1.ageGroup == AgeGroup.youngAdult && (parent2.ageGroup == AgeGroup.middleAged || parent2.ageGroup == AgeGroup.senior))
            || (parent1.ageGroup == AgeGroup.adult && parent2.ageGroup == AgeGroup.senior))
        {
            return parent2;
        }
        else if ((parent1.ageGroup == AgeGroup.middleAged && parent2.ageGroup == AgeGroup.youngAdult)
            || (parent1.ageGroup == AgeGroup.senior && (parent2.ageGroup == AgeGroup.youngAdult || parent2.ageGroup == AgeGroup.adult)))
        {
            return parent1;
        }
        else if (parent2.age < parent1.age)
        {
            return parent2;
        }
        else
        {
            return parent1;
        }
    }
}
