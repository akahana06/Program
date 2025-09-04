﻿using System;
using System.Collections;

namespace AssignmentApp
{
    abstract class User
    {
        public int id;
        public string password;
        public string name;
        public string address;
        public string email;
        public string phone;
        public ArrayList appointments = new ArrayList();

        public enum Role
        {
            P,
            D,
            A
        }
        // upate
        public abstract void MainMenu();
        public Role UserRole { get; set; }

        public void LoadUser(string line)
        {
            string[] u = line.Split(',');
            id = Convert.ToInt32(u[1]);
            password = u[2];
            name = u[3];
            address = u[4];
            email = u[5];
            phone = u[6];
        }

    }
}