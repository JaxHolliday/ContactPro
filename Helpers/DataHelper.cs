using ContactPro.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactPro.Helpers
{
    public static class DataHelper
    {
        //service helps the database stay in sync
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            //ability to go to DB and run it so when published it will creat DB for us
            //Service provided allows access to our services

            //get an instance of the db application context
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();

            //migration: this is equivalent to update-database
            await dbContextSvc.Database.MigrateAsync();
        }

    }
}
