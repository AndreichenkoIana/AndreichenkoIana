import java.util.LinkedList;

public class Main
{
    public static void main(String[] args)
    {
        LinkedList<String> list = new LinkedList<>();
        String value;
        if (args.length < 2)
        {
            list.add("apple");
            list.add("banana");
            list.add("apple");
            list.add("pear");
            list.add("banana");
            value = "apple";
        } else
        {
            for (int i = 0; i < args.length - 1; i++)
            {
                list.add(args[i]);
            }
            value = args[args.length - 1];
        }
        ListUtils utils = new ListUtils();
        System.out.println("Occurrences of \"" + value + "\": " + utils.countOccurrences(list, value));
    }
}