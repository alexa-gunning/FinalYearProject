using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupAndRestoreController : Controller
    {
        [HttpPost]
        [Route("Backup")]
        public IActionResult Backup(string file)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server = tcp:inf370team40.database.windows.net,1433; Database = Team40; Persist Security Info = False; User ID = inf370team40_admin; Password = tuksofniks2022!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                connection.Open();
                string cmd = "BACKUP DATABASE[Team40] to Disk = 'C:\\Backups\\" + file + "';";
                SqlCommand com = new SqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                connection.Close();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpPost]
        [Route("Restore")]
        public IActionResult Restore(string file)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server = tcp:inf370team40.database.windows.net,1433; Database = Team40; Persist Security Info = False; User ID = inf370team40_admin; Password = tuksofniks2022!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                connection.Open();
                string database = connection.Database.ToString();
                SqlCommand cmd = new SqlCommand("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", connection);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + file + "' WITH REPLACE;", connection);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("ALTER DATABASE [" + database + "] SET MULTI_USER", connection);
                cmd2.ExecuteNonQuery();
                return Ok();
                connection.Close();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
    }
}
