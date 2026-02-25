package org.example;

import java.util.Scanner;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        DSSV dssv = new DSSV();
        int option = -1;
        do{
            System.out.println("===== MENU =====");
            System.out.println("1. Them sinh vien");
            System.out.println("2. Xoa sinh vien");
            System.out.println("3. Hien thi danh sach sinh vien");
            System.out.println("4. Tim kiem sinh vien");
            System.out.println("5. Thong ke sinh vien theo gioi tinh");
            System.out.println("0. Thoat");
            System.out.print("Chon chuc nang: ");
            Scanner scanner = new Scanner(System.in);
            option = scanner.nextInt();
            switch (option) {
                case 1:
                    System.out.println("1. Them sinh vien chinh quy: ");
                    System.out.println("2. Them sinh vien lien thong: ");
                    int choose = scanner.nextInt();
                    SinhVien sv = null;
                    if(choose == 1) {
                        sv = new SinhVienChinhQuy();
                    } else if(choose == 2) {
                        sv = new SinhVienLienThong();
                    } else {
                        System.out.println("Lua chon khong hop le.");
                        break;
                    }
                    sv.nhapThongTin();
                    dssv.themSinhVien(sv);
                    break;
                case 2:
                    System.out.print("Nhap ma sinh vien can xoa: ");
                    int maSvXoa = scanner.nextInt();
                    dssv.xoaSinhVien(maSvXoa);
                    break;
                case 3:
                    System.out.println("Danh sach sinh vien:");
                    dssv.hienThiDanhSach();
                    break;
                case 4:
                    System.out.print("Nhap ma sinh vien can tim: ");
                    int maSvTim = scanner.nextInt();
                    SinhVien svTim = dssv.timKiemSinhVien(maSvTim);
                    if (svTim != null) {
                        System.out.println("Thong tin sinh vien tim duoc:");
                        System.out.println(svTim.xuat());
                    } else {
                        System.out.println("Khong tim thay sinh vien voi ma so da cho.");
                    }
                    break;
                case 5:
                    System.out.println("Thong ke sinh vien theo gioi tinh:");
                    dssv.thongKeSinhVienTheoGioiTinh();
                    break;
                case 0:
                    System.out.println("Thoat chuong trinh.");
                    break;
                default:
                    System.out.println("Lua chon khong hop le. Vui long chon lai.");
            }
        }while (option != 0);

    }

}