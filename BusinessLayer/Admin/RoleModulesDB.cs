using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	public class RoleModulesDB
    {
		public List<ADMRoleModules> GetAll()
		{
            List<ADMRoleModules> roles = this.dbContext.ADMRoleModules.ToList<ADMRoleModules>();
            //roles.ForEach(a => a.Modules = "1;2;3");
            return roles;
		}

		public ADMRoleModules GetByID(int id)
		{
			return this.dbContext.ADMRoleModules.First((ADMRoleModules role) => role.RoleModuleID == id);
		}

		public bool Insert(ADMRoleModules entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				if (this.CheckRoleModuleExist(entity.FKRoleID, entity.FKModuleID))
				{
					message = "RoleModuleExist";
					result = false;
				}
				else
				{
					this.dbContext.ADMRoleModules.Add(entity);
					if (this.dbContext.SaveChanges() > 0)
					{
						result = true;
					}
					else
					{
						message = "InsertError";
						result = false;
					}
				}
			}
			catch
			{
				message = "InsertError";
				result = false;
			}
			return result;
		}

		public bool Update(ADMRoleModules entity, out string message)
		{
			message = "";
			bool result;
			try
			{
                ADMRoleModules byID = this.GetByID(int.Parse(entity.RoleModuleID.ToString()));
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMRoleModules>(byID);
				dbEntityEntry.State = EntityState.Modified;
				dbEntityEntry.CurrentValues.SetValues(entity);
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					message = "UpdateError";
					result = false;
				}
			}
			catch
			{
				message = "UpdateError";
				result = false;
			}
			return result;
		}

		public bool Delete(ADMRoleModules entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMRoleModules>(entity).State = EntityState.Deleted;
				result = (this.dbContext.SaveChanges() > 0);
			}
			catch
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		public bool Delete(int id, out string message)
		{
			return this.Delete(this.GetByID(id), out message);
		}

		public bool CheckRoleModuleExist(int roleID, int moduleID)
		{
			return (from entity in this.dbContext.ADMRoleModules
                    where entity.FKRoleID == roleID && entity.FKModuleID == moduleID
                    select entity).Count<ADMRoleModules>() > 0;
		}

        public ADMRoleModules GetByRoleAndModuleContains(int roleID, int moduleID)
        {
            ADMRoleModules roleModule = this.dbContext.ADMRoleModules.Where(entity => entity.FKRoleID == roleID && entity.FKModuleID == moduleID).FirstOrDefault();
            return roleModule;
        }

        public List<ADMRoleModules> GetByRoleContains(int roleID)
        {
            List<ADMRoleModules> roleModules = this.dbContext.ADMRoleModules.Where(entity => entity.FKRoleID == roleID).ToList();
            return roleModules;
        }

        private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
