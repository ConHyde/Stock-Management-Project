USE [StockTakeManagementCore]
GO

BEGIN TRY

  BEGIN TRANSACTION
DECLARE @pdg_guid UNIQUEIDENTIFIER
,		@usr_guid UNIQUEIDENTIFIER = NEWID()

select top 1 @pdg_guid = pdg_guid
from stt_product_group

select Top 1 @usr_guid = usr_guid
from stt_USER

--INSERT INTO stt_Product_Group
--(pdg_guid, pdg_name,pdg_description, pdg_inactive)
--VALUES
--(@pdg_guid, 'General', 'General Products', 0)

--INSERT INTO stt_User
--(usr_guid, usr_id, usr_first_name, usr_last_name, usr_fullname, usr_created_date, usr_updated_date, usr_admin, usr_inactive)
--VALUES
--(@usr_guid, 'ConnorHyde', 'Connor', 'Hyde', 'Connor Hyde', GETUTCDATE(), NULL, 1, 0 )


INSERT INTO [dbo].[stt_Product]
           ([prd_guid]
           ,[prd_id]
           ,[prd_name]
           ,[prd_description]
           ,[prd_pdg_guid]
           ,[prd_created]
           ,[prd_created_usr_guid]
           ,[prd_updated]
           ,[prd_update_usr_guid]
           ,[prd_last_counted]
           ,[prd_last_counted_usr_guid]
           ,[prd_last_cost_price]
           ,[prd_last_sales_price]
           ,[prd_inactive])
     VALUES
           (NEWID()
           ,'Test Product ID 5'
           ,'Test Product Name 5'
           ,'Test Product Description 5'
           ,@pdg_guid
           ,GETUTCDATE()
           ,@usr_guid
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL					
           ,0)

		   PRINT 'Transaction Commited'
COMMIT TRANSACTION

END TRY

BEGIN CATCH

PRINT 'Transaction Rolled Back'
ROLLBACK TRANSACTION

END CATCH


select * from stt_Product

select * from stt_Product_group

select * from stt_user


