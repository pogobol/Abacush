SET XACT_ABORT ON;

BEGIN TRANSACTION;

IF OBJECT_ID(N'[ObjectTypes]', N'U') IS NULL
BEGIN
	CREATE TABLE [ObjectTypes]
	(
		[Id] uniqueidentifier NOT NULL,
		[Name] nvarchar(200) NOT NULL,
		[Description] nvarchar(1000) NULL,
		[Interface] nvarchar(max) NOT NULL,
		CONSTRAINT [PK_ObjectTypes] PRIMARY KEY ([Id])
	);
END;

IF OBJECT_ID(N'[QualifiedSubjects]', N'U') IS NULL
BEGIN
	CREATE TABLE [QualifiedSubjects]
	(
		[Id] uniqueidentifier NOT NULL,
		[Name] nvarchar(200) NOT NULL,
		[Description] nvarchar(1000) NULL,
		[Interface] nvarchar(max) NOT NULL,
		[Attributes] nvarchar(max) NOT NULL,
		CONSTRAINT [PK_QualifiedSubjects] PRIMARY KEY ([Id])
	);
END;

IF OBJECT_ID(N'[QualifiedObjects]', N'U') IS NULL
BEGIN
	CREATE TABLE [QualifiedObjects]
	(
		[Id] uniqueidentifier NOT NULL,
		[Name] nvarchar(200) NOT NULL,
		[Description] nvarchar(1000) NULL,
		[Attributes] nvarchar(max) NOT NULL,
		[TypeId] uniqueidentifier NOT NULL,
		CONSTRAINT [PK_QualifiedObjects] PRIMARY KEY ([Id]),
		CONSTRAINT [FK_QualifiedObjects_ObjectTypes_TypeId]
			FOREIGN KEY ([TypeId]) REFERENCES [ObjectTypes] ([Id]) ON DELETE NO ACTION
	);
END;

IF OBJECT_ID(N'[Permissions]', N'U') IS NULL
BEGIN
	CREATE TABLE [Permissions]
	(
		[Id] uniqueidentifier NOT NULL,
		[ObjectId] uniqueidentifier NOT NULL,
		[Actions] nvarchar(max) NOT NULL,
		CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id]),
		CONSTRAINT [FK_Permissions_QualifiedObjects_ObjectId]
			FOREIGN KEY ([ObjectId]) REFERENCES [QualifiedObjects] ([Id]) ON DELETE NO ACTION
	);
END;

IF OBJECT_ID(N'[PermissionSubjects]', N'U') IS NULL
BEGIN
	CREATE TABLE [PermissionSubjects]
	(
		[PermissionsId] uniqueidentifier NOT NULL,
		[SubjectsId] uniqueidentifier NOT NULL,
		CONSTRAINT [PK_PermissionSubjects] PRIMARY KEY ([PermissionsId], [SubjectsId]),
		CONSTRAINT [FK_PermissionSubjects_Permissions_PermissionsId]
			FOREIGN KEY ([PermissionsId]) REFERENCES [Permissions] ([Id]) ON DELETE CASCADE,
		CONSTRAINT [FK_PermissionSubjects_QualifiedSubjects_SubjectsId]
			FOREIGN KEY ([SubjectsId]) REFERENCES [QualifiedSubjects] ([Id]) ON DELETE CASCADE
	);
END;

IF NOT EXISTS
(
	SELECT 1
	FROM sys.indexes
	WHERE name = N'IX_QualifiedObjects_TypeId'
	  AND object_id = OBJECT_ID(N'[QualifiedObjects]')
)
BEGIN
	CREATE INDEX [IX_QualifiedObjects_TypeId]
		ON [QualifiedObjects] ([TypeId]);
END;

IF NOT EXISTS
(
	SELECT 1
	FROM sys.indexes
	WHERE name = N'IX_Permissions_ObjectId'
	  AND object_id = OBJECT_ID(N'[Permissions]')
)
BEGIN
	CREATE INDEX [IX_Permissions_ObjectId]
		ON [Permissions] ([ObjectId]);
END;

IF NOT EXISTS
(
	SELECT 1
	FROM sys.indexes
	WHERE name = N'IX_PermissionSubjects_SubjectsId'
	  AND object_id = OBJECT_ID(N'[PermissionSubjects]')
)
BEGIN
	CREATE INDEX [IX_PermissionSubjects_SubjectsId]
		ON [PermissionSubjects] ([SubjectsId]);
END;

COMMIT TRANSACTION;
