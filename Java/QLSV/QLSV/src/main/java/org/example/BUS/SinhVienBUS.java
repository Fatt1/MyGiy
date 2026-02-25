package org.example.BUS;

import org.example.DAO.SinhVienDAO;
import org.example.DTO.SinhVien;
import org.example.DTO.ThongKe;

import java.util.List;

public class SinhVienBUS {
    private static List<SinhVien> danhSachSinhVien;
    private final SinhVienDAO sinhVienDAO;
    public SinhVienBUS() {
        sinhVienDAO = new SinhVienDAO();
        if(danhSachSinhVien == null) {
            danhSachSinhVien = sinhVienDAO.getAll();
        }
    }
    public List<SinhVien> getDanhSachSinhVien() {
        return danhSachSinhVien;
    }
    public void addSinhVien(SinhVien sv) {
        var isExistId = danhSachSinhVien.stream().anyMatch(s -> s.getMaSV().equals(sv.getMaSV()));
        if(isExistId) {
            throw new RuntimeException("Ma sinh vien da ton tai");
        }
        String validationError = validateSinhVien(sv);
        if(!validationError.isEmpty()) {
            throw new RuntimeException(validationError);
        }
        sinhVienDAO.add(sv);
        danhSachSinhVien.add(sv);
    }
    public void updateSinhVien(SinhVien sv) {
        String validationError = validateSinhVien(sv);
        if(!validationError.isEmpty()) {
            throw  new RuntimeException(validationError);
        }

        sinhVienDAO.update(sv);
        for (int i = 0; i < danhSachSinhVien.size(); i++) {
            if(danhSachSinhVien.get(i).getMaSV().equals(sv.getMaSV())) {
                danhSachSinhVien.set(i, sv);
                break;
            }
        }
    }
    public SinhVien getSinhVienById(String maSV){
        for (SinhVien sv : danhSachSinhVien) {
            if(sv.getMaSV().equals(maSV)) {
                return sv;
            }
        }
        return null;
    }

    public ThongKe thongKeSinhVien(List<SinhVien> list) {
        int tongNam = 0;
        int tongNu = 0;
        for(var sv : list) {
            if(sv.getGioiTinh() == 1)
                tongNam += 1;
            else
                tongNu += 1;
        }
        var thongKe = new ThongKe();
        thongKe.setTongNam(tongNam);
        thongKe.setTongNu(tongNu);
        return thongKe;
    }

    private String validateSinhVien(SinhVien sv) {
        StringBuilder errorMessage = new StringBuilder();
        if(sv.getMaSV() == null || sv.getMaSV().isEmpty()) {
            errorMessage.append("Ma sinh vien khong duoc de trong\n");
        }
        if(sv.getHoTen() == null || sv.getHoTen().isEmpty()) {
            errorMessage.append("Ho ten khong duoc de trong\n");
        }
        if(sv.getGioiTinh() == null || (sv.getGioiTinh() != 0 && sv.getGioiTinh() != 1)) {
            errorMessage.append("Gioi tinh khong hop le\n");
        }
        return errorMessage.toString();
    }

    public List<SinhVien> searchSinhVien(String searchKey, List<String> nganhHoc) {
        var stream  = danhSachSinhVien.stream();
        if(searchKey != null && !searchKey.isEmpty()) {
            stream = stream.filter(sv -> sv.getMaSV().toLowerCase().contains(searchKey.toLowerCase())
                    || sv.getHoTen().toLowerCase().contains(searchKey.toLowerCase()));
        }
        if(nganhHoc != null && !nganhHoc.isEmpty()) {
            stream = stream.filter(sv -> nganhHoc.contains(sv.getNganhHoc()));
        }
        return stream.toList();
    }

    public void deleteSinhVien(String maSV){
        sinhVienDAO.delete(maSV);
        danhSachSinhVien.removeIf(sv -> sv.getMaSV().equals(maSV));
    }

}
