using System;
using System.Data.SqlClient;

namespace Tgs2_20200140076_TIB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Untuk Membuat Tabel");
                    Console.WriteLine("2. Untuk Memasukkan Data");
                    Console.WriteLine("3. Keluar");
                    Console.Write("\nPilih (1-3): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                db.Create_Tabel();
                            }
                            break;
                        case '2':
                            {
                                db.InsertData();
                            }
                            break;
                        case '3':
                            return;
                        default:
                            {
                                Console.WriteLine("Berhasil");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Selesai");
                    break;
                }
            }
        }

        class Database
        {
            public string connectionStr = "data source=DESKTOP-CRFOF2E;" +
                "database=Prizandeva;User ID=sa;Password=Zandev135790";
            public void Connection()
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();
                    Console.WriteLine("Connection Succesfully");
                }
            }
            public void Create_Tabel()
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(connectionStr);
                    con.Open();

                    SqlCommand cm = new SqlCommand(
                        //Membuat Tabel Apoteker
                        "create table Apoteker " +
                        "(Id_Apoteker char(15) not null primary key, " +
                        "Nama_Apoteker varchar(50) not null, " +
                        "Jk_Apoteker char(1) not null, " +
                        "Alamat_Apoteker varchar(50) not null," +
                        "No_TeleponApoteker char(15) not null)"
                        //Membuat Tabel Supplier
                        + "create table Supplier " +
                        "(Id_Supplier char(15) not null primary key, " +
                        "Nama_Supplier varchar(50) not null, " +
                        "Jk_Supplier char(1) not null, " +
                        "Alamat_Supplier varchar(50) not null," +
                        "No_TeleponSupplier char(15) not null)"
                        //Membuat Tabel Karyawan
                        + "create table Karyawan " +
                        "(Id_Karyawan char(15) not null primary key, " +
                        "Nama_Karyawan varchar(50) not null, " +
                        "Jk_Karyawan char(1) not null, " +
                        "Alamat_Karyawan varchar(50) not null, " +
                        "Status_Karyawan char(15) not null, " +
                        "No_TeleponKaryawan char(15) not null)"
                        //Membuat Tabel Pembeli
                        + "create table Pembeli " +
                        "(Id_Pembeli char(15) not null primary key, " +
                        "Nama_Pembeli varchar(50) not null, " +
                        "No_TeleponPembeli char(15) not null, " +
                        "Email_Pembeli varchar(50) not null, " +
                        "Alamat_Pembeli varchar(50) not null)"
                        //Membuat Tabel Obat
                        + "create table Obat " +
                        "(Id_Obat char(15) not null primary key, " +
                        "Nama_Obat varchar(50) not null, " +
                        "Stock_Obat int not null, " +
                        "Harga_Obat money not null, " +
                        "Jenis_Obat varchar(50) not null, " +
                        "Id_Supplier char(15) FOREIGN KEY REFERENCES Supplier(Id_Supplier) not null, " +
                        "Id_Apoteker char(15) FOREIGN KEY REFERENCES Apoteker(Id_Apoteker) not null, " +
                        "Id_Karyawan char(15) FOREIGN KEY REFERENCES Karyawan(Id_Karyawan) not null, " +
                        "Id_Pembeli char(15) FOREIGN KEY REFERENCES Pembeli(Id_Pembeli) not null)"
                        //Membuat Tabel Faktur Penjualan
                        + "create table Faktur_Penjualan " +
                        "(Id_FakturPenjualan char(15) not null primary key, " +
                        "Tanggal date not null, " +
                        "Waktu time not null, " +
                        "Qty_Total int not null, " +
                        "Total_Harga money not null, " +
                        "Total_Bayar money not null, " +
                        "Pajak money not null, " +
                        "Id_Pembeli char(15) FOREIGN KEY REFERENCES Pembeli(Id_Pembeli) not null, " +
                        "Id_Karyawan char(15) FOREIGN KEY REFERENCES Karyawan(Id_Karyawan) not null)"
                        //Membuat Tabel Faktur Supplier
                        + "create table Faktur_Supplier " +
                        "(Id_FakturSupplier char(15) not null primary key, " +
                        "Tanggal date not null, " +
                        "Waktu time not null, " +
                        "Jumlah int not null, " +
                        "Total_Harga money not null, " +
                        "Total_Bayar money not null, " +
                        "Pajak money not null, " +
                        "Id_Supplier char(15) FOREIGN KEY REFERENCES Supplier(Id_Supplier) not null, " +
                        "Id_Obat char(15) FOREIGN KEY REFERENCES Obat(Id_Obat) not null)", con);
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Tabel sukses dibuat!");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                    Console.ReadKey();
                }
                finally
                {
                    con.Close();
                }
            }

            public void InsertData()
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(connectionStr);
                    con.Open();

                    SqlCommand cm = new SqlCommand(
                        //Memasukkan data Tabel Apoteker
                        "insert into Apoteker " +
                        "(Id_Apoteker, " +
                        "Nama_Apoteker, " +
                        "Jk_Apoteker, " +
                        "Alamat_Apoteker, " +
                        "No_TeleponApoteker) values " +
                        "('01','Zeus','L','Papua','08511111111')" 
                        + "insert into Apoteker " +
                        "(Id_Apoteker, " +
                        "Nama_Apoteker, " +
                        "Jk_Apoteker, " +
                        "Alamat_Apoteker, " +
                        "No_TeleponApoteker) values " +
                        "('02','Poseidon','L','Yogyakarta','08511111112')"
                        + "insert into Apoteker " +
                        "(Id_Apoteker, " +
                        "Nama_Apoteker, " +
                        "Jk_Apoteker, " +
                        "Alamat_Apoteker, " +
                        "No_TeleponApoteker) values " +
                        "('03','Hades','P','Bandung','08511111113')"
                        + "insert into Apoteker " +
                        "(Id_Apoteker, " +
                        "Nama_Apoteker, " +
                        "Jk_Apoteker, " +
                        "Alamat_Apoteker, " +
                        "No_TeleponApoteker) values " +
                        "('04','Hera','L','Bali','08511111114')"
                        + "insert into Apoteker " +
                        "(Id_Apoteker, " +
                        "Nama_Apoteker, " +
                        "Jk_Apoteker, " +
                        "Alamat_Apoteker, " +
                        "No_TeleponApoteker) values " +
                        "('05','Ares ','L','Lombok','08511111115')"

                        //Memasukkan data Tabel Supplier
                        + "insert into Supplier " +
                        "(Id_Supplier, " +
                        "Nama_Supplier, " +
                        "Jk_Supplier, " +
                        "Alamat_Supplier, " +
                        "No_TeleponSupplier) values " +
                        "('001','Hermes','L','Tangsel','08511111116')"
                        + "insert into Supplier " +
                        "(Id_Supplier, " +
                        "Nama_Supplier, " +
                        "Jk_Supplier, " +
                        "Alamat_Supplier, " +
                        "No_TeleponSupplier) values " +
                        "('002','Aphrodite','L','Tanggerang','08511111117')"
                        + "insert into Supplier " +
                        "(Id_Supplier, " +
                        "Nama_Supplier, " +
                        "Jk_Supplier, " +
                        "Alamat_Supplier, " +
                        "No_TeleponSupplier) values " +
                        "('003','Athena','p','Bali','08511111118')"
                        + "insert into Supplier " +
                        "(Id_Supplier, " +
                        "Nama_Supplier, " +
                        "Jk_Supplier, " +
                        "Alamat_Supplier, " +
                        "No_TeleponSupplier) values " +
                        "('004','Apollo','P','Aceh','08511111118')"
                        + "insert into Supplier " +
                        "(Id_Supplier, " +
                        "Nama_Supplier, " +
                        "Jk_Supplier, " +
                        "Alamat_Supplier, " +
                        "No_TeleponSupplier) values " +
                        "('005','Artemis','P','NTT','08511111119')"

                        //Memasukkan data Tabel Karyawan
                        + "insert into Karyawan " +
                        "(Id_Karyawan, " +
                        "Nama_Karyawan, " +
                        "Jk_Karyawan, " +
                        "Alamat_Karyawan, " +
                        "Status_Karyawan, " +
                        "No_TeleponKaryawan) values " +
                        "('0001','Demeter','P','Bali','Aktif','085111111110')"
                        + "insert into Karyawan " +
                        "(Id_Karyawan, " +
                        "Nama_Karyawan, " +
                        "Jk_Karyawan, " +
                        "Alamat_Karyawan, " +
                        "Status_Karyawan, " +
                        "No_TeleponKaryawan) values " +
                        "('0002','Hephaestus','P','Sulawesi','Tidak Aktif','085111111111')"
                        + "insert into Karyawan " +
                        "(Id_Karyawan, " +
                        "Nama_Karyawan, " +
                        "Jk_Karyawan, " +
                        "Alamat_Karyawan, " +
                        "Status_Karyawan, " +
                        "No_TeleponKaryawan) values " +
                        "('0003','Izanami','P','Solo','Aktif','085111111112')"
                        + "insert into Karyawan " +
                        "(Id_Karyawan, " +
                        "Nama_Karyawan, " +
                        "Jk_Karyawan, " +
                        "Alamat_Karyawan, " +
                        "Status_Karyawan, " +
                        "No_TeleponKaryawan) values " +
                        "('0004','Izanagi','L','GunungKidul','Aktif','085111111113')"
                        + "insert into Karyawan " +
                        "(Id_Karyawan, " +
                        "Nama_Karyawan, " +
                        "Jk_Karyawan, " +
                        "Alamat_Karyawan, " +
                        "Status_Karyawan, " +
                        "No_TeleponKaryawan) values " +
                        "('0005','Ebisu','L','Semarang','Tidak Aktif','085111111114')"

                        //Memasukkan data Tabel Pembeli
                        + "insert into Pembeli " +
                        "(Id_Pembeli, " +
                        "Nama_Pembeli, " +
                        "No_TeleponPembeli, " +
                        "Email_Pembeli, " +
                        "Alamat_Pembeli) values " +
                        "('00001','Kagutsuchi','085111111115','Koti@gmail.com','Kaliurang')"
                        + "insert into Pembeli " +
                        "(Id_Pembeli, " +
                        "Nama_Pembeli, " +
                        "No_TeleponPembeli, " +
                        "Email_Pembeli, " +
                        "Alamat_Pembeli) values " +
                        "('00002','Amaterasu','085111111116','vyarbuda@gmail.com','Solo Baru')"
                        + "insert into Pembeli " +
                        "(Id_Pembeli, " +
                        "Nama_Pembeli, " +
                        "No_TeleponPembeli, " +
                        "Email_Pembeli, " +
                        "Alamat_Pembeli) values " +
                        "('00003','Tsukuyomi','085111111117','padma@gmail.com','Kota Baru')"
                        + "insert into Pembeli " +
                        "(Id_Pembeli, " +
                        "Nama_Pembeli, " +
                        "No_TeleponPembeli, " +
                        "Email_Pembeli, " +
                        "Alamat_Pembeli) values " +
                        "('00004','Susanoo','085111111118','Hansa@gmail.com','Sleman')"
                        + "insert into Pembeli " +
                        "(Id_Pembeli, " +
                        "Nama_Pembeli, " +
                        "No_TeleponPembeli, " +
                        "Email_Pembeli, " +
                        "Alamat_Pembeli) values " +
                        "('00005','Raijin ','085111111119','Hara@gmail.com','Bantul')"

                        //Memasukkan data Tabel Obat
                        + "insert into Obat " +
                        "(Id_Obat, " +
                        "Id_Supplier, " +
                        "Id_Apoteker, " +
                        "Id_Karyawan, " +
                        "Id_Pembeli, " +
                        "Nama_Obat, " +
                        "Stock_Obat, " +
                        "Harga_Obat, " +
                        "Jenis_Obat) values " +
                        "('000001','001','01','0001','00001','Acarbose','10','5000,00','Asam')"
                        + "insert into Obat " +
                        "(Id_Obat, " +
                        "Id_Supplier, " +
                        "Id_Apoteker, " +
                        "Id_Karyawan, " +
                        "Id_Pembeli, " +
                        "Nama_Obat, " +
                        "Stock_Obat, " +
                        "Harga_Obat, " +
                        "Jenis_Obat) values " +
                        "('000002','002','02','0002','00002','Albendazole','20','10000,00','Basa')"
                        + "insert into Obat " +
                        "(Id_Obat, " +
                        "Id_Supplier, " +
                        "Id_Apoteker, " +
                        "Id_Karyawan, " +
                        "Id_Pembeli, " +
                        "Nama_Obat, " +
                        "Stock_Obat, " +
                        "Harga_Obat, " +
                        "Jenis_Obat) values " +
                        "('000003','003','03','0003','00003','Apixaban','30','20000,00','Asam')"
                        + "insert into Obat " +
                        "(Id_Obat, " +
                        "Id_Supplier, " +
                        "Id_Apoteker, " +
                        "Id_Karyawan, " +
                        "Id_Pembeli, " +
                        "Nama_Obat, " +
                        "Stock_Obat, " +
                        "Harga_Obat, " +
                        "Jenis_Obat) values " +
                        "('000004','004','04','0004','00004','Alfentanil','40','30000,00','Asam')"
                        + "insert into Obat " +
                        "(Id_Obat, " +
                        "Id_Supplier, " +
                        "Id_Apoteker, " +
                        "Id_Karyawan, " +
                        "Id_Pembeli, " +
                        "Nama_Obat, " +
                        "Stock_Obat, " +
                        "Harga_Obat, " +
                        "Jenis_Obat) values " +
                        "('000005','005','05','0005','00005','Acyclovir Topikal','50','40000,00','Basa')"

                        //Memasukkan data Tabel Faktur Penjualan
                        + "insert into Faktur_Penjualan " +
                        "(Id_FAKTURPenjualan, " +
                        "Id_Pembeli, " +
                        "Id_Karyawan, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Qty_Total, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('0000001','00001','0001','01-04-2022','1:40:53','10','10000,00', '11000,00', '1000,00')"
                        + "insert into faktur_Penjualan " +
                        "(Id_FakturPenjualan, " +
                        "Id_Pembeli, " +
                        "Id_Karyawan, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Qty_Total, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('0000002','00002','0002','02-04-2022','2:40:53','10','20000,00', '21000,00', '1000,00')"
                        + "insert into Faktur_Penjualan " +
                        "(Id_FakturPenjualan, " +
                        "Id_Pembeli, " +
                        "Id_Karyawan, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Qty_Total, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('0000003','00003','0003','03-04-2022','3:40:53','10','30000,00', '31000,00', '1000,00')"
                        + "insert into Faktur_Penjualan " +
                        "(Id_FakturPenjualan, " +
                        "Id_Pembeli, " +
                        "Id_Karyawan, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Qty_Total, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('0000004','00004','0004','04-04-2022','4:40:53','10','400000,00', '41000,00', '1000,00')"
                        + "insert into Faktur_Penjualan " +
                        "(Id_FakturPenjualan, " +
                        "Id_Pembeli, " +
                        "Id_Karyawan, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Qty_Total, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('0000005','00005','0005','05-04-2022','5:40:53','10','50000,00', '51000,00', '100000,00')"

                        //Memasukkan data Tabel Faktur Supplier
                        + "insert into Faktur_Supplier " +
                        "(Id_FakturSupplier, " +
                        "Id_Supplier, " +
                        "Id_Obat, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Jumlah, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('00000001','001','000001','01-04-2022','11:40:53','10','1000000,00', '1100000,00', '100000,00')"
                        + "insert into Faktur_Supplier " +
                        "(Id_FakturSupplier, " +
                        "Id_Supplier, " +
                        "Id_Obat, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Jumlah, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('00000002','002','000002','02-04-2022','12:40:53','10','2000000,00', '2100000,00', '100000,00')"
                        + "insert into Faktur_Supplier " +
                        "(Id_FakturSupplier, " +
                        "Id_Supplier, " +
                        "Id_Obat, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Jumlah, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('00000003','003','000003','03-04-2022','13:40:53','10','3000000,00', '3100000,00', '100000,00')"
                        + "insert into Faktur_Supplier " +
                        "(Id_FakturSupplier, " +
                        "Id_Supplier, " +
                        "Id_Obat, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Jumlah, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('00000004','004','000004','04-04-2022','14:40:53','10','4000000,00', '4100000,00', '100000,00')"
                        + "insert into Faktur_Supplier " +
                        "(Id_FakturSupplier, " +
                        "Id_Supplier, " +
                        "Id_Obat, " +
                        "Tanggal, " +
                        "Waktu, " +
                        "Jumlah, " +
                        "Total_Harga, " +
                        "Total_Bayar, " +
                        "Pajak) values " +
                        "('00000005','005','000005','05-04-2022','15:40:53','10','5000000,00', '5100000,00', '100000,00')", con);
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Data sukses dibuat!");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops, sepertinya ada yang salah di Memasukkan data. " + e);
                    Console.ReadKey();
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}