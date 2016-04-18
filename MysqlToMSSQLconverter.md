#If you want to convert MYSQL database to MS SQL database this is the right tool for you.

# Introduction #

This project will convert MYSQL database to MS SQM database. The conversion process is done with ConvertControl.sql query. The exe is only use to gather information and passed to ConvertControl.sql.

ConvertControl.sql is open to change by the user.


# Details #

Add your content here.  Format your content with:
  * Text in **bold** or _italic_
  * Headings, paragraphs, and lists
  * Automatic links to other wiki pages

# Requirements #

  * .**MYSQL
  * .** MSSQL
  * .**MySQL ODBC Connector  http://dev.mysql.com/downloads/connector/**

# How to USE #
**1. Setup ODBC Connection to MySQL Database**

This article will not go through how to setup a MySQL or Microsoft SQL server, but make sure you have downloaded at least the MySQL ODBC Connector from here .
For this article, I downloaded the MySQL ODBC Connector 5.1.
The setup of this connector is pretty simple:
<br />
<br />1. Open your ODBC Data Source Administrator from the Control Panel -> Administrative Tools. Under the tab labelled as "System DSN", press the "Add" button.
<br />2.On the "Create New Data Source" dialog that appeared, choose MySQL ODBC 5.1 Driver and then press the "Finish" button.
<br />3.After that, a MySQL connection configuration dialog will appear. Add your MySQL database account information in it, preferably the "root" account which has full access to your databases in MySQL. In this case, my database is called "tigerdb". Do not change the port to anything other than 3306, unless during yourMySQL server installation, you have defined something else.
<br />3.Press the "Test" button to ensure your connection settings are set properly and then the "OK" button when you're done.

**2. Use Free Mysql to Mssql Conversion.**
<br />
<br />1.Install Mysql to MsSQL converter. Download for <a href='https://code.google.com/p/mysql-to-mssql-server-converter/source/browse/trunk/MysqlToMssqlx86.zip'>
Win86 (Right click Save link As..)</a> or <a href='https://code.google.com/p/mysql-to-mssql-server-converter/source/browse/trunk/MysqlToMssqlx64.zip'>
Win64 (Right click Save link As..)</a>.
Fill up the Server Name, Authentication, User name and password. Then press Connect button to check for the connection. If successful, the Mysql Connect button will automatically Activate.

<br />2.For MYSQL connection Fill up the host name, User name, Password and Driver. Then press the Connect button. If successful, the Start conversion button will activate and you can now select the source database (Mysql) and destination database (MSSQL).

<br />3.Select the distination Database (MSSQL) and the source database (MYSQL).

<br />4.Press Start Button to begin the migration process. The process will convert the table structure, primary keys, foreign keys , indexes , default values and identities.

http://convertmysqltosqlserver.blogspot.com/
<br />
<br />
<br />
<br />
<sup>Authored by:</sup>
<sup>Jose Levi J. Diola</sup>