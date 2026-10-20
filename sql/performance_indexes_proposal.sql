/*
    PERF INDEX PROPOSAL - NOT EXECUTED
    ---------------------------------
    This file is a review proposal only. It was written during the overnight
    performance pass and has NOT been run against any database. Review the
    workload and validate on a copy before applying.

    All statements are guarded with IF NOT EXISTS so the script is re-runnable.
    No data is modified: only nonclustered indexes are proposed.

    Rationale: every screen opens a fresh SqlConnection to a remote server, so
    each round trip costs roughly 230 ms. Batching queries (already done for the
    dashboard, reports totals and stock alerts) removed redundant round trips.
    These indexes target the remaining per-query scans, especially the
    date/status filters and detail joins used by reports and purchases.
*/

/* 1. Sales: dashboard ranges, trends, payment mix, cashier revenue, history. */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_Sales_Status_SaleDate'
      AND object_id = OBJECT_ID('dbo.Sales')
)
CREATE NONCLUSTERED INDEX IX_Sales_Status_SaleDate
    ON dbo.Sales (Status, SaleDate)
    INCLUDE (TotalAmount, CashierUserId, PaymentMethod);
GO

/* 2. SaleDetails: sale header/detail joins and sale detail lookup. */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_SaleDetails_SaleId'
      AND object_id = OBJECT_ID('dbo.SaleDetails')
)
CREATE NONCLUSTERED INDEX IX_SaleDetails_SaleId
    ON dbo.SaleDetails (SaleId)
    INCLUDE (ProductId, Quantity, UnitPrice, DiscountAmount, LineSubtotal);
GO

/* 3. SaleDetails: sales-by-product, top products, sales-by-category. */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_SaleDetails_ProductId'
      AND object_id = OBJECT_ID('dbo.SaleDetails')
)
CREATE NONCLUSTERED INDEX IX_SaleDetails_ProductId
    ON dbo.SaleDetails (ProductId)
    INCLUDE (SaleId, Quantity, LineSubtotal);
GO

/* 4. PurchaseOrders: supplier purchase history and recent order listings. */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_PurchaseOrders_Status_PurchaseDate'
      AND object_id = OBJECT_ID('dbo.PurchaseOrders')
)
CREATE NONCLUSTERED INDEX IX_PurchaseOrders_Status_PurchaseDate
    ON dbo.PurchaseOrders (Status, PurchaseDate)
    INCLUDE (SupplierId, TotalAmount);
GO

/* 5. PurchaseOrderDetails: receive workflow and GetById detail load. */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_PurchaseOrderDetails_PurchaseOrderId'
      AND object_id = OBJECT_ID('dbo.PurchaseOrderDetails')
)
CREATE NONCLUSTERED INDEX IX_PurchaseOrderDetails_PurchaseOrderId
    ON dbo.PurchaseOrderDetails (PurchaseOrderId)
    INCLUDE (ProductId, Quantity, UnitCost, LineSubtotal);
GO

/* 6. Products: low stock and out of stock lists (filtered to active rows). */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_Products_Active_Stock'
      AND object_id = OBJECT_ID('dbo.Products')
)
CREATE NONCLUSTERED INDEX IX_Products_Active_Stock
    ON dbo.Products (StockQuantity, ReorderLevel)
    INCLUDE (ProductName)
    WHERE IsActive = 1;
GO

/* 7. Products: expiring soon and expired lists (filtered to active rows). */
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_Products_Active_Expiry'
      AND object_id = OBJECT_ID('dbo.Products')
)
CREATE NONCLUSTERED INDEX IX_Products_Active_Expiry
    ON dbo.Products (ExpiryDate)
    INCLUDE (ProductName, StockQuantity)
    WHERE IsActive = 1 AND ExpiryDate IS NOT NULL;
GO

/*
    8. InventoryTransactions: "Inventory History" orders by CreatedAt alone.
       The existing IX_InventoryTransactions_Product_Created leads on ProductId,
       so it cannot serve this global ordering.
*/
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_InventoryTransactions_CreatedAt'
      AND object_id = OBJECT_ID('dbo.InventoryTransactions')
)
CREATE NONCLUSTERED INDEX IX_InventoryTransactions_CreatedAt
    ON dbo.InventoryTransactions (CreatedAt DESC)
    INCLUDE (
        ProductId,
        UserId,
        TransactionType,
        QuantityChange,
        SaleId,
        PurchaseOrderId,
        Notes
    );
GO

/*
    Optional follow-ups to consider only if join plans stay poor at scale
    (Products is small today, so these are intentionally omitted above):
      - IX_Products_CategoryId on dbo.Products (CategoryId)
      - IX_Products_SupplierId on dbo.Products (SupplierId)
      - IX_Sales_CashierUserId on dbo.Sales (CashierUserId)
*/
