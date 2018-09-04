----------------- Database ------------------
drop database db_seriator;              /*/*/
create database db_seriator;            /*/*/
use db_seriator;                        /*/*/
---------------------------------------------

------------------ User ---------------------
create table tbl_user(                  /*/*/
user_id int (10) auto_increment not null,    /*/*/
user_name varchar (50),                 /*/*/
user_password varchar (50),             /*/*/
user_timeWatched double,                /*/*/
primary key(user_id)                    /*/*/
);                                      /*/*/
---------------------------------------------

---------------- Category -------------------
create table tbl_category(              /*/*/
category_id int (10) auto_increment not null,          /*/*/
category_title varchar (20),            /*/*/
primary key(category_id)                /*/*/
);                                      /*/*/
---------------------------------------------

------------------------------ Anime ------------------------------
create table tbl_series(                                       /*/*/
series_id int auto_increment not null,                        /*/*/
series_status int (10),                                       /*/*/
series_title varchar (50),									  /*/*/
series_seasons int (10),                                      /*/*/
series_episodes double,                                       /*/*/
series_synopsys varchar (1000),                               /*/*/
series_episodePerSeason double,                               /*/*/
series_currentSeason double,                                  /*/*/
series_currentEpisode double,                                 /*/*/
series_progressSeason varchar (30),                           /*/*/
series_progressEpisodes varchar (20),                         /*/*/
series_duration double,                                       /*/*/
series_dayFinished dateTime,                                  /*/*/
user_id int not null,                                         /*/*/
category_id int not null,                                     /*/*/
primary key(series_id),                                        /*/*/
foreign key(user_id) references tbl_user(user_id),            /*/*/
foreign key(category_id) references tbl_category(category_id) /*/*/
);                                                            /*/*/
-------------------------------------------------------------------

------------------------- Anime Categorys -----------------------------------------
insert into tbl_category(category_id, category_title) values(1, 'Drama');     /*/*/
insert into tbl_category(category_id, category_title) values(2, 'Ação');      /*/*/
insert into tbl_category(category_id, category_title) values(3, 'Horror');    /*/*/
insert into tbl_category(category_id, category_title) values(4, 'Comédia');   /*/*/
insert into tbl_category(category_id, category_title) values(5, 'Terror');    /*/*/
insert into tbl_category(category_id, category_title) values(6, 'Herói');     /*/*/
insert into tbl_category(category_id, category_title) values(7, 'Fantasia');  /*/*/
insert into tbl_category(category_id, category_title) values(8, 'Desenho');   /*/*/
insert into tbl_category(category_id, category_title) values(9, 'Suspense');  /*/*/
insert into tbl_category(category_id, category_title) values(10, 'Sit Com');  /*/*/ 