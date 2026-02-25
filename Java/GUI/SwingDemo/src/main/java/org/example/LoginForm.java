package org.example;

import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.EmptyBorder;
import java.awt.*;

public class LoginForm extends JFrame {
    public LoginForm() {
        setTitle("Đăng nhập cửa hàng");
        setSize(600, 300);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null); // Canh giữa cửa sổ
//        setLayout(new GridLayout(3,1)); // Bố cục lưới 3 hàng, 1 cột
        setLayout(new BoxLayout(getContentPane(), BoxLayout.Y_AXIS)); // Bố cục theo trục Y

        Dimension labelSize = new Dimension(120, 30);

        // Tầng userName
        JPanel panelUser = new JPanel();
        panelUser.setLayout(new FlowLayout(FlowLayout.CENTER, 20,20)); // cách nhau 20px

        JLabel lblUser = new JLabel("Tên đăng nhập");
        lblUser.setFont(new Font("Arial", Font.BOLD, 14));
        lblUser.setPreferredSize(labelSize);
        lblUser.setHorizontalAlignment(SwingConstants.LEFT);

        JTextField txtUser= new JTextField();
        txtUser.setPreferredSize(new Dimension(200, 30)); // Kích thước w: 200x h: 30px

        panelUser.add(lblUser);
        panelUser.add(txtUser);

        // Tầng password
        JPanel passwordPanel = new JPanel();
        passwordPanel.setLayout(new FlowLayout(FlowLayout.CENTER, 20,0));

        JLabel lblPassword = new JLabel("Mật khẩu");
        lblPassword.setFont(new Font("Arial", Font.BOLD, 14));
        lblPassword.setPreferredSize(labelSize);
        lblPassword.setHorizontalAlignment(SwingConstants.LEFT);

        JPasswordField txtPassword = new JPasswordField();
        txtPassword.setPreferredSize(new Dimension(200, 30));

        passwordPanel.add(lblPassword);
        passwordPanel.add(txtPassword);

        // Tâng button
        JPanel panelButton = new JPanel();
        panelButton.setLayout(new FlowLayout());
//        panelButton.setBorder(new EmptyBorder(2,0,0,0)); // padding top 10px
        JButton btnLogin = new JButton("Đăng nhập");
        btnLogin.setBackground(new Color(30,144,255)); // Màu nền xanh dương
        btnLogin.setForeground(Color.WHITE); // Màu chữ trắng
        btnLogin.setFont(new Font("Arial", Font.BOLD, 14));
        btnLogin.setPreferredSize(new Dimension(200,40));

        btnLogin.setToolTipText("Nhấn nút để đăng nhập"); // Hiển thị gợi ý khi hover chuột

        btnLogin.addActionListener(e -> {
            String username = txtUser.getText();
            String password = new String(txtPassword.getPassword());

            if (username.equals("admin") && password.equals("password")) {
                JOptionPane.showMessageDialog(this, "Đăng nhập thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } else {
                JOptionPane.showMessageDialog(this, "Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        });

        panelButton.add(btnLogin);


        add(panelUser);
        add(Box.createVerticalStrut(10));
        add(passwordPanel);
        add(panelButton);
        pack();

    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            LoginForm loginForm = new LoginForm();
            loginForm.setVisible(true);
        });
    }
}
