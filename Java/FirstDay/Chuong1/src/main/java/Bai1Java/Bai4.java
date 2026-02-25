package Bai1Java;

import java.util.Scanner;

public class Bai4 {
    public static void main(String[] args) {
        System.out.println("Bai 4 Java");
        System.out.print("Enter n: ");
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        if(n % 2 == 0 ) {
            System.out.println(n + " is an even number.");
        } else {
            System.out.println(n + " is an odd number.");
        }
    }

}
