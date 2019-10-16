CREATE TABLE "TaskWork" (
    "Id" BLOB NOT NULL CONSTRAINT "PK_TaskWork" PRIMARY KEY,
    "CreateDate" TEXT NOT NULL,
    "Title" TEXT NULL,
    "Description" TEXT NULL
);
