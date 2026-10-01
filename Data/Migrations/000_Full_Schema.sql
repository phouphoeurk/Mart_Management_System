-- ============================================================================
-- 000_Full_Schema.sql
--
-- Complete database schema for Mart Management System.
--
-- Derived from the column types, lengths and nullability actually used by the
-- Repository mapping code (parameter sizes in AddParameters/Add*Parameters and
-- the reader.Get* accessors in the Map* methods).
--
-- Covers all 9 tables:
--   1. dbo.Users
--   2. dbo.Categories
--   3. dbo.Suppliers
--   4. dbo.Products
--   5. dbo.Sales
--   6. dbo.SaleDetails
--   7. dbo.PurchaseOrders
--   8. dbo.PurchaseOrderDetails
--   9. dbo.InventoryTransactions
--
-- Every block is guarded so the script can be re-run safely against an existing
-- database without failing on objects that are already present.
-- ============================================================================

SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

-- ---------------------------------------------------------------------------
-- 1. dbo.Users
--    UserRepository: NVarChar(150) FullName, NVarChar(50) Username,
--    NVarChar(255) PasswordHash, NVarChar(20) Role, Bit IsActive,
--    DateTime2 CreatedAt/UpdatedAt.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        UserId INT IDENTITY(1,1) NOT NULL,
        FullName NVARCHAR(150) NOT NULL,
        Username NVARCHAR(50) NOT NULL,
        PasswordHash NVARCHAR(255) NOT NULL,
        Role NVARCHAR(20) NOT NULL,
        IsActive BIT NOT NULL
            CONSTRAINT DF_Users_IsActive
            DEFAULT (1),
        CreatedAt DATETIME2 NOT NULL
            CONSTRAINT DF_Users_CreatedAt
            DEFAULT (SYSUTCDATETIME()),
        UpdatedAt DATETIME2 NOT NULL
            CONSTRAINT DF_Users_UpdatedAt
            DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_Users
            PRIMARY KEY (UserId),
        CONSTRAINT CK_Users_Role
            CHECK (Role IN ('Admin', 'Cashier')),
        CONSTRAINT CK_Users_Username
            CHECK (LEN(LTRIM(RTRIM(Username))) > 0)
    );

    CREATE UNIQUE INDEX UX_Users_Username
        ON dbo.Users(Username);
END
GO

-- ---------------------------------------------------------------------------
-- 2. dbo.Categories
--    CategoryRepository: NVarChar(100) CategoryName, NVarChar(255) nullable
--    Description, Bit IsActive, DateTime2 CreatedAt.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Categories', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categories
    (
        CategoryId INT IDENTITY(1,1) NOT NULL,
        CategoryName NVARCHAR(100) NOT NULL,
        Description NVARCHAR(255) NULL,
        IsActive BIT NOT NULL
            CONSTRAINT DF_Categories_IsActive
            DEFAULT (1),
        CreatedAt DATETIME2 NOT NULL
            CONSTRAINT DF_Categories_CreatedAt
            DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_Categories
            PRIMARY KEY (CategoryId),
        CONSTRAINT CK_Categories_Name
            CHECK (LEN(LTRIM(RTRIM(CategoryName))) > 0)
    );

    CREATE INDEX IX_Categories_Name
        ON dbo.Categories(CategoryName);
END
GO

-- ---------------------------------------------------------------------------
-- 3. dbo.Suppliers
--    SupplierRepository: NVarChar(150) SupplierName, NVarChar(30) nullable
--    Phone, NVarChar(150) nullable Email, NVarChar(255) nullable Address,
--    Bit IsActive, DateTime2 CreatedAt.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Suppliers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Suppliers
    (
        SupplierId INT IDENTITY(1,1) NOT NULL,
        SupplierName NVARCHAR(150) NOT NULL,
        Phone NVARCHAR(30) NULL,
        Email NVARCHAR(150) NULL,
        Address NVARCHAR(255) NULL,
        IsActive BIT NOT NULL
            CONSTRAINT DF_Suppliers_IsActive
            DEFAULT (1),
        CreatedAt DATETIME2 NOT NULL
            CONSTRAINT DF_Suppliers_CreatedAt
            DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_Suppliers
            PRIMARY KEY (SupplierId),
        CONSTRAINT CK_Suppliers_Name
            CHECK (LEN(LTRIM(RTRIM(SupplierName))) > 0)
    );

    CREATE INDEX IX_Suppliers_Name
        ON dbo.Suppliers(SupplierName);
