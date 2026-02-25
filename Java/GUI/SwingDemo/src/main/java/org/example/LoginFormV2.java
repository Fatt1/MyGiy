package org.example;

import com.formdev.flatlaf.FlatClientProperties;
import net.miginfocom.swing.MigLayout;

import javax.swing.*;
import java.awt.*;

public class LoginFormV2 extends JPanel {
    public LoginFormV2() {
        init();
    }


    private void init() {
        setLayout(new MigLayout("fill, insets 20", "[center]" ));
        txtUserName = new JTextField();
        txtPassword = new JPasswordField();
        chkRememberMe = new JCheckBox("Ghi nhớ đăng nhập");
        btnLogin = new JButton("Đăng nhập");
        JPanel panel = new JPanel(new MigLayout("wrap, fillx, insets 35 45 30 45", "fill,250:280"));
        JLabel lblTitle = new JLabel("Welcome Back!");
        JLabel description = new JLabel("Please enter your credentials to continue.");

        panel.putClientProperty(FlatClientProperties.STYLE, "" +
                "arc:20;" +
                "background:lighten(#1d1d1d, 15%);"

        );

        lblTitle.putClientProperty(FlatClientProperties.STYLE, "" +
                "font: bold +10");

        description.putClientProperty(FlatClientProperties.STYLE, "" +
                "foreground:#888888");

        txtUserName.putClientProperty(FlatClientProperties.PLACEHOLDER_TEXT, "Enter your username");
        txtUserName.putClientProperty(FlatClientProperties.STYLE, "" +
                "arc:10;"
                );

        txtPassword.putClientProperty(FlatClientProperties.PLACEHOLDER_TEXT, "Enter your password");
        txtPassword.putClientProperty(FlatClientProperties.STYLE, "" +
                "showRevealButton:true;" +
                "arc:10"
                );
        btnLogin.putClientProperty(FlatClientProperties.STYLE, "" +
                "focusWidth:0;" +
                "borderWidth:0;" +
                "font: bold"

        );

       panel.add(lblTitle);
        panel.add(description);
        panel.add(new JLabel("Username"), "gapy 10");
        panel.add(txtUserName, "h 25!");
        panel.add(new JLabel("Password"), "gapy 10");
        panel.add(txtPassword, "h 25!");
        panel.add(chkRememberMe, "gapy 10");

        panel.add(btnLogin, "gaptop 10, h 35!");
        panel.add(createSignupLabel(), "gaptop 10");
        add(panel);
    }

    private Component createSignupLabel() {
        JPanel panel = new JPanel(new FlowLayout(FlowLayout.CENTER, 0, 0));
        panel.putClientProperty(FlatClientProperties.STYLE, "" +
                "background:null");

        JLabel lblSignupPrompt = new JLabel("Don't have an account? ");
        JButton btnSignup = new JButton("<html><a href=\"#\">Sign up</a></html>");

        btnSignup.setCursor(new Cursor(Cursor.HAND_CURSOR));
        btnSignup.putClientProperty(FlatClientProperties.STYLE, "" +
                "border:3,3,3,3");
        btnSignup.setContentAreaFilled(false);
        btnSignup.addActionListener(e -> {
            JOptionPane.showMessageDialog(this, "Redirecting to signup page...");
        });
        panel.add(lblSignupPrompt);
        panel.add(btnSignup);
        return panel;
    }

    private JTextField txtUserName;
    private JPasswordField txtPassword;
    private JCheckBox chkRememberMe;
    private JButton btnLogin;
}
