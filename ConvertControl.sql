--declare @database nvarchar(255)
--declare @mysqldatabase nvarchar(255)
--declare @showmessage bit 
--declare @showalterquerymessage bit 
--declare @showretrievalquerymessage bit 
--declare @showimportantmessage bit
--set @database = N'test2'
--set @mysqldatabase = N'pointofsale'
--set @showmessage = 0
--set @showalterquerymessage = 0
--set @showretrievalquerymessage = 0
--set @showimportantmessage = 1

/******
Epirteo Software

Abstract: This code will transfer structure from mysql to sql server

Structure:
Part.1 - This is to copy data and structure to sql server
	Part.1.1 - Create the structure and data to the sql server with identity columns in place
	Part.1.2 - This is to fix candidate primary columns to NOT NULL
	Part.1.3 - This is to add default constraints for all the columns
	Part.1.4 - Adding of Primary Keys to the tables
Part.2 - This is to put index to the sql server with reference from mysql
Part.3 - This is to put foreign key to the sql server with reference from mysql
*******/

declare @table nvarchar(255)
declare @tabletoinsert nvarchar(255)

declare @result  varchar(max)
declare @mysqlquery varchar(max)
declare @executequery nvarchar(max)
declare @executequeryMain nvarchar(max)

declare @params nvarchar(max)
declare @returnval nvarchar(max)
declare @returnval1 nvarchar(max)
declare @value  nvarchar(max)
declare @parmDefinition nvarchar(500) 
declare @parmDefinition1 nvarchar(500) 
declare @retvalOUT nvarchar(max) 
declare @column nvarchar(255)
declare @datatype nvarchar(50)
declare @columnsconcat nvarchar(max) 
declare @data_type  nvarchar(50)
declare @column_default   nvarchar(50)
declare @constraint_type  nvarchar(50)


declare @message nvarchar(max)



--EXEC master.dbo.sp_addlinkedserver 
--@server = N'MYSQL', 
--@srvproduct=N'MySQL', 
--@provider=N'MSDASQL', 
--@provstr=N'DRIVER={MySQL ODBC 5.1 Driver}; SERVER=localhost; _
--	DATABASE=pointofsale; USER=root; PASSWORD=iprotech123; OPTION=3'
	
	


-- get all the tables and put it to cursor
--set @mysqlquery = N'Select Table_name from information_schema.TABLES where  table_schema="'+@mysqldatabase+'" and table_name = "test"' 
--set @mysqlquery = N'Select Table_name from information_schema.TABLES where  table_schema="'+@mysqldatabase+'" and table_name in ("ospos_employees","ospos_permissions","ospos_modules","ospos_people")'
--set @mysqlquery = N'Select Table_name from information_schema.TABLES where  table_schema="'+@mysqldatabase+'" and table_name in ("test1","test2")'

