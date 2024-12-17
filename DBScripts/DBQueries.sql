CREATE TABLE CandidateProfile (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL UNIQUE,
    education NVARCHAR(100),
    year_of_gradution NVARCHAR(4),
    fun_fact NVARCHAR(200)
);

INSERT INTO dbo.CandidateProfile (first_name, last_name, email, education, year_of_gradution, fun_fact) 
VALUES 
('John', 'Doe', 'john.doe@example.com', 'Bachelor of Science', 2020, 'Loves hiking.'),
('Jane', 'Smith', 'jane.smith@example.com', 'Master of Arts', 2019, 'Plays the guitar.'),
('Emily', 'Johnson', 'emily.johnson@example.com', 'PhD in Physics', 2021, 'Enjoys painting.'),
('Michael', 'Brown', 'michael.brown@example.com', 'Bachelor of Engineering', 2018, 'Avid traveler.'),
('Sarah', 'Davis', 'sarah.davis@example.com', 'Master of Business Administration', 2022, 'Loves cooking.');

-- Drop Table [dbo].[CandidateProfile]