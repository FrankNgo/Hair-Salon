# Hair Salon

#### By Frank Ngo

## Description

A program to add employees to a list.  Each employee can add clients to a list unique to each employee.

## Specifications


- Input for all stylists fields can save and get user data
  - Example input:
    - First Name: Frank Ngo
  - Example output:
    - On list: "Frank Ngo" is stored in variable firstName.
- User can add a new stylist to the list of stylists
  - Example input:
    - Name: Frank Ngo
  - Example output:
    - On list: "Frank Ngo" appears on list
- User can enter a client for each stylists
  - Example input:
    - Name: John Smith
  - Example output:
    - On list for "Frank Ngo": "John Smith" appears on list
- User can select view all to see a list of all stylists
  - Example input:
    - User selects hyperlink "View All Stylist"
  - Example output:
    - User is taken to a page that lists all stylist
- User can remove a stylist off the list of stylists
  - Example input:
    - User selects option "Delete"
  - Example output:
    - Selected stylist is removed off the list of stylist

### Installing

  * Open Terminal
  * Start by importing the databases
  * Download the application MAMP from https://www.mamp.info/en/
  * Open the application and press "Start Server"
  * Select "Open Start Page"
  * Under tools in the main toolbar select "phpMyAdmin"
  * This will take you to the database control interface
  * Click the import button from the top tool bar and select the included "frank_ngo.sql" file to start importing it
  * Select the "Go" button to start importing the database and repeat for all included database files
  * You can also manually set up the databases by using a terminal and entering in:
  ```
  $ C:\MAMP\bin\mysql\bin\mysql -uroot -proot -P8889
  ```
  From your command line once you've logged into MySQL, create the database and tables via the following instructions.

  For Main Database
  ```
  CREATE DATABASE frank_ngo;
  USE frank_ngo;
  CREATE TABLE `clients` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `first_name` varchar(255) DEFAULT NULL,
    `last_name` varchar(255) DEFAULT NULL,
    `stylist_id` int(11) NOT NULL
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
  CREATE TABLE `stylists` (
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
  ```
  For Test Database
  ```
  CREATE DATABASE frank_ngo;
  USE frank_ngo;
  CREATE TABLE `clients` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `first_name` varchar(255) DEFAULT NULL,
    `last_name` varchar(255) DEFAULT NULL,
    `stylist_id` int(11) NOT NULL
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
  CREATE TABLE `stylists` (
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
  ```
  * Cd to desktop or where user would like to store directory by typing in: cd Desktop
  * Copy application contents by typing in your Terminal: git clone https://github.com/FrankNgo/Hair-Salon.git
  * Navigate to the application directory by typing in: cd Word-Counter
  * Restore the applications dependencies by typing in: dotnet restore
  * Build the application by typing in: dotnet build
  * Run and open the application by typing in: dotnet run
  * Open any browser
  * Type in the browser URL http://localhost:5000/ to access the application

### Bugs and Tests

No known bugs

## Built With

* HTML - The web framework used
* C# - The programming language used
* CSS - Style Library
* Javascript
* Asp .NET Core MVC
* [bootstrap](https://getbootstrap.com/docs/3.3/) - Style Library
* [jquery](https://jquery.com/download/) - Javascript Library


## Author and contact details

* Frank Ngo https://github.com/FrankNgo
* Contact the author at frankngomusic@gmail.com

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