END
GO

-- ---------------------------------------------------------------------------
-- 4. dbo.Products
--    ProductRepository: NVarChar(150) ProductName, NVarChar(50) nullable
--    Barcode, Int CategoryId (required), Int nullable SupplierId,
--    Decimal CostPrice/SellingPrice, Int StockQuantity/ReorderLevel,
--    nullable DateTime2 ExpiryDate, Bit IsActive, DateTime2 CreatedAt.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        ProductId INT IDENTITY(1,1) NOT NULL,
        ProductName NVARCHAR(150) NOT NULL,
        Barcode NVARCHAR(50) NULL,
        CategoryId INT NOT NULL,
        SupplierId INT NULL,
        CostPrice DECIMAL(18,2) NOT NULL,
        SellingPrice DECIMAL(18,2) NOT NULL,
        StockQuantity INT NOT NULL
            CONSTRAINT DF_Products_StockQuantity
            DEFAULT (0),
        ReorderLevel INT NOT NULL
            CONSTRAINT DF_Products_ReorderLevel
            DEFAULT (0),
        ExpiryDate DATETIME2 NULL,
        IsActive BIT NOT NULL
            CONSTRAINT DF_Products_IsActive
            DEFAULT (1),
        CreatedAt DATETIME2 NOT NULL
            CONSTRAINT DF_Products_CreatedAt
            DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_Products
            PRIMARY KEY (ProductId),
        CONSTRAINT CK_Products_StockQuantity
            CHECK (StockQuantity >= 0),
        CONSTRAINT CK_Products_ReorderLevel
            CHECK (ReorderLevel >= 0),
        CONSTRAINT CK_Products_Prices
            CHECK (CostPrice >= 0 AND SellingPrice >= 0),
        CONSTRAINT FK_Products_Categories
            FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(CategoryId),
        CONSTRAINT FK_Products_Suppliers
            FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId)
    );

    CREATE INDEX IX_Products_Category
        ON dbo.Products(CategoryId);

    CREATE INDEX IX_Products_Supplier
        ON dbo.Products(SupplierId);

    CREATE INDEX IX_Products_Name
        ON dbo.Products(ProductName);

    CREATE INDEX IX_Products_StockAlerts
        ON dbo.Products(IsActive, StockQuantity, ReorderLevel);
END
GO

-- ---------------------------------------------------------------------------
-- 5. dbo.Sales
--    SalesRepository: Int CashierUserId, DateTime2 SaleDate,
--    Decimal Subtotal/DiscountAmount/TotalAmount, NVarChar(20) PaymentMethod,
--    nullable Decimal AmountReceived/ChangeAmount, NVarChar(20) Status.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Sales', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Sales
    (
        SaleId INT IDENTITY(1,1) NOT NULL,
        CashierUserId INT NOT NULL,
        SaleDate DATETIME2 NOT NULL,
        Subtotal DECIMAL(18,2) NOT NULL,
        DiscountAmount DECIMAL(18,2) NOT NULL,
        TotalAmount DECIMAL(18,2) NOT NULL,
        PaymentMethod NVARCHAR(20) NOT NULL,
        AmountReceived DECIMAL(18,2) NULL,
        ChangeAmount DECIMAL(18,2) NULL,
        Status NVARCHAR(20) NOT NULL
            CONSTRAINT DF_Sales_Status
            DEFAULT ('Completed'),
        CONSTRAINT PK_Sales
            PRIMARY KEY (SaleId),
        CONSTRAINT CK_Sales_PaymentMethod
            CHECK (PaymentMethod IN ('Cash', 'QRCode')),
        CONSTRAINT CK_Sales_Status
            CHECK (Status IN ('Completed', 'Cancelled', 'Refunded')),
        CONSTRAINT CK_Sales_Discount
            CHECK (DiscountAmount >= 0 AND DiscountAmount <= Subtotal),
        CONSTRAINT CK_Sales_Total
            CHECK (TotalAmount >= 0),
        CONSTRAINT CK_Sales_Cash
            CHECK (PaymentMethod <> 'Cash'
                   OR (AmountReceived IS NOT NULL AND AmountReceived >= TotalAmount)),
        CONSTRAINT FK_Sales_Users
            FOREIGN KEY (CashierUserId) REFERENCES dbo.Users(UserId)
    );

    CREATE INDEX IX_Sales_Cashier_Date
        ON dbo.Sales(CashierUserId, SaleDate);

    CREATE INDEX IX_Sales_Status_Date
        ON dbo.Sales(Status, SaleDate);
