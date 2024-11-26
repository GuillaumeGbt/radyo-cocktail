BEGIN TRANSACTION;

CREATE UNIQUE INDEX "IX_Cocktail_Name" ON "Cocktail" ("Name");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241126135259_UniqueCocktailName', '8.0.10');

COMMIT;

