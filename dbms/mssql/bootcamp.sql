USE master
GO

IF NOT EXISTS (
 SELECT name
 FROM sys.databases
 WHERE name = N'BootCamp'
)

CREATE DATABASE BootCamp;
GO

IF SERVERPROPERTY('ProductVersion') > '12'
ALTER DATABASE BootCamp SET QUERY_STORE=ON;
GO

-- 전체복구 모델로 변경
use master;
alter database BootCamp set recovery full
go


-- 데이터베이스 Korea_Wansung_CI_AS 변경
ALTER DATABASE BootCamp
COLLATE Korean_Wansung_CI_AS
GO

--
select name, collation_name
from sys.databases
where name = N'BootCamp'

-- 기본언어 한글로 변경
USE BootCamp;
GO
EXEC sp_configure 'default language', 29 ;
GO
RECONFIGURE ;
GO

use BootCamp
go
exec sp_changedbowner 'sa'

-- (문제발생시)데이터베이스 소유자 변경
exec sp_changedbowner 'sa'
EXEC sp_change_users_login 'Update_One', 'DMS', 'DMS'


/* 완성견본 */
CREATE DATABASE [DMS]
 ON  PRIMARY 
( NAME = N'DMS', FILENAME = N'/var/opt/mssql/data/DMS.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DMS_log', FILENAME = N'/var/opt/mssql/data/DMS_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 COLLATE Korean_Wansung_CI_AS

GO

ALTER DATABASE [BootCamp] SET RECOVERY FULL 
GO

ALTER DATABASE [BootCamp] SET  MULTI_USER 
GO
