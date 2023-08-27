create database WEB_APP_Validation_Cliet_JS
use WEB_APP_Validation_Cliet_JS


create table student
(
sid int primary key identity,
name varchar(100),
email varchar(100),
password varchar(100),
cpassword varchar(100),
salary int,
age int,
mobileno int  -- not worked for large value
)
alter table Student alter column mobileno bigint

alter proc sp_Stdent_Insert

@name varchar(100), -- input parameter
@email varchar(100),
@password varchar(100),
@cpassword varchar(100),
@salary int,
@age int,
@mobileno bigint

as
begin
insert into student(name,email,password,cpassword,salary,age,mobileno)values(@name,@email,@password,@cpassword,@salary,@age,@mobileno)
end

select * from student
exec sp_Stdent_Insert 'Fahad','fahadsid8907@gmail.com','Fahad123','Fahad123',6500,23,789889988

create proc sp_Student_Get
as
begin
select * from Student
end

create proc sp_Student_delete
@id int
as
begin
delete from Student where sid=@id
end