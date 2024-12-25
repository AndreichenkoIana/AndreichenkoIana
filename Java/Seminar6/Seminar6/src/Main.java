import java.util.*;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Set<Laptop> laptops = new HashSet<>();
        laptops.add(new Laptop(8, 512, "Windows 10", "Black"));
        laptops.add(new Laptop(16, 1024, "Windows 11", "Silver"));
        laptops.add(new Laptop(8, 256, "Ubuntu", "Black"));
        laptops.add(new Laptop(32, 1024, "macOS", "Gray"));
        laptops.add(new Laptop(16, 512, "Windows 10", "White"));
        Map<Integer, String> criteria = new HashMap<>();
        criteria.put(1, "ОЗУ");
        criteria.put(2, "Объем ЖД");
        criteria.put(3, "Операционная система");
        criteria.put(4, "Цвет");
        Scanner scanner = new Scanner(System.in);
        Map<String, Object> filters = new HashMap<>();
        boolean continueFiltering = true;
        while (continueFiltering) {
            System.out.println("Введите цифру, соответствующую необходимому критерию:");
            for (Map.Entry<Integer, String> entry :
                    criteria.entrySet()) {
                System.out.println(entry.getKey() + " - " +
                        entry.getValue());
            }
            int criterion = scanner.nextInt();
            scanner.nextLine();
            switch (criterion) {
                case 1:
                    System.out.print("Введите минимальное значение ОЗУ (в ГБ): ");
                    filters.put("ram", scanner.nextInt());
                    scanner.nextLine();
                    break;
                case 2:
                    System.out.print("Введите минимальное значение объема ЖД (в ГБ): ");
                    filters.put("hdd", scanner.nextInt());
                    scanner.nextLine();
                    break;
                case 3:
                    System.out.print("Введите операционную систему: ");
                            filters.put("os", scanner.nextLine());
                    break;
                case 4:
                    System.out.print("Введите цвет: ");
                    filters.put("color", scanner.nextLine());
                    break;
                default:
                    System.out.println("Некорректный критерий.");
            }
            System.out.print("Хотите добавить еще один критерий? (да/нет): ");
            String response = scanner.nextLine();
            continueFiltering = response.equalsIgnoreCase("да");
        }
        filterLaptops(laptops, filters);
    }
    public static void filterLaptops(Set<Laptop> laptops,
                                     Map<String, Object> filters) {
        for (Laptop laptop : laptops) {
            boolean matches = true;
            if (filters.containsKey("ram") && laptop.getRam() <
                    (int) filters.get("ram")) {
                matches = false;
            }
            if (filters.containsKey("hdd") && laptop.getHdd() <
                    (int) filters.get("hdd")) {
                matches = false;
            }
            if (filters.containsKey("os") &&
                    !laptop.getOs().equalsIgnoreCase((String) filters.get("os"))) {
                matches = false;
            }
            if (filters.containsKey("color") &&
                    !laptop.getColor().equalsIgnoreCase((String)
                            filters.get("color"))) {
                matches = false;
            }
            if (matches) {
                System.out.println(laptop);
            }
        }
    }
}