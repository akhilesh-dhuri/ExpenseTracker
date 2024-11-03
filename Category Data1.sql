use TransactionDB;



INSERT INTO Categories (Title, Icon, Type) VALUES
('Groceries', N'🛒', 'Expense'),
('Rent', N'🏠', 'Expense'),
('Utilities', N'💡', 'Expense'),
('Dining Out', N'🍽️', 'Expense'),
('Entertainment', N'🎬', 'Expense'),
('Travel', N'✈️', 'Expense'),
('Clothing', N'👗', 'Expense'),
('Healthcare', N'🏥', 'Expense'),
('Education', N'📚', 'Expense'),
('Insurance', N'🛡️', 'Expense'),
('Transportation', N'🚗', 'Expense'),
('Subscriptions', N'📺', 'Expense'),
('Personal Care', N'💅', 'Expense'),
('Gifts', N'🎁', 'Expense'),
('Pets', N'🐾', 'Expense');


INSERT INTO Categories (Title, Icon, Type) VALUES
('Salary', N'💼', 'Income'),
('Freelance', N'🖥️', 'Income'),
('Investments', N'📈', 'Income'),
('Rental Income', N'🏢', 'Income'),
('Dividends', N'💵', 'Income');


select * from Transactions;
select * from Categories;


INSERT INTO Transactions (CategoryId, Amount, Note, Date)
VALUES
    (11, 150, 'Grocery shopping', '2024-11-01 14:30:00'),
    (12, 75, 'Monthly subscription', '2024-11-02 09:15:00'),
    (13, 200, 'Dinner with friends', '2024-11-03 19:45:00'),
    (14, 50, 'Taxi fare', '2024-11-04 08:00:00'),
    (17, 300, 'New shoes', '2024-11-05 16:20:00'),
    (18, 120, 'Electricity bill', '2024-11-06 10:00:00'),
    (19, 450, 'Weekend getaway', '2024-11-07 18:30:00'),
    (20, 60, 'Coffee and snacks', '2024-11-08 11:00:00'),
    (21, 500, 'Concert tickets', '2024-11-09 20:00:00'),
    (22, 90, 'Gym membership', '2024-11-10 07:30:00'),
    (23, 250, 'Online course', '2024-11-11 13:00:00'),
    (24, 40, 'Book purchase', '2024-11-12 15:45:00'),
    (25, 350, 'Home repairs', '2024-11-13 12:00:00'),
    (26, 80, 'Pet supplies', '2024-11-14 17:10:00'),
    (27, 100, 'Gas refill', '2024-11-15 09:00:00'),
    (28, 200, 'Gifts for family', '2024-11-16 14:00:00');




-- Generate random data
DECLARE @i INT = 0;
DECLARE @max INT = 20; -- Number of records to insert

WHILE @i < @max
BEGIN
    INSERT INTO Transactions (CategoryId, Amount, Note, Date)
    VALUES
    (11, ROUND(RAND() * (9000) + 1000, 0), 'Monthly salary payment', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (12, ROUND(RAND() * (500) + 50, 0), 'Travel expenses', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (13, ROUND(RAND() * (300) + 50, 0), 'Grocery shopping', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (14, ROUND(RAND() * (1500) + 800, 0), 'Rent payment', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (17, ROUND(RAND() * (200) + 50, 0), 'Utilities bill', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (18, ROUND(RAND() * (150) + 20, 0), 'Dining out', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (19, ROUND(RAND() * (300) + 30, 0), 'Entertainment', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (20, ROUND(RAND() * (500) + 50, 0), 'Travel expenses', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (21, ROUND(RAND() * (200) + 30, 0), 'Clothing purchase', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (22, ROUND(RAND() * (300) + 50, 0), 'Healthcare services', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (23, ROUND(RAND() * (800) + 100, 0), 'Education expenses', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (24, ROUND(RAND() * (400) + 100, 0), 'Insurance premium', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (25, ROUND(RAND() * (100) + 20, 0), 'Transportation costs', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (26, ROUND(RAND() * (50) + 5, 0), 'Subscription fees', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (27, ROUND(RAND() * (100) + 20, 0), 'Personal care items', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (28, ROUND(RAND() * (200) + 30, 0), 'Gift purchase', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (29, ROUND(RAND() * (100) + 10, 0), 'Pet supplies', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (31, ROUND(RAND() * (2000) + 500, 0), 'Freelance project', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (32, ROUND(RAND() * (1500) + 100, 0), 'Investments', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (33, ROUND(RAND() * (1000) + 300, 0), 'Rental income', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE())),
    (34, ROUND(RAND() * (400) + 50, 0), 'Dividends', DATEADD(DAY, -CEILING(RAND() * 30), GETDATE()));

    SET @i = @i + 1;
END

-- Generate random data
DECLARE @i INT = 0;
DECLARE @max INT = 20; -- Number of records to insert

WHILE @i < @max
BEGIN
    INSERT INTO Transactions (CategoryId, Amount, Note, Date)
    VALUES
    (
        -- Randomly select a CategoryId from the specified list
        (SELECT TOP 1 CategoryId FROM (VALUES (11), (12), (13), (14), (17), (18), (19), (20), (21), (22), (23), (24), (25), (26), (27), (28), (29), (31), (32), (33), (34)) AS Categories(CategoryId) ORDER BY NEWID()),
        -- Generate a random amount
        ROUND(RAND() * (1000) + 50, 0),
        -- Randomly select a note from a list of possible notes
        (SELECT TOP 1 Note FROM (VALUES ('Salary payment'), ('Travel expenses'), ('Grocery shopping'), ('Rent payment'), ('Utilities bill'), ('Dining out'), ('Entertainment'), ('Clothing purchase'), ('Healthcare services'), ('Education expenses'), ('Insurance premium'), ('Transportation costs'), ('Subscription fees'), ('Personal care items'), ('Gift purchase'), ('Pet supplies'), ('Freelance project'), ('Investments'), ('Rental income'), ('Dividends')) AS Notes(Note) ORDER BY NEWID()),
        -- Generate a random date within the last 30 days
        DATEADD(DAY, -FLOOR(RAND() * 30), GETDATE())
    );

    SET @i = @i + 1;
END