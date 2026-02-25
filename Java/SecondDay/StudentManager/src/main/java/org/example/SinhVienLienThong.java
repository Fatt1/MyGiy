package org.example;

import java.util.Scanner;

public class SinhVienLienThong extends SinhVien{
    private int namTotNghiep;
    private String nganhCaoDang;

    public SinhVienLienThong() {
        super();
    }

    @Override
    public void nhapThongTin() {
        super.nhapThongTin();
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap nam tot nghiep: ");
        namTotNghiep = scanner.nextInt();
        System.out.print("Nhap nganh cao dang: ");
        nganhCaoDang = scanner.next();
        this.namTotNghiep = namTotNghiep;
        this.nganhCaoDang = nganhCaoDang;
    }

    @Override
    public String xuat() {
        String info = super.xuat();
        info += ", Nam tot nghiep: " + namTotNghiep + ", Nganh cao dang: " + nganhCaoDang;
        return info;
    }
}
