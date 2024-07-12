using AppConsole;
using System.Runtime.Intrinsics.X86;
public class Program
{
    public static void Main()
    {
        FemalyMembers GrandFatherMother = new FemalyMembers()
        {
            FullName = "Горобец Борис",
            Age = 56,
            Gender = Gender.men
        };
        FemalyMembers GrandFatherFather = new FemalyMembers()
        {
            FullName = "Андрейченко Александр",
            Age = 75,
            Gender = Gender.men
        };
        FemalyMembers GrandMotherMother = new FemalyMembers()
        {
            FullName = "Горобец Анжела",
            Age = 55,
            Gender = Gender.woman
        };
        FemalyMembers GrandMotherFather = new FemalyMembers()
        {
            FullName = "Андрейченко Надежда",
            Age = 60,
            Gender = Gender.woman
        };
        FemalyMembers Mother = new FemalyMembers()
        {
            FullName = "Андрейченко Яна",
            Age = 28,
            Gender = Gender.woman,
            Mother = GrandMotherMother,
            Father = GrandFatherMother
            
        };
        FemalyMembers Father = new FemalyMembers()
        {
            FullName = "Андрейченко Марк",
            Age = 34,
            Gender = Gender.men,
            Mother = GrandMotherFather,
            Father = GrandFatherFather
        };
        FemalyMembers Daughter = new FemalyMembers()
        {
            FullName = "Андрейченко Елизавета",
            Age = 4,
            Gender = Gender.woman,
            Mother = Mother,
            Father = Father
        };
        Mother.SetPartner(Father);
        Father.SetPartner(Mother);
        Father.SetChildren(Daughter);
        Mother.SetChildren(Daughter);
        var Parent1 = Father.GetParent();
        var Parent2 = Mother.GetParent();
        Console.WriteLine($"Дерево человека: {Father.FullName}");
        Console.WriteLine("____________________");
        Console.WriteLine($"Родители {Father.FullName}: ");
        Console.WriteLine($"Мама: {Parent1[0].FullName}");
        Console.WriteLine($"Папа: {Parent1[1].FullName}");
        Console.WriteLine("____________________");
        Console.WriteLine($"Жена: {Father.Partner.FullName}");
        Console.WriteLine($"Родители {Father.Partner.FullName}: ");
        Console.WriteLine($"Мама: {Parent2[0].FullName}");
        Console.WriteLine($"Папа: {Parent2[1].FullName}");
        Console.WriteLine("____________________");
        Console.WriteLine($"Дочь: {Father.Children.FullName}");
    }
}