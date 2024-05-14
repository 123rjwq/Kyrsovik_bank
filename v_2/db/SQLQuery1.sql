create database mobile_bank_rom_kir

use mobile_bank_rom_kir

create table client(
	id_client int identity(1,1) not null primary key,
	client_last_name nvarchar(50) not null,
	client_first_name nvarchar(50) not null,
	client_middle_name nvarchar(50) not null,
	client_gender nvarchar(3) not null,
	client_password nvarchar(256) not null,
	client_email nvarchar(50) not null,
	client_phone_number nchar(13) not null,
)

create table bank_card(
	id_bank_card int identity(1,1) not null primary key,
	bank_card_type nvarchar(50) not null,
	bank_card_number nvarchar(16) not null,
	bank_card_cvv_code nvarchar(3) not null,
	bank_card_balance money default 0,
	bank_card_currency nvarchar(10) not null,
	bank_card_paymentSystem nvarchar(50) not null,
	bank_card_date date not null,
	bank_card_pin int not null,
)

alter table bank_card add id_client int
alter table bank_card add foreign key (id_client) references dbo.Client(id_client) on delete no action on update cascade

create table transactions(
	id_transaction int identity(1,1) not null primary key,
	transaction_type varchar(50) not null,
	transaction_destination varchar(200) not null,
	transaction_date date not null,
	transaction_number nchar(50),
	transaction_value money,
)

alter table transactions add id_bank_card int
alter table transactions add foreign key (id_bank_card) references dbo.bank_card(id_bank_card) on delete no action on update cascade

create table credits(
	id_credit int identity(1,1) not null primary key,
	credit_total_sum money not null,
	credit_sum money not null,
	credit_date date not null,
	credit_status bit not null default 0,
	repayment_date date,
	repayment_sum money,
)

alter table credits add id_bank_card int
alter table credits add foreign key (id_bank_card) references dbo.bank_card(id_bank_card) on delete no action on update cascade

create table clientServices (
	id_service int identity(1,1) not null primary key,
	serviceName varchar(100) not null,
	serviceBalance money default 0,
	serviceType varchar(100) not null
)

create table clientPersonalAccount (
	id_personal_account int identity(1,1) not null primary key,
	personal_account varchar(10) not null
)

alter table clientPersonalAccount add id_service int
alter table clientPersonalAccount add foreign key (id_service) references dbo.clientServices(id_service) on delete no action on update cascade

alter table clientPersonalAccount add id_client int
alter table clientPersonalAccount add foreign key (id_client) references dbo.Client(id_client) on delete no action on update cascade

select * from client
select * from bank_card
select * from credits
select * from transactions
select * from clientServices
select * from clientPersonalAccount

-- Водоснабжение
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Водоснабжение', 0, 'ЖКХ');

-- Ремонт
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Ремонт', 0, 'ЖКХ');

-- Электричество
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Электричество', 0, 'ЖКХ');

-- Оплата интернета и ТВ
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Оплата интернета и ТВ', 0, 'Связь и интернет');

-- Сотовой связи
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Сотовой связи', 0, 'Связь и интернет');

-- Подписка на сервис
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Подписка на сервис', 0, 'Подписки');

-- Пожертвования на СВО
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Пожертвования на СВО', 0, 'благотворительность');

-- Пожертвования на СД (счастливое детство)
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Пожертвования на СД (счастливое детство)', 0, 'благотворительность');

-- Мамам
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Мамам', 0, 'Перевод');

-- Брат
INSERT INTO clientServices (serviceName, serviceBalance, serviceType) VALUES ('Брат', 0, 'Перевод');


update bank_card set bank_card_balance = 50000 where id_bank_card = 1
