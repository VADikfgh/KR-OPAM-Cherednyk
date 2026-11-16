-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Ноя 16 2026 г., 20:04
-- Версия сервера: 10.4.28-MariaDB
-- Версия PHP: 8.1.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `autodealer_db`
--

-- --------------------------------------------------------

--
-- Структура таблицы `cars`
--

CREATE TABLE `cars` (
  `id` int(11) NOT NULL,
  `brand` varchar(50) NOT NULL,
  `model` varchar(50) NOT NULL,
  `year` int(11) NOT NULL,
  `vin` varchar(50) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `status` varchar(50) NOT NULL,
  `transmission` varchar(50) DEFAULT 'Механіка',
  `fuel_type` varchar(50) DEFAULT 'Бензин',
  `engine_volume` decimal(3,1) DEFAULT 2.0,
  `color` varchar(50) DEFAULT 'Не вказано',
  `horsepower` int(11) DEFAULT 0,
  `description` text DEFAULT NULL,
  `photo_path` varchar(255) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `cars`
--

INSERT INTO `cars` (`id`, `brand`, `model`, `year`, `vin`, `price`, `status`, `transmission`, `fuel_type`, `engine_volume`, `color`, `horsepower`, `description`, `photo_path`) VALUES
(2, 'Volkswagen', 'Passat', 2020, 'WVWZZZ3CZLE123456', 18500.00, 'Продано (Trade-In)', 'Механіка', 'Бензин', 2.0, 'Синій', 150, '', 'C:\\Users\\VADik fgh\\Desktop\\volkswagen_passat_cc_1037034.jpg'),
(4, 'Chevrolet', 'Aveo', 2008, 'KL1TD51Y5BK123456', 2999.00, 'В наявності', 'Механіка', 'Бензин', 2.0, 'Не вказано', 0, NULL, ''),
(5, 'Volkswagen', 'Golf', 2016, '1VWBA7AJ1GC023456', 12000.00, 'В наявності', 'Механіка', 'Бензин', 2.0, 'Не вказано', 0, NULL, ''),
(6, 'Toyota', 'Camry', 2018, '4T1BF1FK3JU123456', 19000.00, 'В наявності', 'Механіка', 'Бензин', 2.0, 'Не вказано', 0, NULL, ''),
(7, 'BMW', '5 Series', 2016, 'WBAFR71020G123456', 19000.00, 'В наявності', 'Механіка', 'Бензин', 2.0, 'Не вказано', 0, NULL, ''),
(8, 'Ford', 'Focus', 2017, '1FADP3K45HL123456', 8800.00, 'В наявності', 'Механіка', 'Бензин', 2.0, 'Не вказано', 0, NULL, ''),
(9, 'Hyundai', 'Sonata', 2017, '5NPE34AF6HH123456', 12499.00, 'В наявності', 'Механіка', 'Бензин', 2.0, 'Сірий', 140, '', '');

-- --------------------------------------------------------

--
-- Структура таблицы `test_drives`
--

CREATE TABLE `test_drives` (
  `id` int(11) NOT NULL,
  `car_id` int(11) NOT NULL,
  `car_info` varchar(255) NOT NULL,
  `test_date` date NOT NULL,
  `test_time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `test_drives`
--

INSERT INTO `test_drives` (`id`, `car_id`, `car_info`, `test_date`, `test_time`) VALUES
(3, 6, 'Toyota Camry', '2026-11-10', '20:46:26');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `test_drives`
--
ALTER TABLE `test_drives`
  ADD PRIMARY KEY (`id`),
  ADD KEY `car_id` (`car_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `cars`
--
ALTER TABLE `cars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `test_drives`
--
ALTER TABLE `test_drives`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `test_drives`
--
ALTER TABLE `test_drives`
  ADD CONSTRAINT `test_drives_ibfk_1` FOREIGN KEY (`car_id`) REFERENCES `cars` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
