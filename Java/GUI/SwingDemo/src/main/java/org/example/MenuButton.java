package org.example;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class MenuButton extends JButton {
    private Color colorNormal = new Color(30, 30, 30); // Màu nền trùng màu Sidebar (ẩn đi)
    private Color colorHover = new Color(50, 50, 50);  // Màu khi di chuột (sáng hơn tí)
    private Color colorActive = new Color(0, 120, 215); // Màu khi đang chọn (Xanh dương)

    private boolean isActive = false;

    public MenuButton(String text) {
        super(text);
        setFont(new Font("Segoe UI", Font.PLAIN, 14));
        setForeground(Color.WHITE); // Chữ màu trắng

        // QUAN TRỌNG: Bỏ vẽ khung và nền mặc định của Swing
        setContentAreaFilled(false);
        setFocusPainted(false);      // Bỏ viền focus khi click
        setBorderPainted(false);     // Bỏ viền nút
        setOpaque(false);             // Để mình tự tô màu nền
        setBackground(colorNormal);  // Mặc định là màu ẩn

        setHorizontalAlignment(SwingConstants.LEFT); // Căn chữ sang trái
        setMargin(new Insets(0, 20, 0, 0)); // Cách lề trái 20px cho đẹp

        // Sự kiện chuột để làm hiệu ứng Hover
        addMouseListener(new MouseAdapter() {
            @Override
            public void mouseEntered(MouseEvent e) {
                if (!isActive) { // Nếu không phải nút đang chọn thì mới đổi màu hover
                    setBackground(colorHover);
                    setCursor(new Cursor(Cursor.HAND_CURSOR)); // Đổi con trỏ chuột thành bàn tay
                    repaint();
                }
            }

            @Override
            public void mouseExited(MouseEvent e) {
                if (!isActive) {
                    setBackground(colorNormal); // Trả về màu cũ
                    repaint();
                }
            }
        });
    }

    // Hàm để MainFrame gọi khi nút được click
    public void setActive(boolean active) {
        this.isActive = active;
        if (active) {
            setBackground(colorActive); // Xanh dương
            setFont(getFont().deriveFont(Font.BOLD)); // Chữ đậm lên
        } else {
            setBackground(colorNormal); // Trở về trong suốt
            setFont(getFont().deriveFont(Font.PLAIN)); // Chữ thường
        }
    }
}

