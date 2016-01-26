

insert into customerrole values('Administrators',0,0,1,1,'Administrators'),
 ('Registered',0,0,1,1,'Registered'),
('Guests',0,0,1,1,'Guests')


  alter table Delivery add StartDate datetime not null
  alter table Delivery add EndDate datetime not null
  alter table Customer add DeliveryStartDate datetime not null default getdate()
  
   alter table Account add Mobile nvarchar(20) not null default '123'
   alter table Account add Validated bit not null default 1
   
   
    alter table Bill add IsFinal bit not null default 1
    
    
    alter table Account_Area_Mapping add DateModified datetime not null default getdate()