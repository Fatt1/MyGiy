package org.example;

import java.util.ArrayList;

public class DSSV {
    private final ArrayList<SinhVien> sinhVienList = new ArrayList<>();

    public void themSinhVien(SinhVien sv) {
        sinhVienList.add(sv);
    }

    public void xoaSinhVien(int maSinhVien) {
        sinhVienList.removeIf(sv -> sv.getMaSv() == maSinhVien);
    }

    public void hienThiDanhSach() {
        for (SinhVien sv : sinhVienList) {
            System.out.println(sv.xuat());
        }
    }

    public SinhVien timKiemSinhVien(int maSinhVien){
        for(SinhVien sv : sinhVienList) {
            if(sv.getMaSv() == maSinhVien)
                return sv;
        }
        return null;
    }

    public void thongKeSinhVienTheoGioiTinh() {
        int soLuongNam = 0;
        int soLuongNu = 0;
        for (SinhVien sv : sinhVienList) {
            if (sv.getGioiTinh() == 1) {
                soLuongNam++;
            } else {
                soLuongNu++;
            }
        }
        System.out.println("So luong sinh vien Nam: " + soLuongNam);
        System.out.println("So luong sinh vien Nu: " + soLuongNu);
    }
}
