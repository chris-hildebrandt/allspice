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
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  FOREIGN KEY (recipeId) REFERENCES recipes(id),
  FOREIGN KEY (tagId) REFERENCES tags(id)
) default charset utf8 COMMENT '';

ALTER TABLE `steps`
add FOREIGN KEY (creatorId) REFERENCES accounts(id);

ALTER TABLE recipes
ADD COLUMN likes INT DEFAULT 0;

CREATE TABLE IF NOT EXISTS ingredients(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  quantity VARCHAR(100) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id),
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS steps(
  id INT AUTO_INCREMENT PRIMARY KEY,
  position INT NOT NULL,
  body VARCHAR(1000) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id),
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

INSERT INTO steps
(position, body, recipeId)
VALUES
(1, "Toss pumpkins, onions, and garlic with a bit of olive oil. Roast until everything is soft and has nice browned edges. Place the roasted items in a soup pot and turn to medium heat. Add 3/4 of the stock and simmer for up to 45 minutes, or until fully cooked. Put in a food processor and blend until smooth. Blend in small amounts of the goat cheese along with the cream if desired. Adjust thickness with the leftover stock. Add more cream if desired and finish seasoning with basil, salt, and pepper. If you add a filet of fish, pan-fry it separately with oil, salt and pepper, then add it to the soup.", 3);

CREATE TABLE IF NOT EXISTS favorites(
  id INT AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id),
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';

-- NOTE filter by likes
SELECT
  g.*,
  COUNT(m.id) AS popularity
  FROM games g
  LEFT JOIN matches m on m.gameId = g.id
  GROUP BY g.id
  ORDER BY popularity DESC;

INSERT INTO recipes
(picture, title, subtitle, description, creatorId)
  VALUES
  ("https://1.bp.blogspot.com/--b0Zif9i3aM/Uo1fMaOy4II/AAAAAAAAAhU/ar0ln_76mHU/s1600/yetosuperbsoup.jpg", "Yeto's Superb Pumpkin and Goat Cheese Soup", "From The Legend of Zelda: Twilight Princess game", "So I think I've done some of the more well-known fantasy foods, all of which have been sweet, so now it's time to change it up a bit and do a more obscure and savory dish. This one appeared in the newest Zelda game, Twilight Princess, in the Snowpeak temple as a soup that Yeto makes for his sick wife, Yeta. The soup, thanks to it's reekfish base, has healing properties that increase as Link finds more ingredients to add throughout the temple, namely a pumpkin and goat cheese from Link's hometown, Ordon. I took a basic pumpkin soup and made some modifications. I decided to make the fish stock and the filet optional because while I think pumpkin and goat cheese are a match made in heaven (or Hyrule), fish and pumpkin and goat cheese might seem like a strange mix for some. Fish or no fish, this soup makes for a perfect winter dinner!", "62fead19fda8e818d13a81db");

-- Get recipe, ingredients, account and tags by recipe ID

-- find fav. join recipe, 

-- get tags for recipe by recipeTag id
-- tags should be stored on the recipe with a rt id so they can be removed rt should have a r.id, an id, and 

INSERT INTO recipeTags
(tagId, recipeId)
VALUES
(27,3);

INSERT INTO favorites
(recipeId, accountId)
VALUES
(3, "62fead19fda8e818d13a81db");

INSERT INTO tags
(name)
VALUES
("Sandwich");
-- 
SELECT 
rt.*,
t.*
FROM recipeTags rt
JOIN tags t ON rt.tagId
JOIN recipes r ON rt.recipeId
WHERE rt.tagId = t.id AND rt.recipeId = "3";
-- get count of all likes for a recipeId
SELECT 
COUNT(accountId)
FROM recipes r
JOIN favorites f ON f.recipeId
WHERE f.recipeId = r.id AND r.id = "3";

SELECT *
FROM recipes r
JOIN accounts a ON a.id = r.creatorId
WHERE r.creatorId = "creatorId";

SELECT *
FROM ingredients i
WHERE i.recipeId = "recipeId";

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
