CREATE TABLE CandidateProfile (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL UNIQUE,
    Education NVARCHAR(100),
    yearOfGradution NVARCHAR(4),
    funFact NVARCHAR(200)
);

INSERT INTO dbo.CandidateProfile (FirstName, LastName, Email, Education, yearOfGradution, funFact) 
VALUES 
('John', 'Doe', 'john.doe@example.com', 'Bachelor of Science', 2020, 'Loves hiking.'),
('Jane', 'Smith', 'jane.smith@example.com', 'Master of Arts', 2019, 'Plays the guitar.'),
('Emily', 'Johnson', 'emily.johnson@example.com', 'PhD in Physics', 2021, 'Enjoys painting.'),
('Michael', 'Brown', 'michael.brown@example.com', 'Bachelor of Engineering', 2018, 'Avid traveler.'),
('Sarah', 'Davis', 'sarah.davis@example.com', 'Master of Business Administration', 2022, 'Loves cooking.');

-- Drop Table [dbo].[CandidateProfile]