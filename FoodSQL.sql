USE MASTER;
GO

CREATE DATABASE Food
GO

USE Food
GO

CREATE TABLE FoodType(
 FoodTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 FoodTypeDescription VARCHAR(100) NOT NULL)
GO

CREATE TABLE FoodColour(
FoodColourID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FoodColourDescription VARCHAR(100) NOT NULL)
GO

CREATE TABLE Food(
FoodID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FoodDescription VARCHAR(100) NOT NULL,
FoodTypeID INT NOT NULL,
FoodColourID INT NOT NULL,
FOREIGN KEY (FoodTypeID) REFERENCES FoodType(FoodTypeID),
FOREIGN KEY (FoodColourID) REFERENCES FoodColour(FoodColourID))


INSERT INTO FoodType VALUES ('Dairy'),('Meat'),('Vegetables')
GO

INSERT INTO FoodColour VALUES ('Green'),('White'),('Brown'),('Red')
GO

INSERT INTO Food VALUES ('Cheddar Cheese',1,2),('Chicken',2,3),('Porterhouse Steak',2,4)
GO
