package Bai1Java;

import java.util.Scanner;

public class Bai1 {
    public static void main(String[] args) {
        int option = -1;
        do{

            System.out.println("1. Addition");
            System.out.println("2. Subtraction");
            System.out.println("3. Multiplication");
            System.out.println("4. Division");
            System.out.println("5. Exit");
            System.out.print("Choose an option: ");
            Scanner scanner = new Scanner(System.in);
            option = scanner.nextInt();
            if(option < 1 || option > 5) {
                System.out.println("Invalid option. Please choose again.");
                continue;
            }
            if(option == 5) {
                break;
            }
            System.out.print("Enter first number: ");
            double num1 = scanner.nextDouble();
            System.out.print("Enter second number: ");
            double num2 = scanner.nextDouble();
            double result = 0;
            if(option == 1) {
                result = add((int)num1, (int)num2);
            } else if(option == 2) {
                result = minus((int)num1, (int)num2);
            } else if(option == 3) {
                result = multiply(num1, num2);
            } else if(option == 4) {
                try {
                    result = divide(num1, num2);
                } catch (IllegalArgumentException e) {
                    System.out.println(e.getMessage());
                    continue;
                }
            }
            System.out.println("Result: " + result);
        }while(true);
    }

    private static int add(int a, int b) {
        return a + b;
    }

    private static int minus(int a, int b) {
        return a - b;
    }
    private static double multiply(double a, double b) {
        return a * b;
    }
    private static double divide(double a, double b) {
        if (b == 0) {
            throw new IllegalArgumentException("Cannot divide by zero");
        }
        return a / b;
    }
}
