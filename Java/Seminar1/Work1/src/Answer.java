class Answer {
    public int factorial(int n) {
// Введите свое решение ниже
        if (n < 0) {
            return -1;
        }
        int result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }
}