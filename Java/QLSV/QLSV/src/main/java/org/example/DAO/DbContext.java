package org.example.DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DbContext {
    private final static String connectionUrl =
            "jdbc:sqlserver://localhost:1434;"
            + "database=SinhVien_DB;"
            + "user=sa;"
            + "password=YourStrong!Passw0rd;"
            + "encrypt=true;"
            + "trustServerCertificate=true;"
            + "loginTimeout=30;";
    public static Connection getConnection() throws SQLException {
            return DriverManager.getConnection(connectionUrl);
    }
}
