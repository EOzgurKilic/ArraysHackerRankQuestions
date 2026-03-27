Create database WorkBoard;

use WorkBoard;
create schema Brands;
create table WorkBoard.Brands.BrandTypes (
    id_BrandType int primary key identity (1,1),
    Brand_Name nvarchar(50) not null,
    Tax_Number int,
    Office_Address varchar(100),
    created_At datetime,
)
insert into WorkBoard.Brands.BrandTypes (Brand_Name, Tax_Number, Office_Address, created_At)values
    ('KFC', 134653445, '12 Baker Street, London, UK', '2025-01-21'),
    ('MCDonalds', 234134643, '88 Orchard Road, Singapore', '2023-05-15'),
    ('Burger King', 123524867, '34 Istiklal Ave, Istanbul, TR', '2024-12-11')

create table WorkBoard.Brands.Branches (
            id_Branch int primary key identity (1,1),
            Branch_Name nvarchar(50) not null,
            Branch_Address varchar(100),
            Branch_Phone varchar(11),
            created_at datetime,
            id_BrandType int not null,
            foreign key (id_BrandType) references WorkBoard.Brands.BrandTypes(id_BrandType)
)

INSERT INTO WorkBoard.Brands.Branches (Branch_Name, Branch_Address, Branch_Phone, created_at) VALUES
    ('Downtown Branch', '123 Main St, New York, NY',       '12125550101', '2021-03-15 09:00:00'),
    ('Westside Branch', '456 Sunset Blvd, Los Angeles, CA','13105550182', '2021-06-22 10:30:00'),
    ('Northgate Branch','789 North Ave, Chicago, IL',      '13125550134', '2022-01-10 08:45:00'),
    ('Eastwood Branch', '321 East Rd, Houston, TX',        '17135550167', '2022-04-05 11:00:00'),
    ('Lakeside Branch',   '654 Lake Dr, Chicago, IL',        '13125550198', '2022-07-19 14:15:00'),
    ('Hillview Branch',   '987 Hill Rd, Phoenix, AZ',        '16025550143', '2022-09-30 09:30:00'),
    ('Riverside Branch',  '147 River Ln, Philadelphia, PA',  '12155550176', '2023-02-14 13:00:00'),
    ('Sunset Branch',     '258 Sunset St, San Antonio, TX',  '12105550112', '2023-05-08 10:00:00'),
    ('Parkway Branch',    '369 Park Ave, San Diego, CA',     '16195550155', '2023-08-21 15:45:00'),
    ('Central Branch',    '741 Central Blvd, Dallas, TX',    '12145550189', '2024-01-03 08:00:00');



select * from Brands.brandtypes;
select * from Brands.Branches;


update brands.branches set id_brandtype = 3 where id_branch < 12 AND id_branch > 7;

create table #tempTable (id_branch int, Branch_address varchar(100))
insert into #tempTable (id_branch, Branch_address)
select id_branch, branch_address from brands.branches

select * from #tempTable;

select id_branch, branch_name
into #temptable2
from Brands.Branches

select * from #tempTable2;
