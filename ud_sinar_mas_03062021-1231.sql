-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 03, 2021 at 06:31 AM
-- Server version: 10.4.13-MariaDB
-- PHP Version: 7.4.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ud_sinar_mas`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertBarangSupplier` (IN `barang` VARCHAR(10), IN `supplier` VARCHAR(10), IN `beli` INT(10), IN `jumlah` INT(10))  NO SQL
INSERT INTO barang_supplier(`barang_id`, `supplier_id`, `harga_beli`, `harga_jual`, `jumlah_barang`) VALUES (barang, supplier, beli, beli + (beli * 2 / 100), jumlah)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPembelianBarangSupplier` (IN `id` VARCHAR(10), IN `bsid` VARCHAR(10), IN `jumlahpembelian` INT, IN `subtotal` INT)  NO SQL
INSERT INTO ud_sinar_mas.pembelian_barang_supplier(`pembelian_id`, `barang_supplier_id`, `jumlah_pembelian`, `sub_total`) VALUES (id, bsid, jumlahpembelian, subtotal)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPenjualan` (IN `customer` VARCHAR(255), IN `grand_total` VARCHAR(255), IN `tanggal` DATE, IN `pembayaran_id` VARCHAR(255), IN `total_bayar` INT, IN `tanggal_jatuh_tempo` DATE, IN `status` TINYINT(4))  NO SQL
INSERT INTO transaksi_penjualan (`customer_id`, `grand_total`, `tanggal_penjualan`, `pembayaran_id`, `total_bayar`, `tanggal_jatuh_tempo`, `status`) VALUES (customer, grand_total, tanggal, pembayaran_id, total_bayar, tanggal_jatuh_tempo, status)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPlnBrgSupp` (IN `penjualan_id` VARCHAR(255), IN `barang_id` VARCHAR(255), IN `subtotal` VARCHAR(255), IN `jumlah` VARCHAR(255))  NO SQL
Insert into penjualan_barang_supplier (`penjualan_id`, `barang_supplier_id`, `sub_total`, `jumlah_pemesanan`) VALUES (penjualan_id, barang_id, subtotal, jumlah)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateTransaksiPembelianNonTanggal` (IN `id` VARCHAR(10), IN `grand` INT(20))  NO SQL
UPDATE transaksi_pembelian SET `grand_total` = grand, `total_bayar` = grand, `status` = 1 , pembayaran_id = 'P2' WHERE `pembelian_id` = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateTransaksiPembelianTanggalOnly` (IN `id` VARCHAR(10), IN `pengiriman` DATE, IN `jatuhtempo` DATE)  NO SQL
UPDATE transaksi_pembelian SET tanggal_pembelian = pengiriman, tanggal_jatuh_tempo = jatuhtempo WHERE pembelian_id = id$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `auto_num` int(2) NOT NULL,
  `barang_id` varchar(3) NOT NULL,
  `nama_barang` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`auto_num`, `barang_id`, `nama_barang`) VALUES
(1, 'B1', 'HCL'),
(2, 'B2', 'Asam Sulfat'),
(3, 'B3', 'Kaporit Cair');

-- --------------------------------------------------------

--
-- Table structure for table `barang_supplier`
--

CREATE TABLE `barang_supplier` (
  `auto_num` int(2) NOT NULL,
  `barang_supplier_id` varchar(4) NOT NULL,
  `barang_id` varchar(3) NOT NULL,
  `supplier_id` varchar(3) NOT NULL,
  `harga_beli` int(13) NOT NULL,
  `harga_jual` int(13) NOT NULL,
  `jumlah_barang` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `barang_supplier`
--

INSERT INTO `barang_supplier` (`auto_num`, `barang_supplier_id`, `barang_id`, `supplier_id`, `harga_beli`, `harga_jual`, `jumlah_barang`) VALUES
(1, 'BS1', 'B1', 'S1', 9500, 9690, 8960),
(2, 'BS2', 'B1', 'S2', 9625, 9817, 45935),
(3, 'BS3', 'B3', 'S1', 7600, 7752, 15000),
(4, 'BS4', 'B2', 'S3', 10500, 10710, 14992),
(5, 'BS5', 'B3', 'S2', 7600, 7752, 15000),
(6, 'BS6', 'B1', 'S6', 9850, 10047, 30912),
(7, 'BS7', 'B1', 'S7', 9666, 9859, 20712),
(8, 'BS8', 'B1', 'S8', 9500, 9690, 24973),
(9, 'BS9', 'B1', 'S9', 9500, 9690, 0),
(10, 'BS10', 'B2', 'S9', 0, 9500, 10000),
(11, 'BS11', 'B1', 'S12', 9485, 9675, 10000),
(12, 'BS12', 'B1', 'S13', 9500, 9690, 10000),
(13, 'BS13', 'B1', 'S14', 9500, 9690, 1000),
(14, 'BS14', 'B1', 'S15', 9340, 9527, 37),
(15, 'BS15', 'B1', 'S16', 9600, 9792, 10000),
(16, 'BS16', 'B1', 'S17', 9500, 9690, 10000);

--
-- Triggers `barang_supplier`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDBarangSupplier` BEFORE INSERT ON `barang_supplier` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM barang_supplier);

