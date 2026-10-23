-- MySQL dump 10.13  Distrib 9.4.0, for macos15 (arm64)
--
-- Host: localhost    Database: stockflow_db
-- ------------------------------------------------------
-- Server version	9.4.0
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `Categories`
--

INSERT INTO `Categories` (`CategoryId`, `CategoryName`, `Description`) VALUES (1,'Electronics','Electronic devices and accessories');
INSERT INTO `Categories` (`CategoryId`, `CategoryName`, `Description`) VALUES (2,'Clothing','Apparel and fashion items');
INSERT INTO `Categories` (`CategoryId`, `CategoryName`, `Description`) VALUES (3,'Fitness','Gym and exercise equipment');
INSERT INTO `Categories` (`CategoryId`, `CategoryName`, `Description`) VALUES (4,'Office','Office supplies');
INSERT INTO `Categories` (`CategoryId`, `CategoryName`, `Description`) VALUES (5,'Home','Household products');

--
-- Dumping data for table `OrderItems`
--

INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (1,1,1,10,24.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (2,1,2,5,89.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (3,1,3,8,39.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (4,2,7,3,199.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (5,2,8,10,25.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (6,3,5,6,109.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (7,4,10,4,149.99);
INSERT INTO `OrderItems` (`OrderItemId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES (8,5,13,5,69.99);

--
-- Dumping data for table `Products`
--

INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (1,'Wireless Mouse','Logitech',24.99,40,1,1);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (2,'Mechanical Keyboard','Keychron',89.99,20,1,1);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (3,'USB-C Hub','Anker',39.99,30,1,1);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (4,'Bluetooth Speaker','JBL',79.99,15,1,1);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (5,'Running Shoes','Nike',109.99,25,2,3);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (6,'Cotton T-Shirt','Adidas',29.99,50,2,3);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (7,'Dumbbell Set','Bowflex',199.99,10,3,2);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (8,'Yoga Mat','Gaiam',25.99,35,3,6);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (9,'Resistance Bands','FitSimplify',18.99,45,3,6);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (10,'Office Chair','Hbada',149.99,12,4,4);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (11,'Notebook Pack','Five Star',12.99,60,4,4);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (12,'Desk Lamp','Philips',34.99,22,4,4);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (13,'Coffee Maker','Hamilton Beach',69.99,18,5,5);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (14,'Water Bottle','Contigo',19.99,55,5,5);
INSERT INTO `Products` (`ProductId`, `ProductName`, `Brand`, `Price`, `Quantity`, `CategoryId`, `SupplierId`) VALUES (15,'Storage Organizer','Iris',32.99,28,5,5);

--
-- Dumping data for table `PurchaseOrders`
--

INSERT INTO `PurchaseOrders` (`OrderId`, `SupplierId`, `OrderDate`, `Status`) VALUES (1,1,'2026-10-01','Delivered');
INSERT INTO `PurchaseOrders` (`OrderId`, `SupplierId`, `OrderDate`, `Status`) VALUES (2,2,'2026-10-03','Delivered');
INSERT INTO `PurchaseOrders` (`OrderId`, `SupplierId`, `OrderDate`, `Status`) VALUES (3,3,'2026-10-05','Pending');
INSERT INTO `PurchaseOrders` (`OrderId`, `SupplierId`, `OrderDate`, `Status`) VALUES (4,4,'2026-10-08','Processing');
INSERT INTO `PurchaseOrders` (`OrderId`, `SupplierId`, `OrderDate`, `Status`) VALUES (5,5,'2026-10-10','Pending');

--
-- Dumping data for table `Suppliers`
--

INSERT INTO `Suppliers` (`SupplierId`, `SupplierName`, `Email`, `Phone`) VALUES (1,'TechSource','sales@techsource.example','555-0101');
INSERT INTO `Suppliers` (`SupplierId`, `SupplierName`, `Email`, `Phone`) VALUES (2,'ActiveGear','contact@activegear.example','555-0102');
INSERT INTO `Suppliers` (`SupplierId`, `SupplierName`, `Email`, `Phone`) VALUES (3,'UrbanWear','sales@urbanwear.example','555-0103');
INSERT INTO `Suppliers` (`SupplierId`, `SupplierName`, `Email`, `Phone`) VALUES (4,'OfficeHub','info@officehub.example','555-0104');
INSERT INTO `Suppliers` (`SupplierId`, `SupplierName`, `Email`, `Phone`) VALUES (5,'HomePlus','support@homeplus.example','555-0105');
INSERT INTO `Suppliers` (`SupplierId`, `SupplierName`, `Email`, `Phone`) VALUES (6,'FitSupply','orders@fitsupply.example','555-0106');
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-10-23 17:47:15
