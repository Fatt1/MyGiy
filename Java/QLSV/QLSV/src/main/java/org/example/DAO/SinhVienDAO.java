package org.example.DAO;

import org.example.DTO.SinhVien;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class SinhVienDAO {
    public SinhVienDAO() {
    }
    public List<SinhVien> getAll() {
        String sql = "SELECT * FROM SinhVien";
        try(Connection conn = DbContext.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);

        ) {
            ResultSet rs = ps.executeQuery();
            List<SinhVien> sv = new ArrayList<>();
            while(rs.next()) {
                SinhVien s = new SinhVien();
                s.setMaSV(rs.getString("maSV"));
                s.setHoTen(rs.getString("hoTen"));
                s.setGioiTinh(rs.getInt("gioiTinh"));
                s.setNganhHoc(rs.getString("nganhHoc"));
                s.setNgaySinh(rs.getDate("ngaySinh"));
                s.setKyNang(rs.getString("KyNang"));
                sv.add(s);
            }
            return sv;
        }
        catch (SQLException sqlException) {
            sqlException.printStackTrace();
            throw new RuntimeException("Lỗi lấy danh sách sinh viên");
        }
    }

    public void add(SinhVien sv ) {
        String sql = "INSERT INTO SinhVien(MaSV, HoTen, GioiTinh, NgaySinh, NganhHoc, KyNang) VALUES (?,?,?,?,?, ?)";
        try(Connection conn = DbContext.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
        ){
            ps.setString(1, sv.getMaSV());
            ps.setString(2, sv.getHoTen());
            ps.setInt(3, sv.getGioiTinh());
            ps.setDate(4, new Date(sv.getNgaySinh().getTime()));
            ps.setString(5, sv.getNganhHoc());
            ps.setString(6, sv.getKyNang());
            ps.executeUpdate();
        }
        catch (SQLException sqlException) {
            sqlException.printStackTrace();
            throw  new RuntimeException("Lỗi thêm sinh viên");
        }
    }

    public void update(SinhVien sv) {
        String sql = "UPDATE SinhVien SET HoTen = ?, GioiTinh = ?, NgaySinh = ?, NganhHoc = ?, KyNang = ? WHERE MaSV = ?";
        try(Connection conn = DbContext.getConnection()){
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, sv.getHoTen());
            ps.setInt(2, sv.getGioiTinh());
            ps.setDate(3, new Date(sv.getNgaySinh().getTime()));
            ps.setString(4, sv.getNganhHoc());
            ps.setString(6, sv.getMaSV());
            ps.setString(5, sv.getKyNang());
            ps.executeUpdate();
        }
        catch (SQLException sqlException) {
            sqlException.printStackTrace();
            throw new RuntimeException("Lỗi cập nhật sinh viên");
        }
    }

    public void delete(String maSV){
        String sql = "DELETE FROM SinhVien Where MaSv = ?";
        try(Connection conn = DbContext.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
        ) {
            ps.setString(1, maSV);
            ps.executeUpdate();
        }
        catch (SQLException sqlException) {
            sqlException.printStackTrace();
            throw new RuntimeException("Lỗi xóa sinh viên");
        }
    }
}