SET new.barang_supplier_id = CONCAT('BS', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `auto_num` int(2) NOT NULL,
  `customer_id` varchar(3) DEFAULT NULL,
  `nama_customer` varchar(30) NOT NULL,
  `no_telepon` varchar(13) NOT NULL,
  `alamat` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`auto_num`, `customer_id`, `nama_customer`, `no_telepon`, `alamat`) VALUES
(1, 'C1', 'Bayu', '81234567', 'Jl. Kertajaya Indah no.2, Surabaya'),
(2, 'C2', 'William', '082345678', 'Jl. Manyar Kertoajo no.5, Sidoarjo'),
(3, 'C3', 'Calvin', '083456789', 'Jl. Dharmausada Indah no.8, Gresik'),
(4, 'C4', 'Ikhwan', '084567890', 'Jl. Mayjen Sungkono no.22, Surabaya'),
(5, 'C5', 'Hanjaya', '085678901', 'Jl. Ahmad Yani no.67, Malang'),
(6, 'C6', 'Alex', '086789012', 'Jl. Mojopahit Blok A-99, Kediri'),
(7, 'C7', 'Aldi', '087890123', 'Jl. Diponogoro 4/78, Surabaya'),
(11, 'C9', 'Hanjeye', '082184920394', 'Jalan mantan lama nomor 6969'),
(12, 'C12', 'Juju', '08210932012', 'Jalan juju'),
(13, 'C13', 'Indra', '082123456789', 'Jalan surabaya'),
(14, 'C14', 'Yosua', '082189289384', 'Jalan Dekat UC Nomor 1');

--
-- Triggers `customer`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDCustomer` BEFORE INSERT ON `customer` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM customer);

SET new.customer_id = CONCAT('C', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `pembayaran`
--

CREATE TABLE `pembayaran` (
  `auto_num` int(1) NOT NULL,
  `pembayaran_id` varchar(2) NOT NULL,
  `metode_pembayaran` varchar(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pembayaran`
--

INSERT INTO `pembayaran` (`auto_num`, `pembayaran_id`, `metode_pembayaran`) VALUES
(1, 'P1', 'Hutang'),
(2, 'P2', 'Cash');

-- --------------------------------------------------------

--
-- Table structure for table `pembelian_barang_supplier`
--

