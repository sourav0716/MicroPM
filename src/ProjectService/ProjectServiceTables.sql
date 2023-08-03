create table projects
(
    projectid uniqueidentifier not null Primary Key,
    projectname varchar(50) not null unique,
    projectdescription varchar(100),
    workflowid uniqueidentifier,
    projectstatus varchar(20),
    created datetime(2),
    modified datetime(2),
    createdby uniqueidentifier,
    modifiedby uniqueidentifier
)

create table componets
(
    componetid uniqueidentifier not null,
    projectid uniqueidentifier not null ,
    componentname varchar(50) not null ,
    componentdescription varchar(100),
    workflowid uniqueidentifier,
    created datetime(2),
    modified datetime(2),
    createdby uniqueidentifier,
    modifiedby uniqueidentifier,
    CONSTRAINT PK_componet PRIMARY KEY (componetid,projectid),
    CONSTRAINT FK_Project_componet FOREIGN KEY (projectid)
    REFERENCES Project(projectid)
)

create table ProjectUsers
(
    userid uniqueidentifier not null,
    projectid uniqueidentifier not null ,
    created datetime(2),
    modified datetime(2),
    createdby uniqueidentifier,
    modifiedby uniqueidentifier,
    userrole varchar(20),
    CONSTRAINT PK_componet PRIMARY KEY (userid,projectid),
    CONSTRAINT FK_Project_User FOREIGN KEY (projectid)
    REFERENCES Project(projectid)
)

