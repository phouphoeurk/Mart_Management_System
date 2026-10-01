-- ============================================================================
-- 000_Full_Schema.sql
--
-- GENERATED FROM LIVE DATABASE METADATA - do not hand-edit.
--
--   Source server  : (null)
--   Source database: db69906
--   Collation      : SQL_Latin1_General_CP1_CI_AS
--   Engine version : 17.0.4085.5
--   Generated at   : 2026-10-01 11:20:31
--
-- Metadata sources: sys.tables, sys.columns, sys.types,
-- sys.identity_columns, sys.default_constraints, sys.key_constraints,
-- sys.indexes, sys.index_columns, sys.check_constraints, sys.foreign_keys,
-- sys.foreign_key_columns.
--
-- Fidelity notes:
--   * Column order, nullability, IDENTITY seed/increment and DEFAULT
--     expressions are reproduced verbatim. Mixed time-zone defaults
--     (sysdatetime() / getdate() / sysutcdatetime()) are deliberately
--     NOT normalised - they are reproduced exactly as the database has them.
--   * Primary keys keep their real constraint names, including the
--     auto-generated PK__<table>__<hash> names produced by SSMS.
--   * Unique and non-unique secondary indexes keep their real names and
--     are emitted as standalone CREATE [UNIQUE] INDEX statements.
--   * CHECK constraint definitions are reproduced verbatim from
--     sys.check_constraints.definition.
--   * dbo.sysdiagrams is deliberately excluded: it is an SSMS 'Database
--     Diagrams' artifact holding no application data, and no code
--     references it.
--
-- The script is re-runnable: every object is guarded by an existence
-- check, so applying it to a populated database is a no-op.
--
-- Application tables (9), emitted parents-first so every
-- inline FOREIGN KEY target already exists at creation time:
--   dbo.Categories
--   dbo.Suppliers
--   dbo.Products
--   dbo.users
--   dbo.PurchaseOrders
--   dbo.PurchaseOrderDetails
--   dbo.Sales
--   dbo.InventoryTransactions
--   dbo.SaleDetails
-- ============================================================================

SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

