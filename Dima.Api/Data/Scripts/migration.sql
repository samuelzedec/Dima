IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Category] (
    [Id] BIGINT NOT NULL IDENTITY,
    [Title] NVARCHAR(80) NOT NULL,
    [Description] NVARCHAR(255) NULL,
    [UserId] VARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Category_Id] PRIMARY KEY ([Id])
);

CREATE TABLE [IdentityRoleClaim] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] bigint NOT NULL,
    [ClaimType] nvarchar(255) NULL,
    [ClaimValue] nvarchar(255) NULL,
    CONSTRAINT [PK_IdentityRoleClaim_Id] PRIMARY KEY ([Id])
);

CREATE TABLE [IdentityUser] (
    [Id] bigint NOT NULL IDENTITY,
    [UserName] nvarchar(180) NULL,
    [NormalizedUserName] nvarchar(180) NULL,
    [Email] nvarchar(180) NULL,
    [NormalizedEmail] nvarchar(180) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(20) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_IdentityUser_Id] PRIMARY KEY ([Id])
);

CREATE TABLE [Transaction] (
    [Id] BIGINT NOT NULL IDENTITY,
    [Title] NVARCHAR(80) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [PaidOrReceivedAt] DATETIME2 NULL,
    [Type] SMALLINT NOT NULL,
    [Amount] MONEY NOT NULL,
    [CategoryId] BIGINT NOT NULL,
    [UserId] VARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Transaction_Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transaction_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [IdentityClaim] (
    [Id] int NOT NULL IDENTITY,
    [UserId] bigint NOT NULL,
    [ClaimType] nvarchar(255) NULL,
    [ClaimValue] nvarchar(255) NULL,
    CONSTRAINT [PK_IdentityUserClaim_Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IdentityClaim_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [IdentityUserLogin] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(255) NULL,
    [UserId] bigint NOT NULL,
    CONSTRAINT [PK_IdentityUserLogin_LoginProvider_ProviderKey] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_IdentityUserLogin_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [IdentityUserRole] (
    [UserId] bigint NOT NULL,
    [RoleId] bigint NOT NULL,
    CONSTRAINT [PK_Identity_UserId_RoleId] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_IdentityUserRole_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [IdentityUserToken] (
    [UserId] bigint NOT NULL,
    [LoginProvider] nvarchar(120) NOT NULL,
    [Name] nvarchar(180) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityUserToken_UserId_LoginProvider_Name] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_IdentityUserToken_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [IdentiyUserRole] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NULL,
    [NormalizedName] nvarchar(255) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [UserId] bigint NULL,
    CONSTRAINT [PK_IdentityRole_Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IdentiyUserRole_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id])
);

CREATE INDEX [IX_IdentityClaim_UserId] ON [IdentityClaim] ([UserId]);

CREATE UNIQUE INDEX [IX_IdentityUser_NormalizedUserName] ON [IdentityUser] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

CREATE UNIQUE INDEX [IX_IdentityUser_NormalizeEmail] ON [IdentityUser] ([NormalizedEmail]) WHERE [NormalizedEmail] IS NOT NULL;

CREATE INDEX [IX_IdentityUserLogin_UserId] ON [IdentityUserLogin] ([UserId]);

CREATE UNIQUE INDEX [IX_IdentityRole_NormalizedName] ON [IdentiyUserRole] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_IdentiyUserRole_UserId] ON [IdentiyUserRole] ([UserId]);

CREATE INDEX [IX_Transaction_CategoryId] ON [Transaction] ([CategoryId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250304190131_StartingDatabase', N'9.0.2');

COMMIT;
GO

