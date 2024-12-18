CREATE TABLE CandidateProfile (
    uid NVARCHAR(50) PRIMARY KEY,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL UNIQUE,
    education NVARCHAR(100),
    year_of_gradution NVARCHAR(4),
    fun_fact NVARCHAR(200)
);

INSERT INTO CandidateProfile (uid, first_name, last_name, email, education, year_of_gradution, fun_fact) 
VALUES (
    '5f73CMP9lQdRmTLugdDP6xbGhS72', 
    'Malkiel', 
    'Asher', 
    'tdevr3i@gmail.com', 
    'Bachelor of Science in Computer Engineering', 
    '2021', 
    'I once built a working robot from old car parts.'
);

CREATE TABLE Skills (
    id INT PRIMARY KEY IDENTITY(1,1),
    skill_name NVARCHAR(100)
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

CREATE TABLE Managers (
    uid NVARCHAR(50) PRIMARY KEY,
    manager_name NVARCHAR(100) NOT NULL,
    manager_email NVARCHAR(100) NOT NULL
);

CREATE TABLE Teams (
    id INT IDENTITY(1,1) PRIMARY KEY,
    team_name NVARCHAR(100) NOT NULL,
    manager_uid NVARCHAR(50) NOT NULL,
    team_location NVARCHAR(100),
    team_members NVARCHAR(MAX),
    projects NVARCHAR(MAX),
    organization NVARCHAR(50),
    net_promoter_score DECIMAL(5,2),
    FOREIGN KEY (manager_uid) REFERENCES Managers(uid)
);

INSERT INTO Teams (team_name, manager_uid, team_location, team_members, projects, organization, net_promoter_score) 
VALUES (
    'Banking Innovators', 
    'lfHZQ8gEAAQNBP0VddJ9YQ79x6A3', 
    'Seneca One', 
    'Alice Johnson, Bob Smith, Charlie Brown, Diana Prince', 
    'Digital Wallet Integration, AI Fraud Detection', 
    'Consumer Technology', 
    92.3
);


CREATE TABLE TeamSkill (
    team_id INT,
    skill_id INT,
    skill_level NVARCHAR(50),
    PRIMARY KEY (team_id, skill_id),
    FOREIGN KEY (team_id) REFERENCES Teams(id),
    FOREIGN KEY (skill_id) REFERENCES Skill(id)
);

CREATE TABLE CandidateSkill (
    candidate_id NVARCHAR(50),
    skill_id INT,
    skill_level NVARCHAR(50),
    PRIMARY KEY (candidate_id, skill_id),
    FOREIGN KEY (candidate_id) REFERENCES CandidateProfile(uid),
    FOREIGN KEY (skill_id) REFERENCES Skill(id)
);

INSERT INTO CandidateSkills (candidate_id, skill_id, skill_level) 
VALUES 
('5f73CMP9lQdRmTLugdDP6xbGhS72', 1, 'Expert'),
('5f73CMP9lQdRmTLugdDP6xbGhS72', 2, 'Intermediate'),
('5f73CMP9lQdRmTLugdDP6xbGhS72', 3, 'Beginner'),
('5f73CMP9lQdRmTLugdDP6xbGhS72', 4, 'Advanced'),
('5f73CMP9lQdRmTLugdDP6xbGhS72', 5, 'Expert');