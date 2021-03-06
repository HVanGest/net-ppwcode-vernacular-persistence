﻿using System;
using System.Runtime.Serialization;

namespace PPWCode.Vernacular.Persistence.II
{
    [Serializable, DataContract(IsReference = true)]
    public abstract class AuditLog<T>
        : PersistentObject<T>
        where T : IEquatable<T>
    {
        [DataMember]
        private DateTime m_CreatedAt;

        [DataMember]
        private string m_CreatedBy;

        [DataMember]
        private string m_EntityId;

        [DataMember]
        private string m_EntityName;

        [DataMember]
        private string m_EntryType;

        [DataMember]
        private string m_NewValue;

        [DataMember]
        private string m_OldValue;

        [DataMember]
        private string m_PropertyName;

        protected AuditLog(T id)
            : base(id)
        {
        }

        protected AuditLog()
            : this(default(T))
        {
        }

        public virtual string EntryType
        {
            get { return m_EntryType; }
            set { m_EntryType = value; }
        }

        public virtual string EntityName
        {
            get { return m_EntityName; }
            set { m_EntityName = value; }
        }

        public virtual string EntityId
        {
            get { return m_EntityId; }
            set { m_EntityId = value; }
        }

        public virtual string PropertyName
        {
            get { return m_PropertyName; }
            set { m_PropertyName = value; }
        }

        public virtual string OldValue
        {
            get { return m_OldValue; }
            set { m_OldValue = value; }
        }

        public virtual string NewValue
        {
            get { return m_NewValue; }
            set { m_NewValue = value; }
        }

        public virtual DateTime CreatedAt
        {
            get { return m_CreatedAt; }
            set { m_CreatedAt = value; }
        }

        public virtual string CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }
    }
}