using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
    [ProtoContract]
     public class User
    {

    /// <summary>
    /// Parameterless constructor required for protobuf
    /// </summary>
        [ProtoMember(1)]
        public string name;
        [ProtoMember(2)]
        public string password;
        [ProtoMember(3)]
        public int level;
        [ProtoMember(4)]
        public long exp;
        [ProtoMember(5)]
        public double balance;
        [ProtoMember(6)]
        public DateTime regDate;
        [ProtoMember(7)]
        public DateTime lastVisit;
        [ProtoMember(8)]
        public string personalName;
        [ProtoMember(9)]
        public string personalSurname;
        [ProtoMember(10)]
        public string phoneNumber;
        [ProtoMember(11)]
        public int[] offers;
        [ProtoMember(12)]
        public string email;
        [ProtoMember(13)]
        public string usergroup = "Default";
        [ProtoMember(14)]
        public long expToNextLvl;

        protected User() { }

        public User(string username = "", string userpassword ="")
        {
            name = username;
            password = userpassword;
        }

    
    }