END
GO

-- ---------------------------------------------------------------------------
-- 6. dbo.SaleDetails
--    SalesRepository detail insert: Int SaleId/ProductId/Quantity,
--    Decimal UnitPrice/DiscountAmount/LineSubtotal.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.SaleDetails', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SaleDetails
    (
        SaleDetailId INT IDENTITY(1,1) NOT NULL,
        SaleId INT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(18,2) NOT NULL,
        DiscountAmount DECIMAL(18,2) NOT NULL
            CONSTRAINT DF_SaleDetails_DiscountAmount
            DEFAULT (0),
        LineSubtotal DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_SaleDetails
            PRIMARY KEY (SaleDetailId),
        CONSTRAINT CK_SaleDetails_Quantity
            CHECK (Quantity > 0),
        CONSTRAINT CK_SaleDetails_Prices
            CHECK (UnitPrice >= 0 AND DiscountAmount >= 0 AND LineSubtotal >= 0),
        CONSTRAINT FK_SaleDetails_Sales
            FOREIGN KEY (SaleId) REFERENCES dbo.Sales(SaleId),
        CONSTRAINT FK_SaleDetails_Products
            FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId)
    );

    CREATE INDEX IX_SaleDetails_Sale
        ON dbo.SaleDetails(SaleId);

    CREATE INDEX IX_SaleDetails_Product
        ON dbo.SaleDetails(ProductId);
END
GO

-- ---------------------------------------------------------------------------
-- 7. dbo.PurchaseOrders
--    PurchaseOrderRepository: Int SupplierId/CreatedByUserId,
--    DateTime2 PurchaseDate, NVarChar(20) Status,
--    Decimal Subtotal/DiscountAmount/TotalAmount.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.PurchaseOrders', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PurchaseOrders
    (
        PurchaseOrderId INT IDENTITY(1,1) NOT NULL,
        SupplierId INT NOT NULL,
        CreatedByUserId INT NOT NULL,
        PurchaseDate DATETIME2 NOT NULL,
        Status NVARCHAR(20) NOT NULL
            CONSTRAINT DF_PurchaseOrders_Status
            DEFAULT ('Draft'),
        Subtotal DECIMAL(18,2) NOT NULL,
        DiscountAmount DECIMAL(18,2) NOT NULL
            CONSTRAINT DF_PurchaseOrders_DiscountAmount
            DEFAULT (0),
        TotalAmount DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_PurchaseOrders
            PRIMARY KEY (PurchaseOrderId),
        CONSTRAINT CK_PurchaseOrders_Status
            CHECK (Status IN ('Draft', 'Received', 'Cancelled')),
        CONSTRAINT CK_PurchaseOrders_Discount
            CHECK (DiscountAmount >= 0 AND DiscountAmount <= Subtotal),
        CONSTRAINT CK_PurchaseOrders_Total
            CHECK (TotalAmount >= 0),
        CONSTRAINT FK_PurchaseOrders_Suppliers
            FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId),
        CONSTRAINT FK_PurchaseOrders_Users
            FOREIGN KEY (CreatedByUserId) REFERENCES dbo.Users(UserId)
    );

    CREATE INDEX IX_PurchaseOrders_Supplier
        ON dbo.PurchaseOrders(SupplierId);

    CREATE INDEX IX_PurchaseOrders_Status_Date
        ON dbo.PurchaseOrders(Status, PurchaseDate);
