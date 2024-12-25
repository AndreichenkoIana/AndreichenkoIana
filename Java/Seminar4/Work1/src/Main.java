import java.util.LinkedList;

public class Main
{
    public static void main(String[] args)
    {
        LinkedList<String> ll = new LinkedList<>();
        if (args.length == 0)
        {
            ll.add("apple");
            ll.add("banana");
            ll.add("pear");
            ll.add("grape");
        } else
        {
            for (String arg : args)
            {
                ll.add(arg);
            }
        }
        LLTasks answer = new LLTasks();
        System.out.println(ll);
        answer.removeOddLengthStrings(ll);
        System.out.println(ll);
    }
}
