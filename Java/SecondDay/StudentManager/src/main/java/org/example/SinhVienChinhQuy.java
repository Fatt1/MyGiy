package org.example;
import java.util.Date;
import java.util.Scanner;

public class SinhVienChinhQuy extends SinhVien{
    private int DRL;

    public SinhVienChinhQuy(int maSv, String ho, String ten, int gioiTinh, Date ngaySinh, int DRL) {
        super(maSv, ho, ten, gioiTinh, ngaySinh);
        this.DRL = DRL;
    }

    public SinhVienChinhQuy() {
        super();
    }

    @Override
    public void nhapThongTin() {
        super.nhapThongTin();
        Scanner scanner = new java.util.Scanner(System.in);
        System.out.print("Nhap diem ren luyen: ");
        DRL = scanner.nextInt();
        this.DRL = DRL;
    }

    public int getDRL() {
        return DRL;
    }

    public void setDRL(int DRL) {
        this.DRL = DRL;
    }

    @Override
    public String xuat() {
        String info = super.xuat();
        info += ", Diem ren luyen: " + DRL;
        return  info;
    }
}
