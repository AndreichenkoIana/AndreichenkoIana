import java.util.LinkedList;

class LLTasks {
    public static void removeOddLengthStrings(LinkedList<String> ll)
    {
        LinkedList<String> toRemove = new LinkedList<>();
        for (String s : ll) {
            if (s.length() % 2 != 0) {
                toRemove.add(s);
            }
        }
        ll.removeAll(toRemove);
    }
}
