using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSN.Models;

namespace DSN.DAL
{
    public class UserProfilesDataAccess: DataAccessBase
    {
        public UserViewModel  GetUsers()
        {
            UserViewModel users = new UserViewModel
            {
                Individuals = new List<IndividualViewModel>(),
                Organizations = new List<OrganizationViewModel>()
            };
            using (IDataReader reader= ExecuteReader(Constants.SPROC.GetNetwork,DbCommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    IndividualViewModel individual = new IndividualViewModel
                    {
                        Id = (int)reader[Constants.Individual.Id],
                        Name = (string)reader[Constants.Individual.Name],
                        Title = (string) reader[Constants.Individual.Title],
                        Organisation = (string) reader[Constants.Individual.Organization]
                    };
                    users.Individuals.Add(individual);
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        OrganizationViewModel organization = new OrganizationViewModel
                        {
                            Id = (int) reader[Constants.Organization.Id],
                            Name = (string) reader[Constants.Organization.Name],
                            Description = (string) reader[Constants.Organization.Description]
                        };
                        users.Organizations.Add(organization);
                    }
                }            
            }
            return users;
        }

        public UserViewModel GetUsers(int id)
        {
            UserViewModel users = new UserViewModel
            {
                Individuals = new List<IndividualViewModel>(),
                Organizations = new List<OrganizationViewModel>()
            };
            List<DbParameter> parameters = new List<DbParameter>
            {
                new SqlParameter("Id", id)
            };
            using (IDataReader reader = ExecuteReader(Constants.SPROC.GetUsersNetwork, DbCommandType.StoredProcedure, parameters))
            {
                while (reader.Read())
                {
                    IndividualViewModel individual = new IndividualViewModel
                    {
                        Id = (int)reader[Constants.Individual.Id],
                        Name = (string)reader[Constants.Individual.Name],
                        Title = (string)reader[Constants.Individual.Title],
                        Organisation = (string)reader[Constants.Individual.Organization]
                    };
                    users.Individuals.Add(individual);
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        OrganizationViewModel organization = new OrganizationViewModel
                        {
                            Id = (int)reader[Constants.Organization.Id],
                            Name = (string)reader[Constants.Organization.Name],
                            Description = (string)reader[Constants.Organization.Description]
                        };
                        users.Organizations.Add(organization);
                    }
                }
            }
            return users;
        }

    }
}