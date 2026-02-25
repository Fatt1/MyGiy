package org.example;

import com.formdev.flatlaf.FlatDarculaLaf;
import com.formdev.flatlaf.FlatDarkLaf;
import com.formdev.flatlaf.FlatLightLaf;
import com.formdev.flatlaf.fonts.roboto.FlatRobotoFont;
import com.formdev.flatlaf.themes.FlatMacLightLaf;
import net.miginfocom.swing.MigLayout;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class DashboadAdmin extends JFrame {

    public DashboadAdmin() {
        init();
    }
    private void init() {
        setTitle("Dashboard Admin");
        setSize(1200, 700);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null); // Canh giữa cửa sổ


        // Layout tổng quan
        setLayout(new MigLayout("fill, insets 0","[250!][grow]"));

        JPanel sidebarPanel = new JPanel();
        sidebarPanel.setBackground(new Color(45,45,48));
        sidebarPanel.setLayout(new MigLayout("wrap 1, fillx, insets 0", "[grow]", "[]20[]"));

        // Tạo các nút menu tùy chỉnh
        MenuButton btnHome = new MenuButton("Trang chủ");
        MenuButton btnUser = new MenuButton("Quản lý User");
        MenuButton btnSetting = new MenuButton("Cài đặt");


        JLabel lblLogo = new JLabel("ADMIN DASHBOARD");
        lblLogo.setForeground(Color.WHITE);
        lblLogo.setFont(new Font("Segoe UI", Font.BOLD, 20));
        sidebarPanel.add(lblLogo, "center, gaptop 20");

        sidebarPanel.add(btnHome, "grow, h 30!");
        sidebarPanel.add(btnUser, "grow, h 30!");
        sidebarPanel.add(btnSetting, "grow, h 30!");

        add(sidebarPanel, "grow");
    }



    public static void main(String[] args) {
        FlatRobotoFont.install();

        try {
            UIManager.setLookAndFeel(new FlatMacLightLaf());
        }
        catch (Exception ex) {
            System.err.println("Không thể khởi tạo giao diện FlatLaf");
        }

        SwingUtilities.invokeLater(() -> {
            DashboadAdmin dashboardAdmin = new DashboadAdmin();
            dashboardAdmin.setVisible(true); // hiển thị cửa sổ
        });
    }
}
