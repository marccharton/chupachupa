ALTER DATABASE [Chupachupa-Database] SET offline WITH rollback immediate
DROP DATABASE [Chupachupa-Database]

PRINT 'DELETE THESE FILES : '
SELECT physical_name, * FROM sys.database_files 