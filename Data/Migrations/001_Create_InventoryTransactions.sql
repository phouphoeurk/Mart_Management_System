SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;

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
            FOREIGN KEY (UserId) REFERENCES dbo.users(UserId),
        CONSTRAINT FK_InventoryTransactions_Sales
            FOREIGN KEY (SaleId) REFERENCES dbo.Sales(SaleId),
        CONSTRAINT FK_InventoryTransactions_PurchaseOrders
            FOREIGN KEY (PurchaseOrderId) REFERENCES dbo.PurchaseOrders(PurchaseOrderId)
    );

    CREATE INDEX IX_InventoryTransactions_Product_Created
        ON dbo.InventoryTransactions(ProductId, CreatedAt);

    CREATE INDEX IX_InventoryTransactions_Sale
        ON dbo.InventoryTransactions(SaleId);

    CREATE INDEX IX_InventoryTransactions_PurchaseOrder
        ON dbo.InventoryTransactions(PurchaseOrderId);
END
