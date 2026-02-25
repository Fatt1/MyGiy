package org.example;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public abstract class SinhVien {
    private int maSv;
    private String ho;
    private String ten;
    private  int gioiTinh;
    private Date ngaySinh;

    public SinhVien(int maSv, String ho, String ten, int gioiTinh, Date ngaySinh) {
        this.maSv = maSv;
        this.ho = ho;
        this.ten = ten;
        this.gioiTinh = gioiTinh;
        this.ngaySinh = ngaySinh;
    }

    public SinhVien() {

    }

    public void nhapThongTin() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ma sinh vien: ");
        maSv = scanner.nextInt();
        System.out.print("Nhap ho: ");
        ho = scanner.next();
        System.out.print("Nhap ten: ");
        ten = scanner.next();
        System.out.print("Nhap gioi tinh (0 - Nu, 1 - Nam):");
        gioiTinh = scanner.nextInt();
        System.out.print("Nhap ngay sinh (dd/MM/yyyy): ");
        String ngaySinhStr = scanner.next();
        try{
            ngaySinh = new SimpleDateFormat("dd/MM/yyyy").parse(ngaySinhStr);
        } catch (Exception e) {
            System.out.println("Loi dinh dang ngay sinh.");
        }

        this.maSv = maSv;
        this.ngaySinh = ngaySinh;
        this.ho = ho;
        this.ten = ten;
        this.gioiTinh = gioiTinh;

    }

    public String xuat() {
        String gt = (gioiTinh == 1) ? "Nam" : "Nu";
        String ngaySinhStr = new java.text.SimpleDateFormat("dd/MM/yyyy").format(ngaySinh);
        return "Ma SV: " + maSv + ", Ho: " + ho + ", Ten: " + ten + ", Gioi tinh: " + gt + ", Ngay sinh: " + ngaySinhStr;
    }

    public int getMaSv() {
        return maSv;
    }

    public String getHo() {
        return ho;
    }

    public void setHo(String ho) {
        this.ho = ho;
    }

    public String getTen() {
        return ten;
    }

    public void setTen(String ten) {
        this.ten = ten;
    }

    public int getGioiTinh() {
        return gioiTinh;
    }

    public void setGioiTinh(int gioiTinh) {
        this.gioiTinh = gioiTinh;
    }

    public Date getNgaySinh() {
        return ngaySinh;
    }

    public void setNgaySinh(Date ngaySinh) {
        this.ngaySinh = ngaySinh;
    }

}
