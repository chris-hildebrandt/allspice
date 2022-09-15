CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';



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
