-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 07, 2025 at 03:23 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `schoolrecords`
--

-- --------------------------------------------------------

--
-- Table structure for table `class_schedule`
--

CREATE TABLE `class_schedule` (
  `ScheduleId` int(11) NOT NULL,
  `Room` varchar(50) NOT NULL,
  `WeeklySchedule` varchar(100) NOT NULL,
  `CourseId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `class_schedule`
--

INSERT INTO `class_schedule` (`ScheduleId`, `Room`, `WeeklySchedule`, `CourseId`, `UserId`) VALUES
(2, 'LAB6', 'Monday 5:00pm - 7:00pm', 101, 2501),
(3, 'B306', 'Wednesday 1:00pm - 3:00pm', 101, 2501),
(4, 'LAB6', 'Thursday 1:00pm - 3:00pm', 110, 2501),
(5, 'LAB6', 'Wednesday 3:00pm - 5:00pm', 101, 2527),
(6, 'LAB6', 'Friday 5:00pm - 7:00pm', 101, 2528),
(7, 'B306', 'Friday 7:00am - 9:00am', 136, 2525),
(8, 'B306', 'Monday 7:00am - 9:00am', 101, 2530),
(9, 'B204', 'Tuesday 9:00am - 11:00am', 102, 2530),
(10, 'B202', 'Wednesday 1:00pm - 3:00pm', 105, 2530),
(11, 'MN323', 'Thursday 3:00pm - 5:00pm', 106, 2530),
(12, 'LAB6', 'Friday 5:00pm - 7:00pm', 107, 2530),
(13, 'LAB6', 'Monday 5:00pm - 7:00pm', 108, 2530),
(14, 'MN323', 'Wednesday 3:00pm - 5:00pm', 109, 2530),
(15, 'B306', 'Monday 7:00am - 9:00am', 101, 2531);

-- --------------------------------------------------------

--
-- Table structure for table `courseassignments`
--

CREATE TABLE `courseassignments` (
  `AssignmentID` int(11) NOT NULL,
  `CourseId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `courseassignments`
--

INSERT INTO `courseassignments` (`AssignmentID`, `CourseId`, `UserId`) VALUES
(1, 101, 2503),
(2, 102, 2503),
(4, 105, 2503),
(6, 106, 2503),
(9, 107, 2503),
(10, 108, 2503),
(11, 109, 2503),
(12, 110, 2503),
(13, 111, 2521),
(14, 112, 2521),
(15, 113, 2521),
(16, 114, 2521),
(17, 115, 2522),
(18, 116, 2522),
(19, 117, 2522),
(20, 118, 2522),
(21, 119, 2523),
(22, 120, 2523),
(23, 121, 2523),
(24, 122, 2523),
(25, 123, 2504),
(26, 124, 2521),
(27, 125, 2503),
(28, 126, 2523),
(29, 127, 2521),
(30, 128, 2512),
(31, 129, 2504),
(32, 130, 2503),
(33, 131, 2504),
(34, 132, 2522),
(35, 133, 2521),
(36, 134, 2512),
(37, 135, 2522),
(38, 136, 2521);

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE `courses` (
  `CourseId` int(11) NOT NULL,
  `CourseName` varchar(100) DEFAULT NULL,
  `CourseCode` varchar(20) DEFAULT NULL,
  `Credits` int(11) DEFAULT NULL,
  `SemesterOffered` varchar(50) DEFAULT NULL,
  `ProgramId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`CourseId`, `CourseName`, `CourseCode`, `Credits`, `SemesterOffered`, `ProgramId`) VALUES
(101, 'Programming 101', 'CS101-INTROPROG', 3, '1st Semester', 1),
(102, 'Data Structures', 'CS102-DATASTRUCT', 3, '1st Semester', 1),
(105, 'Information Management', 'IS105-INFOMGMT', 3, '1st Semester', 1),
(106, 'Introduction to Cybersecurity', 'CY106-CYBERSEC', 3, '1st Semester', 1),
(107, 'Quantitaive Methods', 'MA107-QUANTMETH', 3, '1st Semester', 1),
(108, 'Integrative Porgramming', 'CS108-INTEGPROG', 3, '1st Semester', 1),
(109, 'Introduction to AI', 'AI109-INTROAI', 3, '1st Semester', 1),
(110, 'Web Development', 'WD110-WEBDEV', 3, '1st Semester', 1),
(111, 'Introduction to Computer Engineering', 'CPE101', 3, '1st Semester', 3),
(112, 'Digital Logic Design', 'CPE102', 3, '2nd Semester', 3),
(113, 'Computer Architecture', 'CPE103', 3, '1st Semester', 3),
(114, 'Embedded Systems', 'CPE104', 3, '2nd Semester', 3),
(115, 'Electronics for CPE', 'CPE105', 3, '1st Semester', 3),
(116, 'Microprocessors and Microcontrollers', 'CPE106', 3, '2nd Semester', 3),
(117, 'Systems Programming', 'CPE107', 3, '1st Semester', 3),
(118, 'Capstone Design Project', 'CPE108', 3, '2nd Semester', 3),
(119, 'Programming Fundamentals', 'CS101', 3, '1st Semester', 2),
(120, 'Data Structures and Algorithms', 'CS102', 3, '2nd Semester', 2),
(121, 'Database Systems', 'CS103', 3, '1st Semester', 2),
(122, 'Computer Networks', 'CS104', 3, '2nd Semester', 2),
(123, 'Software Engineering', 'CS105', 3, '1st Semester', 2),
(124, 'Operating Systems', 'CS106', 3, '2nd Semester', 2),
(125, 'Web Development', 'CS107', 3, '1st Semester', 2),
(126, 'Artificial Intelligence', 'CS108', 3, '2nd Semester', 2),
(127, 'Introduction to Information Systems', 'IS101', 3, '1st Semester', 4),
(128, 'Business Process Management', 'IS102', 3, '2nd Semester', 4),
(129, 'Enterprise Systems', 'IS103', 3, '1st Semester', 4),
(130, 'Information Management', 'IS104', 3, '2nd Semester', 4),
(131, 'Systems Analysis and Design', 'IS105', 3, '1st Semester', 4),
(132, 'Project Management', 'IS106', 3, '2nd Semester', 4),
(133, 'IS Strategy and Governance', 'IS107', 3, '1st Semester', 4),
(134, 'IS Capstone Project', 'IS108', 3, '2nd Semester', 4),
(135, 'Ethics', 'ETH123', 3, NULL, NULL),
(136, 'PE', 'PATH123', 3, '1st Semester', 3);

-- --------------------------------------------------------

--
-- Table structure for table `enrollmentrecords`
--

CREATE TABLE `enrollmentrecords` (
  `EnrollmentId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Semester` varchar(50) DEFAULT NULL,
  `SchoolYear` varchar(50) DEFAULT NULL,
  `Status` enum('Active','Dropped') NOT NULL,
  `ProgramId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `enrollmentrecords`
--

INSERT INTO `enrollmentrecords` (`EnrollmentId`, `UserId`, `Semester`, `SchoolYear`, `Status`, `ProgramId`) VALUES
(1, 2525, '1st Semester', '2025-2026', 'Active', 3),
(2, 2526, '1st Semester', '2025-2026', 'Active', 2),
(3, 2527, '1st Semester', '2025-2026', 'Dropped', 1),
(4, 2528, '1st Semester', '2025-2026', 'Dropped', 1),
(5, 2529, '1st Semester', '2025-2026', 'Active', 2),
(6, 2530, '1st Semester', '2025-2026', 'Active', 1),
(7, 2531, '1st Semester', '2025-2026', 'Active', 1);

-- --------------------------------------------------------

--
-- Table structure for table `grades`
--

CREATE TABLE `grades` (
  `GradeID` int(11) NOT NULL,
  `PrelimGrade` decimal(5,2) DEFAULT NULL,
  `MidtermGrade` decimal(5,2) DEFAULT NULL,
  `FinalsGrade` decimal(5,2) DEFAULT NULL,
  `CourseId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Status` enum('Availble','Passed','Failed','Incomplete') DEFAULT NULL,
  `ProgramId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `grades`
--

INSERT INTO `grades` (`GradeID`, `PrelimGrade`, `MidtermGrade`, `FinalsGrade`, `CourseId`, `UserId`, `Status`, `ProgramId`) VALUES
(1, 90.00, 98.00, 91.00, 101, 2528, 'Passed', 1),
(2, 90.00, 89.00, 78.00, 102, 2528, 'Passed', 1),
(3, 86.00, 80.00, 91.00, 105, 2528, 'Passed', 1),
(4, 87.00, 98.00, 90.00, 106, 2528, 'Passed', 1),
(5, 85.00, 83.00, 89.00, 107, 2528, 'Passed', 1),
(6, 90.00, 90.00, 98.00, 108, 2528, 'Passed', 1),
(7, 90.00, 91.00, 93.00, 109, 2528, 'Passed', 1),
(8, 85.00, 92.00, 91.00, 110, 2528, 'Passed', 1),
(17, NULL, NULL, NULL, 119, 2529, '', 2),
(18, NULL, NULL, NULL, 121, 2529, '', 2),
(19, NULL, NULL, NULL, 123, 2529, '', 2),
(20, NULL, NULL, NULL, 125, 2529, '', 2),
(21, 80.00, 80.00, 90.00, 101, 2527, '', NULL),
(22, NULL, NULL, NULL, 101, 2530, '', NULL),
(23, NULL, NULL, NULL, 102, 2530, '', NULL),
(24, NULL, NULL, NULL, 105, 2530, '', NULL),
(25, NULL, NULL, NULL, 106, 2530, '', NULL),
(26, NULL, NULL, NULL, 107, 2530, '', NULL),
(27, NULL, NULL, NULL, 108, 2530, '', NULL),
(28, NULL, NULL, NULL, 109, 2530, '', NULL),
(29, NULL, NULL, NULL, 110, 2530, '', NULL),
(30, 95.00, 90.00, 90.00, 101, 2531, 'Passed', NULL),
(31, NULL, NULL, NULL, 102, 2531, '', NULL),
(32, NULL, NULL, NULL, 105, 2531, '', NULL),
(33, NULL, NULL, NULL, 106, 2531, '', NULL),
(34, NULL, NULL, NULL, 107, 2531, '', NULL),
(35, NULL, NULL, NULL, 108, 2531, '', NULL),
(36, NULL, NULL, NULL, 109, 2531, '', NULL),
(37, NULL, NULL, NULL, 110, 2531, '', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `programs`
--

CREATE TABLE `programs` (
  `ProgramId` int(11) NOT NULL,
  `ProgramName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `programs`
--

INSERT INTO `programs` (`ProgramId`, `ProgramName`) VALUES
(3, 'BS Computer Engineering'),
(2, 'BS Computer Science'),
(4, 'BS Information System'),
(1, 'BS Information Technology');

-- --------------------------------------------------------

--
-- Table structure for table `studentrecords`
--

CREATE TABLE `studentrecords` (
  `UserId` int(11) NOT NULL,
  `ContactNo` varchar(15) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `ProgramId` int(11) NOT NULL,
  `YearLevel` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `studentrecords`
--

INSERT INTO `studentrecords` (`UserId`, `ContactNo`, `Address`, `Age`, `ProgramId`, `YearLevel`) VALUES
(2501, '09171234567', '123 Main St', 20, 1, '1st Year'),
(2502, '09179876543', '456 Elm St', 19, 1, '1st Year'),
(2513, NULL, NULL, NULL, 3, '1st Year'),
(2514, NULL, NULL, NULL, 4, '1st Year'),
(2515, NULL, NULL, NULL, 4, '1st Year'),
(2516, NULL, NULL, NULL, 2, '2nd Year'),
(2517, NULL, NULL, NULL, 1, '1st Year'),
(2519, NULL, NULL, NULL, 3, '1st Year'),
(2520, NULL, NULL, NULL, 2, '2nd Year'),
(2525, NULL, NULL, NULL, 3, '1st Year'),
(2526, NULL, NULL, NULL, 2, '1st Year'),
(2527, NULL, NULL, NULL, 1, '1st Year'),
(2528, NULL, NULL, NULL, 1, '1st Year'),
(2529, NULL, NULL, NULL, 2, '1st Year'),
(2530, NULL, NULL, NULL, 1, '1st Year'),
(2531, NULL, NULL, NULL, 1, '1st Year');

-- --------------------------------------------------------

--
-- Table structure for table `terms`
--

CREATE TABLE `terms` (
  `TermId` int(11) NOT NULL,
  `TermName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `terms`
--

INSERT INTO `terms` (`TermId`, `TermName`) VALUES
(3, 'Finals'),
(2, 'Midterm'),
(1, 'Prelim');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserId` int(11) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `_Role` enum('Admin','Teacher','Student','AcademicStaff') DEFAULT NULL,
  `Status` enum('Active','Inactive') DEFAULT 'Active',
  `PermissionLevel` enum('Registrar','Dean') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserId`, `FirstName`, `LastName`, `Email`, `Password`, `_Role`, `Status`, `PermissionLevel`) VALUES
(2501, 'John', 'Doe', 'john.doe@student.com', 'password1', 'Student', 'Inactive', NULL),
(2502, 'Jane', 'Smith', 'jane.smith@student.com', 'password2', 'Student', 'Inactive', NULL),
(2503, 'Michael', 'Johnson', 'michael.johnson@teacher.com', 'password3', 'Teacher', 'Active', NULL),
(2504, 'Sarah', 'Williams', 'sarah.williams@teacher.com', 'password4', 'Teacher', 'Active', NULL),
(2505, 'Admin', 'User', 'admin@school.com', 'adminpass', 'Admin', 'Active', NULL),
(2506, 'Dean', 'Test', 'registrar@school.com', 'staffpass', 'AcademicStaff', 'Active', 'Dean'),
(2507, 'Registrar', 'Test', 'dean@school.com', 'staffpass', 'AcademicStaff', 'Active', 'Registrar'),
(2508, 'Traumerei', 'Lopobia', 'Tlp@example.com', '123456789', 'Student', 'Inactive', NULL),
(2509, 'Harry', 'Styles', 'HS@example.com', '123Harry', 'Student', 'Inactive', NULL),
(2510, 'Registrar', 'Test', 'asd@asd.com', 'asd123', 'AcademicStaff', 'Active', 'Registrar'),
(2511, 'Dean', 'Test', 'hindi@alam.com', 'asd123', 'AcademicStaff', 'Active', 'Dean'),
(2512, 'Anna', 'Reyes', 'anna.reyes@school.edu', '12345', 'Teacher', 'Active', NULL),
(2513, 'Pou', 'Bidaou', NULL, NULL, 'Student', 'Active', NULL),
(2514, 'Jimmy', 'Neutron', NULL, NULL, 'Student', 'Active', NULL),
(2515, 'Pou', 'Bidaou', 'PB@gmail.com', 'PB123', 'Student', 'Active', NULL),
(2516, 'Patrick', 'Rick', 'PR@gmail.com', 'PR123', 'Student', 'Active', NULL),
(2517, 'Pat', 'rick', NULL, NULL, 'Student', 'Active', NULL),
(2518, 'Lee', 'Val', 'lrv@gmail', '123', 'Student', 'Active', NULL),
(2519, 'Dogie', 'Tamago', 'Dg@gmail.com', '12345', 'Student', 'Active', NULL),
(2520, 'Albert', 'Einstein', 'AE@gmail.com', '12345', 'Student', 'Active', NULL),
(2521, 'Angelica', 'Torres', 'angelica.torres@school.edu', '12345', 'Teacher', 'Active', NULL),
(2522, 'Fatima', 'Gomez', 'fatima.gomez@school.edu', '12345', 'Teacher', 'Active', NULL),
(2523, 'Sopia', 'Navarro', 'sophia.navarro@school.edu', '12345', 'Teacher', 'Active', NULL),
(2525, 'Darren Jason', 'Watkins', 'DJW@gmail.com', '12345', 'Student', 'Active', NULL),
(2526, 'Gun', 'Park', 'GP@gmail.com', '12345', 'Student', 'Active', NULL),
(2527, 'Mafuyu', 'Sato', 'MS@gmail.com', '123', 'Student', 'Active', NULL),
(2528, 'Jiro', 'Valero', 'j@gmail.com', '123', 'Student', 'Active', NULL),
(2529, 'Lee', 'Valero', NULL, NULL, 'Student', 'Active', NULL),
(2530, 'Cheon', 'Ma', 'Cheon@gmail,com', '123', 'Student', 'Active', NULL),
(2531, 'Jan Dale', 'Piansay', '123', '123', 'Student', 'Active', NULL),
(2532, 'Urek', 'Mazino', 'MZ@gmail.com', '123', 'Teacher', 'Active', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users_backup`
--

CREATE TABLE `users_backup` (
  `UserId` int(11) NOT NULL DEFAULT 0,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `_Role` enum('Admin','Teacher','Student','AcademicStaff') DEFAULT NULL,
  `Status` enum('Active','Inactive') DEFAULT 'Active',
  `PermissionLevel` enum('Registrar','Dean') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `users_backup`
--

INSERT INTO `users_backup` (`UserId`, `FirstName`, `LastName`, `Email`, `Password`, `_Role`, `Status`, `PermissionLevel`) VALUES
(1, 'John', 'Doe', 'john.doe@student.com', 'password1', 'Student', 'Active', NULL),
(2, 'Jane', 'Smith', 'jane.smith@student.com', 'password2', 'Student', 'Active', NULL),
(3, 'Michael', 'Johnson', 'michael.johnson@teacher.com', 'password3', 'Teacher', 'Active', NULL),
(4, 'Sarah', 'Williams', 'sarah.williams@teacher.com', 'password4', 'Teacher', 'Active', NULL),
(5, 'Admin', 'User', 'admin@school.com', 'adminpass', 'Admin', 'Active', NULL),
(6, 'Registrar', 'Staff', 'registrar@school.com', 'staffpass', 'AcademicStaff', 'Active', 'Dean'),
(7, 'Dean', 'Staff', 'dean@school.com', 'staffpass', 'AcademicStaff', 'Active', 'Registrar'),
(8, 'Traumerei', 'Lopobia', 'Tlp@example.com', '123456789', 'Student', 'Active', NULL),
(9, 'Ben', 'Ten', 'Bt@example.com', '123Ben', 'Student', 'Active', NULL),
(10, 'John', 'Paul', 'asd@asd.com', 'asd123', 'AcademicStaff', 'Active', 'Registrar'),
(11, 'kahit', 'ano', 'hindi@alam.com', 'asd123', 'AcademicStaff', 'Active', 'Dean'),
(12, 'ewan', 'geh', 'asd', 'asd', 'Teacher', 'Active', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `class_schedule`
--
ALTER TABLE `class_schedule`
  ADD PRIMARY KEY (`ScheduleId`),
  ADD KEY `CourseId` (`CourseId`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `courseassignments`
--
ALTER TABLE `courseassignments`
  ADD PRIMARY KEY (`AssignmentID`),
  ADD KEY `fk_CourseId` (`CourseId`),
  ADD KEY `fk_UserId` (`UserId`);

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`CourseId`);

--
-- Indexes for table `enrollmentrecords`
--
ALTER TABLE `enrollmentrecords`
  ADD PRIMARY KEY (`EnrollmentId`),
  ADD KEY `fk_ProgramId` (`ProgramId`),
  ADD KEY `fk_enrollment_student` (`UserId`);

--
-- Indexes for table `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`GradeID`),
  ADD KEY `fk_grades_student` (`UserId`);

--
-- Indexes for table `programs`
--
ALTER TABLE `programs`
  ADD PRIMARY KEY (`ProgramId`),
  ADD UNIQUE KEY `ProgramName` (`ProgramName`);

--
-- Indexes for table `studentrecords`
--
ALTER TABLE `studentrecords`
  ADD PRIMARY KEY (`UserId`),
  ADD KEY `ProgramId` (`ProgramId`);

--
-- Indexes for table `terms`
--
ALTER TABLE `terms`
  ADD PRIMARY KEY (`TermId`),
  ADD UNIQUE KEY `TermName` (`TermName`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserId`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `class_schedule`
--
ALTER TABLE `class_schedule`
  MODIFY `ScheduleId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `courseassignments`
--
ALTER TABLE `courseassignments`
  MODIFY `AssignmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
  MODIFY `CourseId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=137;

--
-- AUTO_INCREMENT for table `enrollmentrecords`
--
ALTER TABLE `enrollmentrecords`
  MODIFY `EnrollmentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `grades`
--
ALTER TABLE `grades`
  MODIFY `GradeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT for table `programs`
--
ALTER TABLE `programs`
  MODIFY `ProgramId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `terms`
--
ALTER TABLE `terms`
  MODIFY `TermId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `class_schedule`
--
ALTER TABLE `class_schedule`
  ADD CONSTRAINT `class_schedule_ibfk_1` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`CourseId`) ON DELETE CASCADE,
  ADD CONSTRAINT `class_schedule_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE;

--
-- Constraints for table `courseassignments`
--
ALTER TABLE `courseassignments`
  ADD CONSTRAINT `courseassignments_ibfk_2` FOREIGN KEY (`CourseID`) REFERENCES `courses` (`CourseId`),
  ADD CONSTRAINT `fk_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`CourseId`),
  ADD CONSTRAINT `fk_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`);

--
-- Constraints for table `enrollmentrecords`
--
ALTER TABLE `enrollmentrecords`
  ADD CONSTRAINT `fk_ProgramId` FOREIGN KEY (`ProgramId`) REFERENCES `programs` (`ProgramId`);

--
-- Constraints for table `studentrecords`
--
ALTER TABLE `studentrecords`
  ADD CONSTRAINT `studentrecords_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`),
  ADD CONSTRAINT `studentrecords_ibfk_2` FOREIGN KEY (`ProgramId`) REFERENCES `programs` (`ProgramId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
