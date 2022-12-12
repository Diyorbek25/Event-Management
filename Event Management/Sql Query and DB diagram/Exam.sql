create database EventManagement

use EventManagement

CREATE TABLE Users (
  id integer identity PRIMARY KEY,
  full_name nvarchar(50),
  user_name nvarchar(50) unique not null,
  password nvarchar(50) not null,
  role integer
)
drop table Users
select * from Users

CREATE TABLE Rooms (
  id integer identity PRIMARY KEY,
  name varchar(50) unique,
  number_of_places integer not null,
)
drop table Rooms
select * from Rooms

CREATE TABLE Places (
  id integer identity PRIMARY KEY,
  room_id integer,
  user_id integer

  constraint FK_User_ID foreign key(user_id)
  references Users(id) on delete SET NULL,

	constraint FK_Room_ID foreign key(room_id)
	references Rooms(id) on delete SET NULL,
)
drop table Places
select * from Places

CREATE TABLE Events (
  id integer identity PRIMARY KEY,
  event_date datetime,
  name text not null,
  company_id integer,
  room_id integer

  constraint FK_Order_Room_ID foreign key(room_id)
  references Rooms(id) on delete SET NULL,

  constraint FK_Company_ID foreign key(company_id)
  references Users(id) on delete SET NULL
)
drop table Events
select * from Events


-- Registr
create procedure InsertUser
	@fullName as varchar(50),
	@userName as varchar(50),
	@password as varchar(50)
as
begin 
	insert into Users(full_name, user_name, password, role) values
	(@fullName, @userName, @password, 2)
	select * from Users where user_name = @userName
end;

execute InsertUser 
	'Diyorbek Abdumannobov',
	'diyor',
	'diyor1'


select * from Users where USER_NAME = 'diyor' and password = 'diyor1'

-- Xona yaratish
create procedure InsertRoom
	@name as varchar(50),
	@number_of_places integer
as
begin 
	insert into Rooms(name, number_of_places) values
	(@name, @number_of_places)

	declare @room_id INT;
	SET @room_id = (select id from Rooms where name = @name); 

	declare @stud_value INT;  
	SET @stud_value = 1;  
		WHILE @stud_value <= @number_of_places  
		BEGIN  
			insert into Places(room_id, user_id) values
			(@room_id, null)
			SET @stud_value = @stud_value + 1;
		end;
end;

execute InsertRoom 
	'PdpRoom',
	25


-- Role o'zgartirish
UPDATE Users
SET role = 1
WHERE id = 1;

-- Xona o'chirish
DELETE FROM Places WHERE room_id = 11;
DELETE FROM Rooms WHERE id = 11;

-- Joylar ro'yxati
create procedure GetPlaces
	@room_id as integer
as
begin 
	select * from Places where @room_id = @room_id
end;

execute GetPlaces
	12


-- Xonalar ro'yxati
create procedure GetRooms
	@room_id as integer
as
begin 
	select * from Rooms where @room_id = @room_id
end;

execute GetRooms
	12

-- Bo'sh xonalar ro'yxati
create procedure GetEmptyRooms
as
begin 
	select * from Rooms where id not in (select room_id from Events)
end;

execute GetEmptyRooms

select * from Users where role = 2