END
GO

-- ---------------------------------------------------------------------------
-- 8. dbo.PurchaseOrderDetails
--    PurchaseOrderRepository detail insert: Int PurchaseOrderId/ProductId/
--    Quantity, Decimal UnitCost/LineSubtotal.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.PurchaseOrderDetails', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PurchaseOrderDetails
    (
        PurchaseOrderDetailId INT IDENTITY(1,1) NOT NULL,
        PurchaseOrderId INT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT NOT NULL,
        UnitCost DECIMAL(18,2) NOT NULL,
        LineSubtotal DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_PurchaseOrderDetails
            PRIMARY KEY (PurchaseOrderDetailId),
        CONSTRAINT CK_PurchaseOrderDetails_Quantity
            CHECK (Quantity > 0),
        CONSTRAINT CK_PurchaseOrderDetails_Cost
            CHECK (UnitCost >= 0 AND LineSubtotal >= 0),
        CONSTRAINT FK_PurchaseOrderDetails_PurchaseOrders
            FOREIGN KEY (PurchaseOrderId)
            REFERENCES dbo.PurchaseOrders(PurchaseOrderId),
        CONSTRAINT FK_PurchaseOrderDetails_Products
            FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId)
    );

    CREATE INDEX IX_PurchaseOrderDetails_PurchaseOrder
        ON dbo.PurchaseOrderDetails(PurchaseOrderId);

    CREATE INDEX IX_PurchaseOrderDetails_Product
        ON dbo.PurchaseOrderDetails(ProductId);
END
GO

-- ---------------------------------------------------------------------------
-- 9. dbo.InventoryTransactions
--    InventoryRepository: Int ProductId/UserId, NVarChar(20) TransactionType,
--    Int QuantityChange, nullable Int SaleId/PurchaseOrderId,
--    NVarChar(255) nullable Notes, DateTime2 CreatedAt.
--
--    Mirrors 001_Create_InventoryTransactions.sql so this file is a complete
--    standalone snapshot of the schema.
-- ---------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.InventoryTransactions', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.InventoryTransactions
    (
        InventoryTransactionId INT IDENTITY(1,1) NOT NULL,
        ProductId INT NOT NULL,
        UserId INT NOT NULL,
        TransactionType NVARCHAR(20) NOT NULL,
        QuantityChange INT NOT NULL,
        SaleId INT NULL,
        PurchaseOrderId INT NULL,
        Notes NVARCHAR(255) NULL,
        CreatedAt DATETIME2 NOT NULL
            CONSTRAINT DF_InventoryTransactions_CreatedAt
            DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_InventoryTransactions
            PRIMARY KEY (InventoryTransactionId),
        CONSTRAINT CK_InventoryTransactions_Type
            CHECK (TransactionType IN ('Purchase', 'Sale', 'Return', 'Adjustment')),
        CONSTRAINT CK_InventoryTransactions_Quantity
            CHECK (QuantityChange <> 0),
        CONSTRAINT FK_InventoryTransactions_Products
            FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
        CONSTRAINT FK_InventoryTransactions_Users
            FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId),
        CONSTRAINT FK_InventoryTransactions_Sales
            FOREIGN KEY (SaleId) REFERENCES dbo.Sales(SaleId),
        CONSTRAINT FK_InventoryTransactions_PurchaseOrders
            FOREIGN KEY (PurchaseOrderId)
            REFERENCES dbo.PurchaseOrders(PurchaseOrderId)
    );

    CREATE INDEX IX_InventoryTransactions_Product_Created
        ON dbo.InventoryTransactions(ProductId, CreatedAt);

    CREATE INDEX IX_InventoryTransactions_Sale
        ON dbo.InventoryTransactions(SaleId);

    CREATE INDEX IX_InventoryTransactions_PurchaseOrder
        ON dbo.InventoryTransactions(PurchaseOrderId);
END
GO
