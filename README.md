CREATE TABLE Participants (
  [Id] INT NOT NULL IDENTITY (1,1),
  [Name] NVARCHAR(256) NOT NULL,
  [EmailAddress] NVARCHAR(256) NOT NULL,
  UNIQUE ([EmailAddress]),
  PRIMARY KEY ([Id]));

  CREATE TABLE Interviews (
  [Id] INT NOT NULL IDENTITY (1,1),
  [StartTime] DATETIME NOT NULL,
  [EndTime] DATETIME NOT NULL,
  PRIMARY KEY ([Id]));

  CREATE TABLE InterviewParticipants (
  [InterviewId] INT NOT NULL,
  [ParticipantId] INT NOT NULL,
  FOREIGN KEY ([InterviewId]) REFERENCES [dbo].[Interviews] ([Id]) ON DELETE CASCADE,
  FOREIGN KEY ([ParticipantId]) REFERENCES [dbo].[Participants] ([Id]) ON DELETE CASCADE,
  PRIMARY KEY ([InterviewId], [ParticipantId]));


INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Alok Kumar', 'alokkumar@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Bharat Kumar', 'bharatkumar@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Rahul Yadav', 'rahulyadav@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Kunal Kamra', 'kunalkamra@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Abhay Singh', 'abhaysingh@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Sakshi Gupta', 'sakshigupta@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Manushi Kumari', 'manushikumari@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Rohit Sahai', 'rohitsahay@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Shubham Saxena', 'shubhamsaxena@gmail.com')

INSERT INTO dbo.Participants ([Name], [EmailAddress])
VALUES ('Arun Meena', 'arun11meena@gmail.com')