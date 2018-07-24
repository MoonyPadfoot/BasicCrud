-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 25, 2018 at 12:15 AM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 5.6.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbtest`
--

-- --------------------------------------------------------

--
-- Table structure for table `tabletest`
--

CREATE TABLE `tabletest` (
  `idtableTest` int(11) NOT NULL,
  `testName` varchar(70) NOT NULL,
  `testSurname` varchar(70) NOT NULL,
  `testAge` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tabletest`
--

INSERT INTO `tabletest` (`idtableTest`, `testName`, `testSurname`, `testAge`) VALUES
(1, 'hellow ', 'world', 7),
(2, 'yo ', 'yo', 0),
(2, 'yo ', 'yo', 0),
(4, 'fa ', 'sa', 7),
(6, 'albert', 'einstein', 10),
(7, 'shierna', 'hryn', 18),
(8, 'elon', 'musketeer', 1),
(5, 'mister ', 'Gato', 7),
(3, 'crowded', 'house', 20);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
