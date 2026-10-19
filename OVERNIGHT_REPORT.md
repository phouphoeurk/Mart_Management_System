# Overnight Performance Report (STEP 2)

Branch: `feature/ui-dashboard-purchase-reports`
Scope: perf-only pass on top of the existing UI work. `main` was never touched (no checkout/switch/merge/rebase/push/reset/clean/force/delete).

## 1. Commits added this session

```
5360c8f perf(sql): add review proposal for missing indexes
0174470 perf(pos): debounce barcode search and flush on Enter
7e7d149 perf(ui): debounce list search to avoid a query per keystroke
```

Context (already on the branch before this session): `72e9220`, `654fc74`, `780d267`, `4a6463f`, `5fccd24`, `07b20f2`, `d14d9b3`, `cc8cb17` and earlier UI work. A "STEP 2" todo file did not exist in the repo, so the remaining items were reconstructed from the checkpoint (`654fc74`), the `PerfTimer` instrumentation (`d14d9b3`) and the code itself.

## 2. Decisions made autonomously (no user available)

1. Reconstructed the todo list as: search debounce, POS barcode debounce, SQL index proposal, measurements, this report.
2. `SearchDebouncer` is a new shared helper (`UI/SearchDebouncer.cs`) using the built-in WinForms `Timer`; no new libraries.
3. `SupplierForm` was included in the search debounce even though the checklist only names Products/Users/Categories. It had the identical query-per-keystroke problem; this is a small, same-pattern change.
4. POS: Enter now flushes the pending search immediately (no cart side effects). Existing barcode/search filtering behavior is unchanged.
5. Measurements use a read-only harness under `bin/PerfHarness/` (gitignored, excluded from the main project compile). It only reads; it never inserts/updates/deletes/creates indexes.
6. Index work is a proposal file only (`sql/performance_indexes_proposal.sql`); nothing was executed.
7. `appsettings.json`, `opencode.json`, `_PerfHarness` were never staged; no connection string or password was printed.

## 3. Before / after timing table

Environment: Release harness against the configured remote SQL Server. Every repository call opens a fresh `SqlConnection`, so a single round trip costs roughly 230-240 ms. Values are milliseconds; "avg" over 12 runs after a warm-up (min in parentheses). "Before" for batched screens replicates the previous multi-query path; "before" for typing counts one query per keystroke.

| Scenario | Before (avg / min) | After (avg / min) | Round trips |
|---|---|---|---|
| Dashboard 1 Day | 1957.4 / 1868.9 | 241.8 / 238.0 | 8 -> 1 |
| Dashboard 1 Week | 1917.6 / 1868.8 | 240.9 / 237.5 | 8 -> 1 |
| Dashboard 1 Month | 1872.3 / 1867.0 | 239.7 / 237.3 | 8 -> 1 |
| Reports period totals | 940.1 / 935.2 | 235.0 / 232.9 | 4 -> 1 |
| Stock Alerts snapshot | 1178.6 / 1166.9 | 236.8 / 234.9 | 5 -> 1 |
| Sales History list | n/a (already 1 query) | 233-333 | 1 |
| Purchases page load | n/a (already 1 query) | 235.5 / 233.8 | 1 |
| Reports: all 10 types | n/a (1 query each) | 233-236 each | 1 each |
| Products search, 6 keystrokes | 1451.1 / 1399.3 | ~233 + <=250 ms debounce | 6 -> 1 |
| Categories search, 6 keystrokes | 1400.2 / 1394.4 | ~232 + <=250 ms debounce | 6 -> 1 |
| Suppliers search, 6 keystrokes | 1489.7 / 1397.4 | ~233 + <=250 ms debounce | 6 -> 1 |
| Users search, 6 keystrokes | 1428.8 / 1397.3 | ~232 + <=250 ms debounce | 6 -> 1 |
| POS barcode scan, 6 keystrokes | 1406.1 / 1398.7 | ~234 + flush on Enter | 6 -> 1 |

The dashboard, reports-total and stock-alert batching landed in the earlier perf commits on this branch; this session added the search/barcode debounce. Net effect of the search change: database work for a 6-character search drops from ~1.4 s to ~0.23 s, at the cost of up to 250 ms after the last keystroke (Enter in POS skips the wait).

## 4. Skipped items and reasons

- Purchase Order Save Draft / Receive timings: skipped. These are write paths and rule 5 forbids any INSERT/UPDATE/DELETE against the real database. The code was left unchanged (single transaction; one command per detail line) to preserve behavior.
- Applying the proposed indexes: skipped by design. Rule 5 requires a proposal only.
- Reworking reports to merge the two sequential calls on load (totals + selected report): skipped as risky for little gain (two round trips either way).
- Index creation, query-plan capture and any schema change: not attempted.

## 5. Risks

- Debounce adds up to 250 ms before a list refreshes after the user stops typing. POS Enter flushes immediately, so scanning is not affected.
- `SearchDebouncer` uses a WinForms `Timer` on the UI thread and is disposed in `FormClosed`; if a form is shown without a message pump the timer would not tick (all app forms run under a message loop).
- The proposed indexes add write cost to Sales/SaleDetails/Products/InventoryTransactions. Review and validate on a copy before applying.
- `bin/PerfHarness/` holds the temporary harness (already covered by `bin/` ignore). It does not affect the application build.
- Timing depends on network latency to the remote SQL Server (~230 ms/round trip); absolute numbers will differ on a local server, though the round-trip reductions hold.

## 6. Manual test checklist

- [ ] Dashboard: switch 1 Day / 1 Week / 1 Month and confirm KPIs, deltas and chart update without errors.
- [ ] Reports: generate all 10 types (Sales Trend, Revenue by Cashier, Revenue by Payment Method, Top Products, Sales by Category, Sales by Product, Supplier Purchase History, Inventory Value, Low Stock Report, Profit Report).
- [ ] Purchases: Save Draft, then Receive; confirm stock updates and the past-orders panel refreshes.
- [ ] Sales History: confirm cashier full names display (username fallback when FullName is empty).
- [ ] Products / Users / Categories search: type and confirm the list refreshes about a quarter second after typing stops; test Enter and clearing the box.
- [ ] POS: scan/type a barcode and press Enter; confirm the product list filters and no accidental action fires.
- [ ] Reports export (CSV) and print preview still work.

## 7. How the numbers were produced

Read-only harness at `bin/PerfHarness/Program.cs` (gitignored). It references the project, calls the read-only repository methods, and times each with `Stopwatch` (warm-up + 12 iterations, min/avg). It opens a normal `SqlConnection` and performs `SELECT`/`ExecuteReader` only. No write statement is issued and no index is created.
