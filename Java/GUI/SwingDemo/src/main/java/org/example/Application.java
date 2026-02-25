package org.example;

import com.formdev.flatlaf.fonts.roboto.FlatRobotoFont;
import com.formdev.flatlaf.themes.FlatMacDarkLaf;

import javax.swing.*;
import java.awt.*;

public class Application extends JFrame {
    public Application() {
        init();
    }
    private void init() {
        setTitle("FlatLaf Login");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(new Dimension(1200, 700));
        setLocationRelativeTo(null); // Canh giữa cửa sổ,
        setContentPane(new LoginFormV2());
    }

    public static void main(String[] args) {
        FlatRobotoFont.install();
        Color accentColor = new Color(88,85,214);
        UIManager.put("Component.focusedBorderColor", accentColor);
        UIManager.put("Component.focusColor", accentColor);
        UIManager.put("defaultFont", new Font(FlatRobotoFont.FAMILY, Font.PLAIN, 13));

        FlatMacDarkLaf.setup();
        SwingUtilities.invokeLater(() -> new Application().setVisible(true));
    }
}
