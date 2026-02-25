package org.example;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableColumn;
import java.awt.*;

public class JTableCustomComponent extends JFrame {

    public JTableCustomComponent() {
        setTitle("Ví dụ JTable với ComboBox và TextField");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(500, 300);
        setLocationRelativeTo(null);

        // 1. Dữ liệu mẫu
        Object[][] data = {
                {"Nguyễn Văn A", "Admin", true},
                {"Trần Thị B", "User", false},
                {"Lê Văn C", "Guest", true}
        };

        // 2. Tên cột
        String[] columnNames = {"Tên (TextField)", "Chức vụ (ComboBox)", "Kích hoạt (CheckBox)"};

        // 3. Tạo Model (Quan trọng: Phải override getColumnClass để hiện Checkbox)
        DefaultTableModel model = new DefaultTableModel(data, columnNames) {
            @Override
            public Class<?> getColumnClass(int columnIndex) {
                // Nếu là cột 2 (cột cuối), trả về Boolean để hiện Checkbox tự động
                if (columnIndex == 2) return Boolean.class;
                return super.getColumnClass(columnIndex);
            }
        };

        JTable table = new JTable(model);

        // Tăng chiều cao hàng để dễ nhìn
        table.setRowHeight(25);

        // --- CẤU HÌNH JCOMBOBOX CHO CỘT "CHỨC VỤ" ---
        // Tạo ComboBox
        JComboBox<String> comboBox = new JComboBox<>();
        comboBox.addItem("Admin");
        comboBox.addItem("User");
        comboBox.addItem("Guest");

        // Lấy cột thứ 2 (index 1) và gán Editor
        TableColumn roleColumn = table.getColumnModel().getColumn(1);
        roleColumn.setCellEditor(new DefaultCellEditor(comboBox));

        // --- CẤU HÌNH (TÙY CHỌN) CHO CỘT "TÊN" ---
        // Mặc định là TextField rồi, nhưng ta có thể custom nếu muốn
        JTextField customField = new JTextField();
        customField.setFont(new Font("Arial", Font.BOLD, 14));
        table.getColumnModel().getColumn(0).setCellEditor(new DefaultCellEditor(customField));

        // Thêm bảng vào frame
        add(new JScrollPane(table));
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            new JTableCustomComponent().setVisible(true);
        });
    }
}