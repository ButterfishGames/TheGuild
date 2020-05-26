using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Household
{
    RootPerson root;
    List<Person> otherMembers;

    public Household()
    {
        root = new RootPerson();
        otherMembers = new List<Person>();

        if (root.relationship != Relationship.single)
        {
            otherMembers.Add(new Person(PersonType.partner, root));
        }

        int numChildren = NumChildren();
        for (int i = 0; i < numChildren; i++)
        {
            if (root.relationship == Relationship.single)
            {
                otherMembers.Add(new Person(PersonType.child, root, numChildren-i-1));
            }
            else
            {
                otherMembers.Add(new Person(PersonType.child, root, otherMembers[0], numChildren-i-1));
            }
        }
    }

    private int NumChildren()
    {
        int res = 0;
        float[] vals;

        switch (root.ageGroup)
        {
            case AgeGroup.youngAdult:
                vals = new float[] { 0.9f, 0.99f };
                break;

            case AgeGroup.adult:
                vals = new float[] { 0.25f, 0.5f, 0.75f };
                break;

            case AgeGroup.middleAged:
                vals = new float[] { 0.2f, 0.5f, 0.8f };
                break;

            case AgeGroup.senior:
                vals = new float[] { 0.7f, 0.85f, 0.95f };
                break;

            default:
                vals = new float[0];
                Debug.LogError("Invalid age group");
                break;
        }

        float det = Random.Range(0.0f, 1.0f);

        vals = ChildOddMod(vals);

        for (int i = vals.Length - 1; i >= 0; i--)
        {
            if (det >= vals[i])
            {
                res = i + 1;
                break;
            }
        }

        return res;
    }

    private float[] ChildOddMod(float[] input)
    {
        float modifier = 0.0f;

        if (root.wealth == Wealth.poor)
        {
            modifier += 0.01f;
        }

        if (root.relationship == Relationship.dating)
        {
            modifier += 0.01f;
        }
        else if (root.relationship == Relationship.married)
        {
            modifier += 0.02f;
            if (root.wealth == Wealth.wealthy)
            {
                modifier += 0.01f;
            }
        }

        if (root.relationship == Relationship.single)
        {
            modifier -= 0.02f;
        }
        else
        {
            if (GenerationHelpers.SABMatch(root, otherMembers[0]))
            {
                modifier -= 0.02f;
            }
            else
            {
                modifier += 0.01f;
            }

            if (root.gender != Gender.cisMale && root.gender != Gender.cisFemale)
            {
                modifier -= 0.01f;
            }
            else if (otherMembers[0].gender != Gender.cisMale && otherMembers[0].gender != Gender.cisFemale)
            {
                modifier -= 0.01f;
            }
        }

        float[] output = input;
        int count = 1;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            output[i] -= modifier * count;
            count++;
        }

        return output;
    }
}