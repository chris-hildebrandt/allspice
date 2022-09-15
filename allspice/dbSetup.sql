CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  picture VARCHAR(255),
  title VARCHAR(100) NOT NULL,
  subtitle VARCHAR(100),
  description VARCHAR(1000),
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS tags(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS recipeTags(
  id INT AUTO_INCREMENT PRIMARY KEY,
  tagId INT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id),
  FOREIGN KEY (tagId) REFERENCES tags(id)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS ingredients(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  quantity VARCHAR(100) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS steps(
  id INT AUTO_INCREMENT PRIMARY KEY,
  position INT NOT NULL,
  body VARCHAR(500) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS favorites(
  id INT AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id),
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';

INSERT INTO recipes
(picture, title, subtitle, description, creatorId)
  VALUES
  ("https://1.bp.blogspot.com/--b0Zif9i3aM/Uo1fMaOy4II/AAAAAAAAAhU/ar0ln_76mHU/s1600/yetosuperbsoup.jpg", "Yeto's Superb Pumpkin and Goat Cheese Soup", "From The Legend of Zelda: Twilight Princess game", "So I think I've done some of the more well-known fantasy foods, all of which have been sweet, so now it's time to change it up a bit and do a more obscure and savory dish. This one appeared in the newest Zelda game, Twilight Princess, in the Snowpeak temple as a soup that Yeto makes for his sick wife, Yeta. The soup, thanks to it's reekfish base, has healing properties that increase as Link finds more ingredients to add throughout the temple, namely a pumpkin and goat cheese from Link's hometown, Ordon. I took a basic pumpkin soup and made some modifications. I decided to make the fish stock and the filet optional because while I think pumpkin and goat cheese are a match made in heaven (or Hyrule), fish and pumpkin and goat cheese might seem like a strange mix for some. Fish or no fish, this soup makes for a perfect winter dinner!", "62fead19fda8e818d13a81db");

  
-- create Tables
-- create a link or tie between two tables that need to be used together with a foreign KEY
-- create model
-- controller
-- repo: after typing in the idbconnection you can autocomplete a ctor
-- services
-- register rpo and then the service in the startup. deepestlayer first!
-- when doing a join the order matters, SELECT a.*, b.* then from a JOIN b ON a.id = b.creatorId;
-- Query<A, B, A(this one determines the returned data type)>(sql, (a, b) this is a foreach that tells the loop each a is from A and each b is from B => { a.Creator = b; return a}) after this mess you need to make sue that your model has a place to store the joined information.
-- task is used for an async function
