CREATE TABLE CandidateProfile (
    uid NVARCHAR(50) PRIMARY KEY,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL UNIQUE,
    education NVARCHAR(100),
    year_of_gradution NVARCHAR(4),
    fun_fact NVARCHAR(200)
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

INSERT INTO CandidateProfile (uid, first_name, last_name, email, education, year_of_gradution, fun_fact) 
VALUES 
('N8BoYtR3z7S08gIoQZQXHZf7YgN2', 'Patricia', 'Harris', 'patricia.harris@example.com', 'Bachelor of Science in Computer Engineering', 2020, 'Loves skydiving.'),
('OuQTnMEO9KOkFoXtSjlIK2Qt6aM2', 'Lisa', 'Martin', 'lisa.martin@example.com', 'Master of Arts in Music', 2021, 'Plays the violin.'),
('20xQkkWV2QYuzTKUn8T1yURxUrB2', 'Emily', 'Brown', 'emily.brown@example.com', 'Bachelor of Arts in Zoology', 2020, 'Has a pet iguana.'),
('I7xKpUfmQUNSCkdpHGGzQK1zHsI3', 'Michael', 'Jones', 'michael.jones@example.com', 'Doctor of Philosophy in Physics', 2022, 'Loves solving Rubiks cubes.'),
('JRf8D7o9SHXcCoePHdiMMNPPkMS2', 'Sarah', 'Smith', 'sarah.smith@example.com', 'Master of Science in Environmental Science', 2021, 'Enjoys long-distance running.'),
('7Vyvymd5VTM9U2C731lZpAwfBQd2', 'John', 'Doe', 'john.doe@example.com', 'Bachelor of Science in Literature', 2020, 'Is an avid reader.');

INSERT INTO CandidateSkill (candidate_id, skill_id, skill_level) 
VALUES 
('N8BoYtR3z7S08gIoQZQXHZf7YgN2', 5, 4),
('N8BoYtR3z7S08gIoQZQXHZf7YgN2', 12, 3),
('N8BoYtR3z7S08gIoQZQXHZf7YgN2', 33, 5),
('OuQTnMEO9KOkFoXtSjlIK2Qt6aM2', 2, 4),
('OuQTnMEO9KOkFoXtSjlIK2Qt6aM2', 8, 2),
('OuQTnMEO9KOkFoXtSjlIK2Qt6aM2', 14, 3),
('20xQkkWV2QYuzTKUn8T1yURxUrB2', 7, 5),
('20xQkkWV2QYuzTKUn8T1yURxUrB2', 15, 4),
('20xQkkWV2QYuzTKUn8T1yURxUrB2', 25, 2),
('I7xKpUfmQUNSCkdpHGGzQK1zHsI3', 20, 3),
('I7xKpUfmQUNSCkdpHGGzQK1zHsI3', 30, 4),
('I7xKpUfmQUNSCkdpHGGzQK1zHsI3', 40, 5),
('JRf8D7o9SHXcCoePHdiMMNPPkMS2', 4, 2),
('JRf8D7o9SHXcCoePHdiMMNPPkMS2', 18, 3),
('JRf8D7o9SHXcCoePHdiMMNPPkMS2', 22, 4),
('7Vyvymd5VTM9U2C731lZpAwfBQd2', 10, 3),
('7Vyvymd5VTM9U2C731lZpAwfBQd2', 17, 5),
('7Vyvymd5VTM9U2C731lZpAwfBQd2', 42, 4),
('IOMeMjKaJpT56WOsApkm8emSCnG3', 6, 4),
('IOMeMjKaJpT56WOsApkm8emSCnG3', 11, 3),
('IOMeMjKaJpT56WOsApkm8emSCnG3', 28, 2);


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

INSERT INTO Managers (uid, manager_name, manager_email)
VALUES 
('IrgePIa7eZb1XQDyRg6ZuVM3Ljg1', 'Doris Foster', 'doris.foster@example.com'),
('BBWrXQ3a6PM6BckST9cS2ume0bv2', 'Margaret Fisher', 'margaret.fisher@example.com'),
('8VGeQKQLQWhdVHLOHqFW4Vvi0MT2', 'Martin Ward', 'martin.ward@example.com');

INSERT INTO Teams (team_name, manager_uid, team_location, team_members, projects, organization, net_promoter_score)
VALUES
('Code Crusaders', 'IrgePIa7eZb1XQDyRg6ZuVM3Ljg1', 'Seneca One', 'John Doe, Emma Stone, James Smith', 'Customer Onboarding Portal, Mobile Banking App Revamp', 'Retail Banking Division', 87);
('Bit Busters', 'BBWrXQ3a6PM6BckST9cS2ume0bv2', 'Lafayette Court', 'Liam Johnson, Olivia Brown, Daniel Harris', 'Loan Origination System, Corporate Credit Risk Analysis', 'Corporate Banking Subteam', 75);
('Bug Squashers', '8VGeQKQLQWhdVHLOHqFW4Vvi0MT2', 'Remote', 'Sophia Lee, Michael Clark, Chris Walker', 'Blockchain Payment System, Fraud Detection Algorithm', 'Digital Transformation Subteam', 92);

INSERT INTO TeamSkill (team_id, skill_id, skill_level)
VALUES
(3, 12, '8'),  -- Code Crusaders
(3, 33, '6'),
(3, 56, '10'),
(3, 72, '4'),
(3, 15, '7'),
(3, 45, '5'),
(3, 89, '9'),
(3, 67, '10'),
(3, 25, '3'),
(3, 99, '6'),

(4, 7, '9'),  -- Bit Busters (using previously chosen skill_ids)
(4, 24, '5'),
(4, 41, '8'),
(4, 89, '3'),
(4, 18, '6'),
(4, 62, '7'),
(4, 77, '10'),
(4, 53, '4'),
(4, 11, '8'),
(4, 68, '6'),

(5, 15, '5'),  -- Bug Squashers
(5, 28, '10'),
(5, 38, '7'),
(5, 92, '4'),
(5, 49, '8'),
(5, 63, '6'),
(5, 88, '9'),
(5, 26, '3'),
(5, 54, '8'),
(5, 37, '7');
