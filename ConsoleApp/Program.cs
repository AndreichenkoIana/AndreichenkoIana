public class FamalyMembers
{
    int Age { get; set; }
    Gender Gender { get; set; }
    string FullName { get; set; }
    FamalyMembers Mother { get; set; }
    FamalyMembers Father { get; set; }

    public FamalyMembers[] GetGrandMother()
    {
        return new FamalyMembers[] { Mother.Mother, Father.Mother };
    }

    public FamalyMembers[] GetGrandFather()
    {
        return new FamalyMembers[] { Mother.Father, Father.Father };
    }
}


enum Gender { men, woman}