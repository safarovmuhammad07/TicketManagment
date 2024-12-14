CREATE TABLE Tickets
(
    TicketId      SERIAL PRIMARY KEY,
    Type          VARCHAR(50)    NOT NULL,
    Title         VARCHAR(150)   NOT NULL,
    Price         DECIMAL(10, 2) NOT NULL,
    EventDateTime TIMESTAMP      NOT NULL
);

CREATE TABLE Customers
(
    CustomerId SERIAL PRIMARY KEY,
    FullName   VARCHAR(150) NOT NULL,
    Email      VARCHAR(150) NOT NULL UNIQUE,
    Phone      VARCHAR(20)  NOT NULL UNIQUE
);

CREATE TABLE Purchases
(
    PurchaseId       SERIAL PRIMARY KEY,
    TicketId         INT            NOT NULL REFERENCES Tickets (TicketId) ON DELETE CASCADE,
    CustomerId       INT            NOT NULL REFERENCES Customers (CustomerId) ON DELETE CASCADE,
    PurchaseDateTime TIMESTAMP      NOT NULL,
    Quantity         INT            NOT NULL CHECK (Quantity > 0),
    TotalPrice       DECIMAL(10, 2) NOT NULL CHECK (TotalPrice >= 0)
);

CREATE TABLE Locations
(
    LocationId   SERIAL PRIMARY KEY,
    City         VARCHAR(100) NOT NULL,
    Address      VARCHAR(200) NOT NULL,
    LocationType VARCHAR(50)  NOT NULL
);

CREATE TABLE TicketLocations
(
    TicketId   INT NOT NULL REFERENCES Tickets (TicketId) ON DELETE CASCADE,
    LocationId INT NOT NULL REFERENCES Locations (LocationId) ON DELETE CASCADE,
    PRIMARY KEY (TicketId, LocationId)
);