CREATE TABLE `pembelian_barang_supplier` (
  `auto_num` int(5) NOT NULL,
  `pembelian_barang_supplier_id` varchar(8) DEFAULT NULL,
  `pembelian_id` varchar(6) NOT NULL,
  `barang_supplier_id` varchar(4) NOT NULL,
  `jumlah_pembelian` int(6) NOT NULL,
  `sub_total` int(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pembelian_barang_supplier`
--

INSERT INTO `pembelian_barang_supplier` (`auto_num`, `pembelian_barang_supplier_id`, `pembelian_id`, `barang_supplier_id`, `jumlah_pembelian`, `sub_total`) VALUES
(37, 'YBS1', 'Y1', 'BS9', 10, 95000),
(38, 'YBS38', 'Y2', 'BS11', 10000, 94850000),
(40, 'YBS39', 'Y4', 'BS12', 10000, 95000000),
(42, 'YBS42', 'Y6', 'BS14', 10, 93400),
(43, 'YBS43', 'Y7', 'BS14', 27, 252180),
(44, 'YBS44', 'Y8', 'BS15', 10000, 96000000),
(45, 'YBS45', 'Y9', 'BS16', 10000, 95000000);

--
-- Triggers `pembelian_barang_supplier`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDPembelianBarangSupplier` BEFORE INSERT ON `pembelian_barang_supplier` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM pembelian_barang_supplier);

SET new.pembelian_barang_supplier_id = CONCAT('YBS', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `penjualan_barang_supplier`
--

CREATE TABLE `penjualan_barang_supplier` (
  `auto_num` int(5) NOT NULL,
  `penjualan_barang_supplier_id` varchar(8) DEFAULT NULL,
  `penjualan_id` varchar(6) DEFAULT NULL,
  `barang_supplier_id` varchar(4) DEFAULT NULL,
  `jumlah_pemesanan` int(6) DEFAULT NULL,
  `sub_total` int(13) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `penjualan_barang_supplier`
--

INSERT INTO `penjualan_barang_supplier` (`auto_num`, `penjualan_barang_supplier_id`, `penjualan_id`, `barang_supplier_id`, `jumlah_pemesanan`, `sub_total`) VALUES
(110, 'JBS1', 'J4', 'BS9', 1, 9690),
(111, 'JBS111', 'J5', 'BS8', 50, 484500),
(112, 'JBS112', 'J5', 'BS2', 5, 49085),
(113, 'JBS113', 'J6', 'BS9', 9, 87210),
(114, 'JBS114', 'J7', 'BS1', 15, 145350),
(115, 'JBS115', 'J8', 'BS2', 3, 29451),
(117, 'JBS116', 'J9', 'BS1', 1000, 9690000);

--
-- Triggers `penjualan_barang_supplier`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDPenjualanBarangSupplier` BEFORE INSERT ON `penjualan_barang_supplier` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM penjualan_barang_supplier);

SET new.penjualan_barang_supplier_id = CONCAT('JBS', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `auto_num` int(2) NOT NULL,
  `supplier_id` varchar(3) DEFAULT NULL,
  `nama_supplier` varchar(30) NOT NULL,
  `alamat` varchar(200) NOT NULL,
  `no_telepon` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`auto_num`, `supplier_id`, `nama_supplier`, `alamat`, `no_telepon`) VALUES
(1, 'S1', 'Sumanto', 'Jl. Kusuma bangsa, No. 8 Kediri', '081265737383'),
(2, 'S2', 'Andi Hari', 'Jl. Pattimura, No.12 Wonokromo', '083455882292'),
(3, 'S3', 'Masinnton', 'Jl. Dr. Soetomo, No.66 Gresik', '081637363778'),
(4, 'S4', 'Gissela Anasurbaningrum', 'Jl. Masmasban, No.22 Malang', '085286373882'),
(5, 'S5', 'Milea Ginting', 'Jl. Soekarno, No.01 Sidoarjo', '081627828673'),
(6, 'S6', 'Andi Fajar', 'Jalan Mantan', '082108292394'),
(7, 'S7', 'UD Sinar Gelap', 'Jalan Kegelapan Duniawi Nomor 69', '082188991122'),
(8, 'S8', 'UD Calvin Chandra', 'Jalan Obesitas Nomor 666', '082348920193'),
(9, 'S9', 'UD Hanjaya', 'Jalan Cahaya Baru Nomor 666', '082186866666'),
(10, 'S10', 'UD Catalina', 'Jalan Sebelahnya UD Calvin Chandra', '081666666666'),
(12, 'S11', 'UD Catalina Chandra', 'Jalan Rumahnya Dekat Calvin nomor 1', '082198928392'),
(13, 'S13', 'Rumah Tetangga', 'Anjay', '0891'),
(14, 'S14', 'Indra', 'Surabaya', '911'),
(15, 'S15', 'Jumanji', 'Jalanan', '911'),
(16, 'S16', 'BebekAngsa', 'Surabaya', '08219039203'),
(17, 'S17', 'UD Yayasan Kuliah', 'Jalan Semen', '1929302949');

--
-- Triggers `supplier`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDSupplier` BEFORE INSERT ON `supplier` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM supplier);

SET new.supplier_id = CONCAT('S', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `transaksi_pembelian`
--

CREATE TABLE `transaksi_pembelian` (
  `auto_num` int(5) NOT NULL,
  `pembelian_id` varchar(6) DEFAULT NULL,
  `pembayaran_id` varchar(3) DEFAULT NULL,
  `tanggal_pembelian` date DEFAULT NULL,
  `grand_total` int(13) DEFAULT NULL,
  `total_bayar` int(13) DEFAULT NULL,
  `tanggal_jatuh_tempo` date DEFAULT NULL,
  `status` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaksi_pembelian`
--

INSERT INTO `transaksi_pembelian` (`auto_num`, `pembelian_id`, `pembayaran_id`, `tanggal_pembelian`, `grand_total`, `total_bayar`, `tanggal_jatuh_tempo`, `status`) VALUES
(1, 'Y1', 'P2', '2021-05-29', 95000, 95000, '2021-05-29', 1),
(2, 'Y2', 'P2', '2021-05-31', 94850000, 94850000, '2021-05-31', 1),
(4, 'Y4', 'P2', '2021-06-05', 95000000, 95000000, '2021-06-05', 1),
(6, 'Y6', 'P2', '2021-05-31', 93400, 93400, '2021-05-31', 1),
(7, 'Y7', 'P2', '2021-05-31', 252180, 252180, '2021-05-31', 1),
(8, 'Y8', 'P2', '2021-05-31', 96000000, 96000000, '2021-05-31', 1),
(9, 'Y9', 'P2', '2021-06-03', 95000000, 95000000, '2021-06-03', 1);

--
-- Triggers `transaksi_pembelian`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDPembelian` BEFORE INSERT ON `transaksi_pembelian` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM transaksi_pembelian);

SET new.pembelian_id = CONCAT('Y', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `transaksi_penjualan`
--

CREATE TABLE `transaksi_penjualan` (
  `auto_num` int(5) NOT NULL,
  `penjualan_id` varchar(6) DEFAULT NULL,
  `customer_id` varchar(3) DEFAULT NULL,
  `grand_total` int(13) DEFAULT NULL,
  `tanggal_penjualan` date DEFAULT NULL,
  `pembayaran_id` varchar(2) DEFAULT NULL,
  `total_bayar` int(13) DEFAULT NULL,
  `tanggal_jatuh_tempo` date DEFAULT NULL,
  `status` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaksi_penjualan`
--

INSERT INTO `transaksi_penjualan` (`auto_num`, `penjualan_id`, `customer_id`, `grand_total`, `tanggal_penjualan`, `pembayaran_id`, `total_bayar`, `tanggal_jatuh_tempo`, `status`) VALUES
(3, 'J1', NULL, NULL, '2021-05-28', NULL, NULL, NULL, 0),
(4, 'J4', 'C5', 9690, '2021-05-29', 'P2', 9690, '2021-05-29', 1),
(5, 'J5', 'C13', 533585, '2021-06-30', 'P1', 50000, '2021-07-30', 0),
(6, 'J6', 'C13', 87210, '2021-06-17', 'P2', 87210, '2021-06-17', 1),
(7, 'J7', 'C3', 145350, '2021-05-31', 'P1', 2100, '2021-06-09', 0),
(8, 'J8', 'C3', 29451, '2021-05-05', 'P1', 0, '2021-05-20', 0),
(9, 'J9', 'C14', 9690000, '2021-06-09', 'P2', 9690000, '2021-06-09', 1);

--
-- Triggers `transaksi_penjualan`
--
DELIMITER $$
CREATE TRIGGER `GenerateIDPenjualan` BEFORE INSERT ON `transaksi_penjualan` FOR EACH ROW BEGIN

SET @id = (SELECT COALESCE(MAX(auto_num), 0) + 1 FROM transaksi_penjualan);

SET new.penjualan_id = CONCAT('J', @id);

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `auto_num` int(1) NOT NULL,
  `user_id` varchar(2) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `pin` int(4) NOT NULL,
  `user_level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`auto_num`, `user_id`, `nama`, `pin`, `user_level`) VALUES
(1, 'U1', 'Bayu', 4646, 0),
(2, 'U2', 'Calvin', 6969, 0),
(3, 'U3', 'Hanjaya', 6942, 0),
(4, 'U4', 'Ikhwan', 1234, 0),
(5, 'U5', 'William', 4321, 0),
(6, 'U6', 'Catalina', 6969, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `barang_supplier`
--
ALTER TABLE `barang_supplier`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `pembelian_barang_supplier`
--
ALTER TABLE `pembelian_barang_supplier`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `penjualan_barang_supplier`
--
ALTER TABLE `penjualan_barang_supplier`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `transaksi_pembelian`
--
ALTER TABLE `transaksi_pembelian`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `transaksi_penjualan`
--
ALTER TABLE `transaksi_penjualan`
  ADD PRIMARY KEY (`auto_num`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`auto_num`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `barang`
--
ALTER TABLE `barang`
  MODIFY `auto_num` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `barang_supplier`
--
ALTER TABLE `barang_supplier`
  MODIFY `auto_num` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `auto_num` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `pembayaran`
--
ALTER TABLE `pembayaran`
  MODIFY `auto_num` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `pembelian_barang_supplier`
--
ALTER TABLE `pembelian_barang_supplier`
  MODIFY `auto_num` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT for table `penjualan_barang_supplier`
--
ALTER TABLE `penjualan_barang_supplier`
  MODIFY `auto_num` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=118;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `auto_num` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `transaksi_pembelian`
--
ALTER TABLE `transaksi_pembelian`
  MODIFY `auto_num` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `transaksi_penjualan`
--
ALTER TABLE `transaksi_penjualan`
  MODIFY `auto_num` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `auto_num` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
