﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PengBugTracker.Models;

namespace PengBugTracker.Helpers
{
    public class ProjectHelper
    {

            private ApplicationDbContext db = new ApplicationDbContext();
            private RoleHelper roleHelper = new RoleHelper();

            public List<string>ListUsersOnProjectRole(int projectId, string roleName)
            {
                var userIdList = new List<string>();
            foreach (var user in UsersOnProject(projectId))
                {
                    if (roleHelper.IsUserInRole(user.Id, roleName))
                        userIdList.Add(user.Id);
                }
                return userIdList;
            }
            public bool IsUserOnProject(string userId, int projectId)
            {
                var project = db.Projects.Find(projectId);
                var flag = project.Users.Any(u => u.Id == userId);
                return (flag);
            }
            public ICollection<Project> ListUserProjects(string userId)
            {
                ApplicationUser user = db.Users.Find(userId);
                var projects = user.Projects.ToList();
                return (projects);
            }
            public void AddUserToProject(string userId, int projectId)
            {
                if (!IsUserOnProject(userId, projectId))
                {
                    Project proj = db.Projects.Find(projectId);
                    var newUser = db.Users.Find(userId);
                    proj.Users.Add(newUser);
                    db.SaveChanges();
                }
            }

            public void RemoveUserFromProject(string userId, int projectId)
            {
                if (IsUserOnProject(userId, projectId))
                {
                    Project proj = db.Projects.Find(projectId);
                    var delUser = db.Users.Find(userId);

                    proj.Users.Remove(delUser);
                    db.Entry(proj).State = EntityState.Modified; // just saves this obj instance.
                    db.SaveChanges();
                }
            }
            public ICollection<ApplicationUser> UsersOnProject(int projectId)
            {
                return db.Projects.Find(projectId).Users;
            }
            public ICollection<ApplicationUser> UsersNotOnProject(int projectId)
            {
                return db.Users.Where(u => u.Projects.All(p => p.Id != projectId)).ToList();
            }
        }

        public class UserProjectsHelper
        {
            private UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new
           UserStore<ApplicationUser>(new ApplicationDbContext()));
            private ApplicationDbContext db = new ApplicationDbContext();
            public bool IsOnProject(string userId, int projectId)
            {

                if (db.Projects.Find(projectId).Users.Contains(db.Users.Find(userId)))
                {
                    return true;
                }
                return false;
            }

            public void AddUserToProject(string userId, int projectId)
            {
                if (!IsOnProject(userId, projectId))
                {
                    var project = db.Projects.Find(projectId);
                    project.Users.Add(db.Users.Find(userId));
                    db.Entry(project).State = EntityState.Modified; // just saves this obj instance.
                    db.SaveChanges();
                }
            }
            public void RemoveUserFromProject(string userId, int projectId)
            {
                if (IsOnProject(userId, projectId))
                {
                    var project = db.Projects.Find(projectId);
                    project.Users.Remove(db.Users.Find(userId));
                    db.Entry(project).State = EntityState.Modified; // just saves this obj instance.
                    db.SaveChanges();
                }
            }
            public ICollection<ApplicationUser> ListUsersOnProject(int projectId)
            {
                return db.Projects.Find(projectId).Users;
            }
            public ICollection<Project> ListProjectsForUser(string userId)
            {
                return db.Users.Find(userId).Projects;
            }
            public ICollection<ApplicationUser> ListUsersNotOnProject(int projectId)
            {
                return db.Users.Where(u => u.Projects.All(p => p.Id != projectId)).ToList();
            }
        

    }

}