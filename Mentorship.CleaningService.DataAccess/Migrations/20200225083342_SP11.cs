using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentorship.CleaningService.DataAccess.Migrations
{
    public partial class SP11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[sps_ClientsDemand]
	            
	            @ClientId int NULL
            AS
            BEGIN
	            SET NOCOUNT ON;
	            IF @ClientId IS NULL 
				 
					SELECT Top(20) dbo.Clients.Id As Id, dbo.Clients.Id AS ClientId, dbo.Demands.DemandStatusId AS DemandStatusId, 'false' AS IsDeleted
					FROM dbo.Clients
					INNER JOIN dbo.Demands 
					ON dbo.Clients.Id = dbo.Demands.ClientId
				ELSE
					SELECT Top(20) dbo.Clients.Id As Id, dbo.Clients.Id AS ClientId, dbo.Demands.DemandStatusId AS DemandStatusId, 'false' AS IsDeleted
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
