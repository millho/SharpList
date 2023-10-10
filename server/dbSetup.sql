CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    houses (
        id INT AUTO_INCREMENT PRIMARY KEY,
        bedrooms INT NOT NULL,
        bathrooms INT NOT NULL,
        description VARCHAR(500),
        year INT NOT NULL,
        price INT NOT NULL,
        image VARCHAR(1000)
    ) default charset utf8mb4;