package Bai1Java;

import java.util.Scanner;

public class Bai5 {
    public static void main(String[] args) {
        System.out.println("Bai 5 Java");
        System.out.print("Enter n: ");
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        if(n > 0) {
            System.out.println(n + " is a positive number.");
        } else if (n < 0) {
            System.out.println(n + " is a negative number.");
        } else {
            System.out.println("n is zero.");
        }

    }
}
