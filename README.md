# PassGen C#

### Application is a CLI password generator with link to local database

Application made in C# using .NET 5.0. Made to practice the experience with C# and link with database. I usually use a lot of CLI tools, so I thought, why not do mine, since password generators and stores are frequent in my daily life

## Dependencies

It requires .NET installed and a MySQL database installed, a database and a user created for the application. Below is the code for installing and configuring the database for Ubuntu 20.04

- In your shell

        sudo apt update
        sudo apt install mariadb-client mariadb-server mariadb-common
        sudo mysql

- At MariaDB

        create database PassGen;
        create table Passwords(id int(11) NOT NULL AUTO_INCREMENT, user varchar(250),password varchar(50) NOT NULL, application varchar(250), primary key (id));
        grant all on PassGen.* to PassGenApp@'%' identified by '78964254';
        flush privileges;

## Functions

- 1° Generate a password and save it to the database (or not). You can choose or not to save the application (As URL or name) and your Username.

- 2° Same as above, but you can enter an existing password to be saved in the database

- 3° Display your passwords saved in the database, along with other data such as application and username

![Screenshot](/Screenshots/screenshot.png)

## Installation and execution

- To run the application, clone this github repository

        git clone https://github.com/WeversonL/PassGen-Csharp.git

- Enter the project folder and run using .NET

        dotnet run