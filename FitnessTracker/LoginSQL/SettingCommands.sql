Use LoginWPF
Go


Create Procedure User_ID
AS
Select * From UserID
Go

alter Procedure User_ID
(@UserId varchar(50),  
@word varchar(50))  
as  
begin
select count(*) from UserID where UserName=@UserId and word=@word  
End 

insert into UserID(userName,word)
	values ('tester2017','tester2017!') 