-- ---------------------------------------------------------------------------
-- dbo.Categories
-- ---------------------------------------------------------------------------
-- Identity: CategoryId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.Categories', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categories
    (
        CategoryId int IDENTITY(1,1) NOT NULL,
        CategoryName nvarchar(100) NOT NULL,
        Description nvarchar(255) NULL,
        IsActive bit NOT NULL DEFAULT ((1)),
        CreatedAt datetime2(7) NOT NULL DEFAULT (sysdatetime()),
        CONSTRAINT PK__Categori__19093A0BF5632614 PRIMARY KEY (CategoryId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.Suppliers
-- ---------------------------------------------------------------------------
-- Identity: SupplierId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.Suppliers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Suppliers
    (
        SupplierId int IDENTITY(1,1) NOT NULL,
        SupplierName nvarchar(150) NOT NULL,
        Phone nvarchar(30) NULL,
        Email nvarchar(150) NULL,
        Address nvarchar(255) NULL,
        IsActive bit NOT NULL DEFAULT ((1)),
        CreatedAt datetime2(7) NOT NULL DEFAULT (sysdatetime()),
        CONSTRAINT PK__Supplier__4BE666B4857C5B14 PRIMARY KEY (SupplierId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.Products
-- ---------------------------------------------------------------------------
-- Identity: ProductId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        ProductId int IDENTITY(1,1) NOT NULL,
        ProductName nvarchar(150) NOT NULL,
        Barcode nvarchar(50) NULL,
        CategoryId int NOT NULL,
        SupplierId int NULL,
        CostPrice decimal(18,2) NOT NULL DEFAULT ((0)),
        SellingPrice decimal(18,2) NOT NULL DEFAULT ((0)),
        StockQuantity int NOT NULL DEFAULT ((0)),
        ReorderLevel int NOT NULL DEFAULT ((0)),
        ExpiryDate datetime2(7) NULL,
        IsActive bit NOT NULL DEFAULT ((1)),
        CreatedAt datetime2(7) NOT NULL DEFAULT (sysdatetime()),
        CONSTRAINT PK__Products__B40CC6CDAED443D2 PRIMARY KEY (ProductId),
        CONSTRAINT CK_Products_CostPrice CHECK ([CostPrice]>=(0)),
        CONSTRAINT CK_Products_ReorderLevel CHECK ([ReorderLevel]>=(0)),
        CONSTRAINT CK_Products_SellingPrice CHECK ([SellingPrice]>=(0)),
        CONSTRAINT CK_Products_StockQuantity CHECK ([StockQuantity]>=(0)),
        CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(CategoryId),
        CONSTRAINT FK_Products_Suppliers FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.users
-- ---------------------------------------------------------------------------
-- Identity: UserId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.users
    (
        UserId int IDENTITY(1,1) NOT NULL,
        Username nvarchar(50) NOT NULL,
        PasswordHash nvarchar(255) NOT NULL,
        Role nvarchar(20) NOT NULL,
        IsActive bit NOT NULL DEFAULT ((1)),
        CreatedAt datetime2(7) NOT NULL DEFAULT (getdate()),
        UpdatedAt datetime2(7) NOT NULL DEFAULT (getdate()),
        FullName nvarchar(150) NOT NULL DEFAULT (''),
        CONSTRAINT PK__users__3213E83FA7A935E8 PRIMARY KEY (UserId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.PurchaseOrders
-- ---------------------------------------------------------------------------
-- Identity: PurchaseOrderId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.PurchaseOrders', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PurchaseOrders
    (
        PurchaseOrderId int IDENTITY(1,1) NOT NULL,
        SupplierId int NOT NULL,
        CreatedByUserId int NOT NULL,
        PurchaseDate datetime2(7) NOT NULL DEFAULT (sysdatetime()),
        Status nvarchar(20) NOT NULL DEFAULT ('Draft'),
        Subtotal decimal(18,2) NOT NULL DEFAULT ((0)),
        DiscountAmount decimal(18,2) NOT NULL DEFAULT ((0)),
        TotalAmount decimal(18,2) NOT NULL DEFAULT ((0)),
        CONSTRAINT PK__Purchase__036BACA4A45BCE0F PRIMARY KEY (PurchaseOrderId),
        CONSTRAINT CK_PurchaseOrders_DiscountAmount CHECK ([DiscountAmount]>=(0)),
        CONSTRAINT CK_PurchaseOrders_Status CHECK ([Status]='Cancelled' OR [Status]='Received' OR [Status]='Draft'),
        CONSTRAINT CK_PurchaseOrders_Subtotal CHECK ([Subtotal]>=(0)),
        CONSTRAINT CK_PurchaseOrders_TotalAmount CHECK ([TotalAmount]>=(0)),
        CONSTRAINT FK_PurchaseOrders_Suppliers FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId),
        CONSTRAINT FK_PurchaseOrders_Users FOREIGN KEY (CreatedByUserId) REFERENCES dbo.users(UserId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.PurchaseOrderDetails
-- ---------------------------------------------------------------------------
-- Identity: PurchaseOrderDetailId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.PurchaseOrderDetails', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PurchaseOrderDetails
    (
        PurchaseOrderDetailId int IDENTITY(1,1) NOT NULL,
        PurchaseOrderId int NOT NULL,
        ProductId int NOT NULL,
        Quantity int NOT NULL,
        UnitCost decimal(18,2) NOT NULL,
        LineSubtotal decimal(18,2) NOT NULL,
        CONSTRAINT PK__Purchase__5026B698A34CA24E PRIMARY KEY (PurchaseOrderDetailId),
        CONSTRAINT CK_PurchaseOrderDetails_LineSubtotal CHECK ([LineSubtotal]>=(0)),
        CONSTRAINT CK_PurchaseOrderDetails_Quantity CHECK ([Quantity]>(0)),
        CONSTRAINT CK_PurchaseOrderDetails_UnitCost CHECK ([UnitCost]>=(0)),
        CONSTRAINT FK_PurchaseOrderDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
        CONSTRAINT FK_PurchaseOrderDetails_PurchaseOrders FOREIGN KEY (PurchaseOrderId) REFERENCES dbo.PurchaseOrders(PurchaseOrderId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.Sales
-- ---------------------------------------------------------------------------
-- Identity: SaleId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.Sales', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Sales
    (
        SaleId int IDENTITY(1,1) NOT NULL,
        CashierUserId int NOT NULL,
        SaleDate datetime2(7) NOT NULL DEFAULT (sysdatetime()),
        Subtotal decimal(18,2) NOT NULL DEFAULT ((0)),
        DiscountAmount decimal(18,2) NOT NULL DEFAULT ((0)),
        TotalAmount decimal(18,2) NOT NULL DEFAULT ((0)),
        PaymentMethod nvarchar(20) NOT NULL,
        AmountReceived decimal(18,2) NULL,
        ChangeAmount decimal(18,2) NULL,
        Status nvarchar(20) NOT NULL DEFAULT ('Completed'),
        CONSTRAINT PK__Sales__1EE3C3FF0AFE4E0D PRIMARY KEY (SaleId),
        CONSTRAINT CK_Sales_DiscountAmount CHECK ([DiscountAmount]>=(0)),
        CONSTRAINT CK_Sales_PaymentMethod CHECK ([PaymentMethod]='QRCode' OR [PaymentMethod]='Cash'),
        CONSTRAINT CK_Sales_Status CHECK ([Status]='Refunded' OR [Status]='Cancelled' OR [Status]='Completed'),
        CONSTRAINT CK_Sales_Subtotal CHECK ([Subtotal]>=(0)),
        CONSTRAINT CK_Sales_TotalAmount CHECK ([TotalAmount]>=(0)),
        CONSTRAINT FK_Sales_Users FOREIGN KEY (CashierUserId) REFERENCES dbo.users(UserId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.InventoryTransactions
-- ---------------------------------------------------------------------------
-- Identity: InventoryTransactionId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.InventoryTransactions', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.InventoryTransactions
    (
        InventoryTransactionId int IDENTITY(1,1) NOT NULL,
        ProductId int NOT NULL,
        UserId int NOT NULL,
        TransactionType nvarchar(20) NOT NULL,
        QuantityChange int NOT NULL,
        SaleId int NULL,
        PurchaseOrderId int NULL,
        Notes nvarchar(255) NULL,
        CreatedAt datetime2(7) NOT NULL DEFAULT (sysutcdatetime()),
        CONSTRAINT PK_InventoryTransactions PRIMARY KEY (InventoryTransactionId),
        CONSTRAINT CK_InventoryTransactions_Quantity CHECK ([QuantityChange]<>(0)),
        CONSTRAINT CK_InventoryTransactions_Type CHECK ([TransactionType]='Adjustment' OR [TransactionType]='Return' OR [TransactionType]='Sale' OR [TransactionType]='Purchase'),
        CONSTRAINT FK_InventoryTransactions_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
        CONSTRAINT FK_InventoryTransactions_PurchaseOrders FOREIGN KEY (PurchaseOrderId) REFERENCES dbo.PurchaseOrders(PurchaseOrderId),
        CONSTRAINT FK_InventoryTransactions_Sales FOREIGN KEY (SaleId) REFERENCES dbo.Sales(SaleId),
        CONSTRAINT FK_InventoryTransactions_Users FOREIGN KEY (UserId) REFERENCES dbo.users(UserId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- dbo.SaleDetails
-- ---------------------------------------------------------------------------
-- Identity: SaleDetailId IDENTITY(1,1)
IF OBJECT_ID(N'dbo.SaleDetails', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SaleDetails
    (
        SaleDetailId int IDENTITY(1,1) NOT NULL,
        SaleId int NOT NULL,
        ProductId int NOT NULL,
        Quantity int NOT NULL,
        UnitPrice decimal(18,2) NOT NULL,
        DiscountAmount decimal(18,2) NOT NULL DEFAULT ((0)),
        LineSubtotal decimal(18,2) NOT NULL,
        CONSTRAINT PK__SaleDeta__70DB14FEBDC4687B PRIMARY KEY (SaleDetailId),
        CONSTRAINT CK_SaleDetails_DiscountAmount CHECK ([DiscountAmount]>=(0)),
        CONSTRAINT CK_SaleDetails_LineSubtotal CHECK ([LineSubtotal]>=(0)),
        CONSTRAINT CK_SaleDetails_Quantity CHECK ([Quantity]>(0)),
        CONSTRAINT CK_SaleDetails_UnitPrice CHECK ([UnitPrice]>=(0)),
        CONSTRAINT FK_SaleDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
        CONSTRAINT FK_SaleDetails_Sales FOREIGN KEY (SaleId) REFERENCES dbo.Sales(SaleId)
    );
END
GO

-- ---------------------------------------------------------------------------
-- Secondary indexes on dbo.Categories
-- ---------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'UQ_Categories_CategoryName'
      AND object_id = OBJECT_ID(N'dbo.Categories')
)
BEGIN
    CREATE UNIQUE INDEX UQ_Categories_CategoryName ON dbo.Categories
    (
        CategoryName
    )
;
END
GO

-- ---------------------------------------------------------------------------
-- Secondary indexes on dbo.Products
-- ---------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'UQ_Products_Barcode'
      AND object_id = OBJECT_ID(N'dbo.Products')
)
BEGIN
    CREATE UNIQUE INDEX UQ_Products_Barcode ON dbo.Products
    (
        Barcode
    )
    WHERE ([Barcode] IS NOT NULL)
;
END
GO

-- ---------------------------------------------------------------------------
-- Secondary indexes on dbo.users
-- ---------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'UQ_users_Username'
      AND object_id = OBJECT_ID(N'dbo.users')
)
BEGIN
    CREATE UNIQUE INDEX UQ_users_Username ON dbo.users
    (
        Username
    )
;
END
GO

-- ---------------------------------------------------------------------------
-- Secondary indexes on dbo.InventoryTransactions
-- ---------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_InventoryTransactions_Product_Created'
      AND object_id = OBJECT_ID(N'dbo.InventoryTransactions')
)
BEGIN
    CREATE INDEX IX_InventoryTransactions_Product_Created ON dbo.InventoryTransactions
    (
        ProductId,
        CreatedAt
    )
;
END

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_InventoryTransactions_PurchaseOrder'
      AND object_id = OBJECT_ID(N'dbo.InventoryTransactions')
)
BEGIN
    CREATE INDEX IX_InventoryTransactions_PurchaseOrder ON dbo.InventoryTransactions
    (
        PurchaseOrderId
    )
;
END

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_InventoryTransactions_Sale'
      AND object_id = OBJECT_ID(N'dbo.InventoryTransactions')
)
BEGIN
    CREATE INDEX IX_InventoryTransactions_Sale ON dbo.InventoryTransactions
    (
        SaleId
    )
;
END
GO

