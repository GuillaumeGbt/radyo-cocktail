BEGIN TRANSACTION;

ALTER TABLE "Cocktail" ADD "Description" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241125133819_DescriptionCocktailAdded', '8.0.10');

COMMIT;

