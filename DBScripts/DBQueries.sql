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

CREATE TABLE Skills (
    id INT PRIMARY KEY IDENTITY(1,1),
    skill NVARCHAR(100)
);

INSERT INTO Skills (skill) VALUES
('Python'),
('Java'),
('JavaScript'),
('C++'),
('C#'),
('Go'),
('TypeScript'),
('Kotlin'),
('Swift'),
('PHP'),
('SQL'),
('PostgreSQL'),
('MySQL'),
('MongoDB'),
('SQLite'),
('AWS'),
('Microsoft Azure'),
('Google Cloud Platform'),
('Docker'),
('Kubernetes'),
('Terraform'),
('React.js'),
('Angular'),
('Vue.js'),
('Node.js'),
('Express.js'),
('Tailwind CSS'),
('HTML5'),
('CSS3'),
('Flutter'),
('React Native'),
('SwiftUI'),
('TensorFlow'),
('PyTorch'),
('Pandas'),
('NumPy'),
('Scikit-learn'),
('Git'),
('GitHub'),
('Jenkins'),
('Bash/Shell Scripting'),
('Linux'),
('RESTful APIs'),
('GraphQL'),
('Microservices Architecture'),
('Event-Driven Architecture'),
('JUnit'),
('Selenium'),
('Postman'),
('Cypress'),
('Jest'),
('Clean Architecture'),
('Domain-Driven Design (DDD)'),
('SOLID Principles'),
('CI/CD Pipelines'),
('Prometheus'),
('Grafana'),
('Redis'),
('Spring Boot'),
('ASP.NET Core'),
('Django'),
('Flask'),
('FastAPI'),
('Entity Framework'),
('Android Development'),
('iOS Development'),
('OpenCV'),
('Agile Development'),
('Communication Skills'),
('Team Collaboration'),
('Problem-Solving'),
('Critical Thinking'),
('Time Management'),
('Adaptability'),
('Leadership'),
('Creativity'),
('Emotional Intelligence'),
('Conflict Resolution'),
('Active Listening'),
('Decision-Making'),
('Presentation Skills'),
('Mentoring and Coaching'),
('Feedback Management'),
('Cross-Functional Collaboration'),
('Accountability'),
('Resilience'),
('Goal Setting'),
('Negotiation Skills'),
('Continuous Learning'),
('Stress Management'),
('Empathy'),
('Stakeholder Management'),
('Proactive Mindset'),
('Analytical Thinking'),
('Planning and Organization'),
('Self-Motivation'),
('Initiative'),
('Collaboration Tools (Slack, Teams)'),
('Conflict Management'),
('Public Speaking');


CREATE TABLE Teams (
    id INT IDENTITY(1,1) PRIMARY KEY,
    team_name NVARCHAR(100) NOT NULL,
    manager_name NVARCHAR(100) NOT NULL,
    team_location NVARCHAR(100),
    team_members NVARCHAR(MAX),
    projects NVARCHAR(MAX),
    organization NVARCHAR(50),
    net_promoter_score DECIMAL(5,2)
);

INSERT INTO Teams (team_name, manager_name, team_location, team_members, projects, organization, net_promoter_score)
VALUES
('Core Banking Team', 'John Doe', 'Seneca One', 'Alice Johnson, Bob Smith, Charlie Brown', 'Core Banking Platform Modernization', 'Digital Banking Services', 8.75),
('Mobile Solutions Team', 'Jane Smith', 'Remote', 'David Miller, Emma Wilson, Frank Taylor', 'Mobile Banking App Enhancement', 'Mobile Technology', 9.50),
('Fraud Detection Unit', 'Michael Johnson', 'Wilmington Plaza', 'Grace Lee, Henry Thompson', 'Fraud Monitoring System Upgrade', 'Risk & Compliance', 7.80),
('Data Analytics Group', 'Sarah Lee', 'Lafayette Court', 'Liam Davis, Olivia Clark, Noah Martin', 'Customer Data Insights Platform', 'Data Science & Analytics', 9.10),
('Cybersecurity Team', 'William Brown', 'Remote', 'Sophia Martinez, James Carter', 'Cyber Threat Detection System', 'Cybersecurity', 8.25),
('Payment Solutions Team', 'Emily Davis', 'Seneca One', 'Lucas White, Mia Adams, Charlotte Scott', 'Real-Time Payments Infrastructure', 'Payments Technology', 8.60),
('Wealth Management IT', 'Andrew Wilson', 'Lafayette Court', 'Isabella Turner, Ethan Cooper, Jack Evans', 'Portfolio Management Platform', 'Wealth Management Technology', 7.90),
('Infrastructure Ops Team', 'Ella Martinez', 'Wilmington Plaza', 'Ava Bell, Benjamin Rivera', 'Cloud Migration for Infrastructure', 'IT Operations', 9.00),
('Customer Service IT', 'Daniel Clark', 'Remote', 'Harper Brooks, Alexander Hughes, Amelia Howard', 'AI-Powered Chatbot Development', 'Customer Technology Services', 9.30),
('Innovation Lab', 'Sophia Harris', 'Seneca One', 'Mason Reed, Evelyn Perry, Elijah Morgan', 'Blockchain-Based Settlements', 'Innovation & Strategy', 8.95);


CREATE TABLE CandidateInterestLookup(
    candidate_id INT not null,
    skill_id INT not null,
	PRIMARY KEY (candidate_id, skill_id),
	FOREIGN KEY (candidate_id) 
        REFERENCES CandidateProfile(id),
	FOREIGN KEY (skill_id) 
        REFERENCES Skills(id)
);

CREATE TABLE candidate_skill_lookup(
    candidate_id INT,
    team_id INT,
    skill_id INT not null,
    PRIMARY KEY (candidate_id, team_id, skill_id),
   FOREIGN KEY (candidate_id) 
        REFERENCES CandidateProfile(id),
   FOREIGN KEY (team_id) 
        REFERENCES team(id),
   FOREIGN KEY (skill_id) 
        REFERENCES Skills(id)
);