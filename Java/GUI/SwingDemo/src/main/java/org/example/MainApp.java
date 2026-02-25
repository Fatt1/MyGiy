package org.example;

import javax.swing.*;
import java.awt.*;

public class MainApp extends JFrame {
    public MainApp() {
        setTitle("Ứng dụng Swing đầu tiên");
        setSize(400, 300);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // Đóng ứng dụng khi cửa sổ được đóng
        setLocationRelativeTo(null); // Căn giữa cửa sổ trên
        setLayout(new GridLayout(2,5)); // chọn bố cục FlowLayout


        JLabel label = new JLabel("Xin chào, Nhấn nút bên dưới!");
        JButton button = new JButton("Nhấn tôi");
        JButton button1 = new JButton("Nhấn tôi");

        button.addActionListener(e -> JOptionPane.showMessageDialog(null,"Bạn đã nhấn nút!"));


        add(label);
        add(button);
        add(button1);
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            MainApp app = new MainApp();
            app.setVisible(true); // hiển thị cửa sổ
        });
    }
}