set @mysqlquery = N'Select Table_name from information_schema.TABLES where  table_schema="'+@mysqldatabase+'"'
set @executequeryMain = N'DECLARE db_cursor CURSOR FOR select table_name from openquery(MYSQL,'''+@mysqlquery+''')' 

IF @showmessage = 1 Begin Print N'**Start creation of table structure and data...' End
IF @showretrievalquerymessage = 1 Begin Print N'**'+@executequeryMain+'' End
exec sp_executesql @executequeryMain



OPEN db_cursor
FETCH NEXT FROM db_cursor
INTO @table
 
WHILE @@FETCH_STATUS = 0
BEGIN
		--Part.1 - This is to copy data and structure to sql server
		IF @showmessage = 1 Begin Print N'**	Start creation of structure and data for table '+@table+'...'End
		set @tabletoinsert = @table

		-- create a identity table
		-- get the columns to create and put the identity replace
		-- create a dynamic sql for the columns retrieval


		-- get all the collumns and put it in one liner
		set @mysqlquery = N'Select * from information_schema.COLUMNS where table_name="'+@table+'" and table_schema="'+@mysqldatabase+'"'
		set @executequery = N'
			 --set @retvalOUT = ''
			select @retvalOUT = COALESCE(@retvalOUT + '', '', '''') + ''['' + COLUMN_NAME +'']'' from openquery(MYSQL,'''+@mysqlquery+''')'
		 
		SET @parmDefinition = N'@retvalOUT nvarchar(max) OUTPUT' 
		set @returnval = null
		
		IF @showretrievalquerymessage = 1 Begin Print N'**	Parameter Definition = '+@parmDefinition+''  Print N'*	'+@executequery+'' End
		EXEC sp_executesql @executequery, @parmDefinition, @retvalOUT=@returnval OUTPUT 
		 

		-- get all the identity columns and add the identity syntax
		set @mysqlquery = N'Select * from information_schema.COLUMNS where table_name="'+@table+'" and extra = "auto_increment" and table_schema="'+@mysqldatabase+'"'
		set @executequery = N'select  @retvalOUT=''[''+COLUMN_NAME+'']'' from openquery(MYSQL,'''+@mysqlquery+''')'
		IF @showretrievalquerymessage = 1 Begin Print N'*	Parameter Definition = '+@parmDefinition+''  Print N'*	'+@executequery+'' End
		EXEC sp_executesql @executequery, @parmDefinition, @retvalOUT=@returnval1 OUTPUT 

		set @params = REPLACE(REPLACE(@returnval,'[', '`' ),']', '`' );

		IF @returnval1 <> null 
		Begin
			set @value = REPLACE(@returnval,@returnval1, 'IDENTITY (int, 1, 1) AS ' + @returnval1 );
		end
		else
		begin
			set @value = @returnval
		end
		--Part.1.1 - Create the structure and data to the sql server with identity columns in place
		set @mysqlquery = 'SELECT ' +@params+ ' FROM '+@mysqldatabase+'.'+@table+'';
		set @executequery = 'SELECT ' +@value+ ' INTO ' +@tabletoinsert+ ' from openquery(MYSQL,''' +@mysqlquery+ ''')'
		IF @showalterquerymessage = 1 Begin Print N'*	'+@executequery+'' End
		EXEC sp_executesql @executequery
		
		IF @showmessage = 1 Begin Print N'*		Start adding Primary Key and Default...' End
		
		set @mysqlquery = N'
		SELECT c.table_name,c.column_name,IF(ISNULL(c.character_maximum_length),"", CONCAT("(",c.character_maximum_length,")"))  datatype,c.COLUMN_DEFAULT,t.constraint_type
		FROM  information_schema.columns c 
		left JOIN information_schema.key_column_usage k    
		USING(table_schema,column_name,table_name)
		left JOIN information_schema.table_constraints t  
		USING(constraint_name,table_schema,table_name)
		WHERE c.table_schema="'+@mysqldatabase+'"
		  AND c.table_name="'+@table+'"' --and t.constraint_type="PRIMARY KEY" 
		
		set @columnsconcat = ''
		
		--column_name , table_name 
		-- add primary key
		set @executequery = N'DECLARE db_cursorsub CURSOR FOR 
							select distinct c.data_type,m.column_name,c.data_type+datatype as datatype,cast(m.COLUMN_DEFAULT as varchar(50)) as COLUMN_DEFAULT,constraint_type 
							from openquery(MYSQL,'''+@mysqlquery+''') as m 
							join INFORMATION_SCHEMA.COLUMNS c on c.column_name = m.column_name and c.table_name=m.table_name and c.table_catalog = '''+@database+''''

		IF @showretrievalquerymessage = 1 Begin Print N'*		'+@executequery+'' End
		exec sp_executesql @executequery

		OPEN db_cursorsub
		FETCH NEXT FROM db_cursorsub
		INTO @data_type,@column,@datatype,@column_default,@constraint_type
		
		WHILE @@FETCH_STATUS = 0
		BEGIN
				IF @showmessage = 1 Begin Print N'*			Start adding Primary Key and Default for column '+@column+'...' End
				--add primary key
				IF @constraint_type='PRIMARY KEY'
				Begin
						--Part.1.2 - This is to fix candidate primary columns to NOT NULL
						IF @showmessage = 1 Begin Print N'*				Change column ['+@column+'] to Not Null...' End 
						set @executequery = N'ALTER TABLE dbo.'+@table+' Alter COLUMN  ['+@column+'] '+@datatype+' NOT NULL;'
						IF @showalterquerymessage = 1 Begin Print N'*				'+@executequery+'' End
						exec sp_executesql @executequery
						
						set @columnsconcat = @columnsconcat + '[' + @column+'] ASC '
						
						set @columnsconcat = @columnsconcat + ','
				End
				Else
				Begin
						IF @showmessage = 1 Begin Print N'*				No Primary Key added for column ['+@column+'].' End 
				End
		 

				
				-- default
				IF @column_default is not null
				Begin
						 
						IF @@FETCH_STATUS <> 0
						Begin 
								--Part.1.3 - This is to add default constraints for all the columns
								IF exists(select top 1 * from INFORMATION_SCHEMA.TABLES where 
									@data_type in ('int','tinyint','bit','decimal', 'numeric','money','smallmoney','float','binary'))
								Begin
									set @column_default = '(('+@column_default+'))'
								End
								ELSE IF exists(select top 1 * from INFORMATION_SCHEMA.TABLES where 
									@data_type in ('varchar','char','text','nchar','nvarchar','ntext'))
								BEGIN
									set @column_default = ''''+@column_default+''''
								END
								ELSE
								BEGIN
									set @column_default = ''
								End
								
								IF @column_default <> ''
								BEGIN
									IF @showmessage = 1 Begin Print N'*				Add Default for column ['+@column+'] ...' End 
									set @executequery =N'
									IF exists(select * from INFORMATION_SCHEMA.COLUMNS where  Column_default is null and table_name = '''+@table+''' and column_name = '''+@column+''')
									BEGIn
										ALTER TABLE [dbo].['+@table+'] ADD  CONSTRAINT [DF_'+@table+'_'+@column+']  DEFAULT '+@column_default+' FOR ['+@column+']
									END'

									IF @showalterquerymessage = 1 Begin Print N'*				'+@executequery+'' End
									exec sp_executesql @executequery
								End
						End
				End
						
				FETCH NEXT FROM db_cursorsub --have to fetch again within loop
				INTO @data_type,@column,@datatype,@column_default,@constraint_type	
				
				IF @@FETCH_STATUS <> 0
				Begin 
						IF @columnsconcat <> ''
						Begin
							--Part.1.4 - Adding of Primary Keys to the tables
							-- remove the last comma
							set @columnsconcat = REPLACE(@columnsconcat+'`~',',`~', '' );
							IF @showmessage = 1 Begin Print N'*				Add Primary Key for column ['+@column+'] named PK_'+@table+'_'+@column+'...' End 
							set @executequery = N'ALTER TABLE [dbo].['+@table+'] ADD  CONSTRAINT [PK_'+@table+'_'+@column+'] PRIMARY KEY CLUSTERED ('+@columnsconcat+')'
							--select @executequery
							IF @showalterquerymessage = 1 Begin Print N'*				'+@executequery+'' End
							exec sp_executesql @executequery
						End
						Else
						Begin
							IF @showmessage = 1 Begin Print N'*				No Primary Key is added for column ['+@column+']...' End 
						End
				End					
				IF @showmessage = 1 Begin Print N'*			Done adding Primary Key for column '+@column+'.' End 
		END
		CLOSE db_cursorsub
		DEALLOCATE db_cursorsub
		IF @showmessage = 1 Begin Print N'*		Done adding Primary Key and Default...' End
		
		IF @showmessage = 1 Begin Print N'*	Done creation of table structure and data for table [' + @table + '].' End
		FETCH NEXT FROM db_cursor --have to fetch again within loop
		INTO @table

END

CLOSE db_cursor
DEALLOCATE db_cursor
IF @showmessage = 1 Begin Print N'*Done creation of table structure and data...' End
--################################################Index
--Part.2 - This is to put index to the sql server with reference from mysql
declare @table_name nvarchar(64)
declare @non_unique nvarchar(10)
declare @index_schema nvarchar(64)
declare @index_name nvarchar(64)
declare @seq_in_index int
declare @column_names nvarchar(64)
declare @collation nvarchar(1)
declare @indexname nvarchar(64)

IF @showmessage = 1 Begin Print N'*Start creation of table index...' End
IF @showretrievalquerymessage = 1 Begin Print N'*'+@executequery+'' End
exec sp_executesql @executequeryMain

SET @parmDefinition = N'
@table_name_arg nvarchar(64) OUTPUT,
 @index_schema_arg nvarchar(64) OUTPUT,
 @column_names_arg nvarchar(64) OUTPUT,
 @non_unique_arg nvarchar(10) OUTPUT,
 @index_name_arg nvarchar(64) OUTPUT'
 
OPEN db_cursor
FETCH NEXT FROM db_cursor
INTO @table
WHILE @@FETCH_STATUS = 0
BEGIN
		IF @showmessage = 1 Begin Print N'*	Start adding Index for table ['+@table+']...' End
		set @mysqlquery = N'select  
							distinct INDEX_NAME
							from
							Information_schema.STATISTICS
							where
							table_name = "'+@table+'" and
							table_schema = "'+@mysqldatabase+'" and index_name not in ("PRIMARY")'

		set @executequery = N'DECLARE db_cursorsub CURSOR FOR 
							select INDEX_NAME 
							from openquery(MYSQL,'''+@mysqlquery+''') as m'
		IF @showretrievalquerymessage = 1 Begin Print N'*	'+@executequery+'' End
		execute sp_executesql @executequery
		
		OPEN db_cursorsub
		FETCH NEXT FROM db_cursorsub
		INTO @indexname 
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @showmessage = 1 Begin Print N'*		Start adding index '+@indexname+'...' End
			set @mysqlquery = N'select  
					TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,NON_UNIQUE,
					INDEX_SCHEMA,INDEX_NAME,SEQ_IN_INDEX,
					COLUMN_NAME,COLLATION,CARDINALITY,SUB_PART,
					PACKED,NULLABLE,INDEX_TYPE,`COMMENT`
					from
					Information_schema.STATISTICS
					where
					table_name = "'+@table+'" and
					table_schema = "'+@mysqldatabase+'" and
					INDEX_NAME = "'+@indexname+'" order by SEQ_IN_INDEX asc'
			set @executequery = N'select    
				  @column_names_arg = COALESCE(@column_names_arg + '', '', '''') + ''['' + m.COLUMN_NAME +'']'' ,
				  @index_schema_arg =INDEX_SCHEMA,
				  @table_name_arg=TABLE_NAME,
				  @index_name_arg=INDEX_NAME,
				  @non_unique_arg =   case NON_UNIQUE when  0 Then ''UNIQUE'' Else '''' End 
					from openquery(MYSQL,'''+@mysqlquery+''') as m'

				IF @showretrievalquerymessage = 1 Begin Print N'*		Parameter Definition = '+@parmDefinition+''  Print N'*		'+@executequery+'' End
				
				set @column_names = null
				set @index_schema = null
				set @table_name = null
				set @index_name = null
				set @non_unique = null
				
				execute sp_executesql @executequery,@parmDefinition, 
					@column_names_arg =@column_names OUTPUT,
					@index_schema_arg =@index_schema OUTPUT,
					@table_name_arg=@table_name OUTPUT,
					@index_name_arg=@index_name OUTPUT,
					@non_unique_arg = @non_unique OUTPUT
				
				set @executequery = N'CREATE '+@non_unique+' NONCLUSTERED INDEX ['+@indexname+'] ON [dbo].['+@table_name+'] 
					(
						'+@column_names+'
					)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]'
				IF @showmessage = 1 Begin Print N'*			Add index '+@indexname+'...' End
				IF @showalterquerymessage = 1 Begin Print N'*			'+@executequery+'' End
				execute sp_executesql @executequery
				IF @showmessage = 1 Begin Print N'*		Done adding index '+@indexname+'.' End
				FETCH NEXT FROM db_cursorsub --have to fetch again within loop
				INTO @indexname
				
		End -- end of loop
		
		CLOSE db_cursorsub
		DEALLOCATE db_cursorsub
		IF @showmessage = 1 Begin Print N'*	Done adding Index for table ['+@table+'].' End
		FETCH NEXT FROM db_cursor --have to fetch again within loop
		INTO  @table
End

CLOSE db_cursor
DEALLOCATE db_cursor
IF @showmessage = 1 Begin Print N'*Done creation of table index.' End

--################################################foreign Key
--Part.3 - This is to put foreign key to the sql server with reference from mysql
declare @constraint_name nvarchar(300)
declare @COLUMN_NAME nvarchar(300) 
declare @referenced_table_name  nvarchar(300)
declare @referenced_column_name  nvarchar(300)
declare @tablecolumns nvarchar(max)
declare @referencetablecolumns nvarchar(max)
declare @referencetablecolumns1 nvarchar(max)
declare @count int
declare @indexcount int

exec sp_executesql @executequeryMain
IF @showmessage = 1 Begin Print N'*Start adding Foreign Key to the tables...' End
OPEN db_cursor
FETCH NEXT FROM db_cursor
INTO @table
WHILE @@FETCH_STATUS = 0
BEGIN
		IF @showmessage = 1 Begin Print N'*	Start adding Foreign Key for table ['+@table+']...' End
		set @mysqlquery = N'SELECT  t.constraint_name
							FROM information_schema.table_constraints t    
							JOIN information_schema.key_column_usage k    
							USING(constraint_name,table_schema,table_name)    
							WHERE t.table_schema="'+@mysqldatabase+'"  and constraint_type = "FOREIGN KEY"
							and k.table_name = "'+@table+'"'
	
		set @executequery = N'DECLARE db_cursorsub CURSOR FOR 
							select distinct m.constraint_name 
							from openquery(MYSQL,'''+@mysqlquery+''') as m'
		IF @showretrievalquerymessage = 1 Begin Print N'*	'+@executequery+'' End
		exec sp_executesql @executequery
							
		OPEN db_cursorsub
		FETCH NEXT FROM db_cursorsub
		INTO @constraint_name 
		
		SET @parmDefinition = N'@tablecolumns_arg nvarchar(200) OUTPUT,
							@referencetablecolumns_arg nvarchar(max) OUTPUT,
							@referencetablecolumns1_arg nvarchar(max) OUTPUT,
							@constraint_name_arg nvarchar(200) OUTPUT,
							@table_name_arg nvarchar(200) OUTPUT,
							@referenced_table_name_arg nvarchar(200) OUTPUT,
							@count_arg int OUTPUT'
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @showmessage = 1 Begin Print N'*		Start adding Foreign Key '+@constraint_name+'...' End
			set @mysqlquery = N'SELECT  distinct t.constraint_name,k.table_name, k.COLUMN_NAME,k.referenced_table_name, k.referenced_column_name         
					FROM information_schema.table_constraints t             
					JOIN information_schema.key_column_usage k             
					USING(constraint_name,table_schema,table_name)             
					WHERE t.table_schema="'+@mysqldatabase+'"  and 
					constraint_type = "FOREIGN KEY" and 
					t.constraint_name in ("'+@constraint_name+'") and k.table_name = "'+@table+'"'
					
			set @executequery = N'select    
					@tablecolumns_arg = COALESCE(@tablecolumns_arg + '', '', '''') + ''['' + m.COLUMN_NAME +'']'' ,
					@referencetablecolumns_arg = COALESCE(@referencetablecolumns_arg + '', '','''') + ''['' + m.referenced_column_name +'']'' ,
					@referencetablecolumns1_arg = COALESCE(@referencetablecolumns1_arg + '', '','''') + '''''''' + m.referenced_column_name +'''''''' ,
					@constraint_name_arg =constraint_name,
					@table_name_arg=table_name,
					@referenced_table_name_arg=referenced_table_name,
					@count_arg = count(1)
					from openquery(MYSQL,'''+@mysqlquery+''') as m
					group by m.COLUMN_NAME,m.referenced_column_name,m.constraint_name,m.table_name,m.referenced_table_name'	
			
			set @tablecolumns = null
			set @referencetablecolumns = null
			set @constraint_name = null
			set @table_name = null
			set @referenced_table_name = null
			set @count = null
			
			IF @showretrievalquerymessage = 1 Begin Print N'*		Parameter Definition = '+@parmDefinition+''  Print N'*		'+@executequery+'' End

			execute sp_executesql @executequery,@parmDefinition, 
					@tablecolumns_arg =@tablecolumns OUTPUT ,
					@referencetablecolumns_arg = @referencetablecolumns OUTPUT,
					@referencetablecolumns1_arg = @referencetablecolumns1 OUTPUT,
					@constraint_name_arg = @constraint_name OUTPUT,
					@table_name_arg = @table_name OUTPUT,
					@referenced_table_name_arg = @referenced_table_name OUTPUT ,
					@count_arg = @count OUTPUT
			
			SET @parmDefinition1 = N'@count_arg1 int OUTPUT'	
			set @executequery = N'SELECT @count_arg1 = COUNT(1)
				FROM sys.indexes i 
				join sys.objects o ON i.object_id = o.object_id
				join sys.index_columns ic ON ic.object_id = i.object_id and ic.index_id = i.index_id
				join sys.columns co ON co.object_id = i.object_id and co.column_id = ic.column_id
				WHERE  
				i.is_unique = 1 and o.name = '''+@referenced_table_name+''' and co.name in ('+@referencetablecolumns1+')'

			set @indexcount = null
			IF @showretrievalquerymessage = 1 Begin Print N'*		Parameter Definition = '+@parmDefinition1+''  Print N'*		'+@executequery+'' End

			execute sp_executesql @executequery,@parmDefinition1,@count_arg1 = @indexcount OUTPUT
			
			IF  @indexcount = @count
			BEGIN
				IF @showmessage = 1 Begin Print N'*			Add Foreign Key '+@constraint_name+'...' End
				set @executequery = N'ALTER TABLE ['+@table_name+']
				add CONSTRAINT '+@constraint_name+' FOREIGN KEY ( '+@tablecolumns+' ) REFERENCES ['+@referenced_table_name+']('+@referencetablecolumns+')'
				exec sp_executesql @executequery
			END
			ELSE
			BEGIN
				IF @showimportantmessage = 1 Begin Print N'*			Cannot add Foreign Key to a non-unique columns in SQL SERVER. ALTER TABLE ['+@table_name+']	add CONSTRAINT '+@constraint_name+' FOREIGN KEY ( '+@tablecolumns+' ) REFERENCES ['+@referenced_table_name+']('+@referencetablecolumns+')' END
			END
			
			IF @showalterquerymessage = 1 Begin Print N'*			'+@executequery+'' End
			
			IF @showmessage = 1 Begin Print N'*		Done adding Foreign Key '+@constraint_name+'.' End
			FETCH NEXT FROM db_cursorsub --have to fetch again within loop
			INTO  @constraint_name
		End
		
		CLOSE db_cursorsub
		DEALLOCATE db_cursorsub
		IF @showmessage = 1 Begin Print N'*	Done adding Foreign Key for table ['+@table+'].' End
		
	FETCH NEXT FROM db_cursor --have to fetch again within loop
	INTO @table
End
IF @showmessage = 1 Begin Print N'*Done adding Foreign Key to the tables.' End
CLOSE db_cursor
DEALLOCATE db_cursor

IF @showmessage = 1 Begin Print N'*FINISHED!!' End
