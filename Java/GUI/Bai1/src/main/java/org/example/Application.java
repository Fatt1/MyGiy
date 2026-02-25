package org.example;

import javax.swing.*;
import java.awt.*;

public class Application extends JFrame {

    public Application() {
        init();
    }
    public void init() {
        setTitle("Bai tap 1");
        setSize(500, 500);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null); // canh giua man hinh

        JPanel panel = new JPanel(new GridLayout(0,1, 10,10));
        JLabel label = new JLabel("Tinh so", SwingConstants.CENTER);

        JLabel lblFirstNumber = new JLabel("So thu nhat");
        JTextField txtFirstNumber = new JTextField();
        JLabel lblSecondNumber = new JLabel("So thu hai");
        JTextField txtSecondNumber = new JTextField();
        JButton btnCalculate = new JButton("Tinh");
        JLabel lblResult = new JLabel();
        btnCalculate.addActionListener(e -> {
            int firstNumber = Integer.parseInt(txtFirstNumber.getText());
            int secondNumber = Integer.parseInt(txtSecondNumber.getText());
            int sum = firstNumber + secondNumber;
            int minus = firstNumber - secondNumber;
            int multiply = firstNumber * secondNumber;
            if(secondNumber == 0) {
                lblResult.setText("Khong the chia cho 0");
                return;
            }
            double divide = (double) firstNumber / secondNumber;

            lblResult.setText("<html>Tong: " + sum + "<br/>Hieu: " + minus + "<br/>Tich: " + multiply + "<br/>Thuong: " + divide + "</html>");

        });


        panel.add(label);
        panel.add(lblFirstNumber);
        panel.add(txtFirstNumber);
        panel.add(lblSecondNumber);
        panel.add(txtSecondNumber);
        panel.add(btnCalculate);
        panel.add(lblResult);
        add(panel);


    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            Application app = new Application();
            app.setVisible(true);
        });
    }

}
