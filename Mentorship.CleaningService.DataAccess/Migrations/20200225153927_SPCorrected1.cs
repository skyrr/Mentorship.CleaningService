using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentorship.CleaningService.DataAccess.Migrations
{
    public partial class SPCorrected1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[sps_ClientsDemand]
	                @ClientId int NULL
                AS
                BEGIN
	            SET NOCOUNT ON;
	            IF @ClientId IS NULL 
				 
					SELECT CAST(ROW_NUMBER() OVER(ORDER BY ClientId ASC) As INT) As Id, dbo.Clients.Id AS ClientId, 
						(SELECT dbo.DemandStatuses.StatusName 
						FROM dbo.DemandStatuses
						WHERE dbo.DemandStatuses.Id = dbo.Demands.DemandStatusId)
						AS DemandStatusName
					, CONVERT(bit, 'false') AS IsDeleted
					FROM dbo.Clients
					INNER JOIN dbo.Demands 
					ON dbo.Clients.Id = dbo.Demands.ClientId
				ELSE
					SELECT CAST(ROW_NUMBER() OVER(ORDER BY ClientId ASC) As INT) As Id, dbo.Clients.Id AS ClientId, (SELECT dbo.DemandStatuses.StatusName 
						FROM dbo.DemandStatuses
						WHERE dbo.DemandStatuses.Id = dbo.Demands.DemandStatusId)
						AS DemandStatusName, CONVERT(bit, 'false') AS IsDeleted
					FROM dbo.Clients
					INNER JOIN dbo.Demands 
					ON dbo.Clients.Id = dbo.Demands.ClientId AND dbo.Clients.Id = @ClientId
				
            END
            ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[sps_ClientsDemand]");

        }
    }
}
